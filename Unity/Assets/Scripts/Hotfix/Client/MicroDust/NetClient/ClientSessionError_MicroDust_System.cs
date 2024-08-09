namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustClientSessionErrorComponent))]
    public static partial class ClientSessionError_MicroDust_System
    {
        [EntitySystem]
        private static void Awake(this MicroDustClientSessionErrorComponent self)
        {

        }

        [EntitySystem]
        private static void Destroy(this MicroDustClientSessionErrorComponent self)
        {
            Fiber fiber = self.Fiber();
            if (fiber.IsDisposed)
            {
                return;
            }
            var message = NetClient2Main_MicroDust_SessionDispose.Create();
            message.Error = self.GetParent<Session>().Error;
            self.Root().GetComponent<ProcessInnerSender>().Send(new ActorId(fiber.Process, ConstFiberId.Main), message);
        }
    }
}
