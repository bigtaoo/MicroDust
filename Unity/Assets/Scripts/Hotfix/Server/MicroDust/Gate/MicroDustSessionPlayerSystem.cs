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

            root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit)
                .Send(self.Player.Id, new G2M_MicroDust_SessionDisconnect());
        }

        [EntitySystem]
        private static void Awake(this MicroDustSessionPlayerComponent self)
        {

        }
    }
}
