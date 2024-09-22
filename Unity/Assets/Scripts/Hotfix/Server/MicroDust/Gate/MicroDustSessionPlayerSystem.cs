namespace ET.Server
{
    [EntitySystemOf(typeof(MicroDustSessionPlayerComponent))]
    public static partial class MicroDustSessionPlayerSystem
    {
        [EntitySystem]
        private static void Destroy(this MicroDustSessionPlayerComponent self)
        {
            Scene root = self.Root();
            if (root.IsDisposed)
            {
                return;
            }

            var request = G2M_MicroDust_SessionDisconnect.Create();
            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit)
                .Send(self.Player.Id, request);
        }

        [EntitySystem]
        private static void Awake(this MicroDustSessionPlayerComponent self)
        {

        }
    }
}
