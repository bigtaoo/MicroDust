namespace ET.Server
{
    [EntitySystemOf(typeof(MicroDustGatePlayerComponent))]
    [FriendOf(typeof(MicroDustGatePlayerComponent))]
    public static partial class MicroDustGatePlayerSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustGatePlayerComponent self, string a)
        {
            self.Account = a;
        }
    }
}
