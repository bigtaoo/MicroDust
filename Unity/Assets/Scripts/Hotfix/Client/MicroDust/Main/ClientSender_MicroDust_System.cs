namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustClientSenderComponent))]
    [FriendOf(typeof(MicroDustClientSenderComponent))]
    public static partial class MicroDustClientSenderSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustClientSenderComponent self)
        {
        }

        [EntitySystem]
        private static void Destroy(this MicroDustClientSenderComponent self)
        {
            self.RemoveFiberAsync().Coroutine();
        }

        private static async ETTask RemoveFiberAsync(this MicroDustClientSenderComponent self)
        {
            if (self.fiberId == 0)
            {
                return;
            }

            int fiberId = self.fiberId;
            self.fiberId = 0;
            await FiberManager.Instance.Remove(fiberId);
        }

        public static async ETTask<(long, string)> LoginAsync(this MicroDustClientSenderComponent self, string account, string password)
        {
            self.fiberId = await FiberManager.Instance.Create(SchedulerType.ThreadPool, 0, SceneType.MicroDustNetClient, "");
            self.netClientActorId = new ActorId(self.Fiber().Process, self.fiberId);

            Log.Debug($"Send login with account[{account}] password[{password}]");

            var request = Main2NetClient_MicroDust_Login.Create();
            request.OwnerFiberId = self.fiberId;
            request.Account = account;
            request.Password = password;
            var response = await self.Root().GetComponent<ProcessInnerSender>().Call(
                self.netClientActorId, request) as NetClient2Main_MicroDust_Login;
            return (response.PlayerId, response.UserId);
        }

        public static void Send(this MicroDustClientSenderComponent self, IMessage message)
        {
            MicroDust_A2NetClient_Message a2NetClientMessage = MicroDust_A2NetClient_Message.Create();
            a2NetClientMessage.MessageObject = message;
            self.Root().GetComponent<ProcessInnerSender>().Send(self.netClientActorId, a2NetClientMessage);
        }

        public static async ETTask<IResponse> Call(this MicroDustClientSenderComponent self, IRequest request, bool needException = true)
        {
            A2NetClient_MicroDust_Request a2NetClientRequest = A2NetClient_MicroDust_Request.Create();
            a2NetClientRequest.MessageObject = request;
            A2NetClient_MicroDust_Response a2NetClientResponse = await self.Root().GetComponent<ProcessInnerSender>().Call(
                self.netClientActorId, a2NetClientRequest) as A2NetClient_MicroDust_Response;
            IResponse response = a2NetClientResponse.MessageObject;

            if (response.Error == ErrorCore.ERR_MessageTimeout)
            {
                throw new RpcException(response.Error, $"Rpc error: request, Actor message timeout，" +
                    $"Please check if there is deadlock or no reply: {request}, response: {response}");
            }

            if (needException && ErrorCore.IsRpcNeedThrowException(response.Error))
            {
                throw new RpcException(response.Error, $"Rpc error: {request}, response: {response}");
            }
            return response;
        }
    }
}
