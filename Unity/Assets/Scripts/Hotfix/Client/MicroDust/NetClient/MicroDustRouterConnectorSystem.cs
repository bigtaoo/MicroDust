using System.Net;

namespace ET.Client
{
    [FriendOf(typeof(MicroDustRouterConnector))]
    [EntitySystemOf(typeof(MicroDustRouterConnector))]
    public static partial class MicroDustRouterConnectorSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustRouterConnector self)
        {
            NetComponent netComponent = self.GetParent<NetComponent>();
            KService kService = (KService)netComponent.AService;
            kService.AddRouterAckCallback(self.Id, (flag) =>
            {
                self.Flag = flag;
            });
        }

        [EntitySystem]
        private static void Destroy(this MicroDustRouterConnector self)
        {
            NetComponent netComponent = self.GetParent<NetComponent>();
            KService kService = (KService)netComponent.AService;
            kService.RemoveRouterAckCallback(self.Id);
        }

        public static void Connect(this MicroDustRouterConnector self, byte[] bytes, int index, int length, IPEndPoint ipEndPoint)
        {
            NetComponent netComponent = self.GetParent<NetComponent>();
            KService kService = (KService)netComponent.AService;
            kService.Transport.Send(bytes, index, length, ipEndPoint);
        }
    }
}