namespace ET.Server
{
    [FriendOf(typeof(MicroDustGateSessionKeyComponent))]
    public static partial class MicroDustGateSessionKeySystem
    {
        public static void Add(this MicroDustGateSessionKeyComponent self, long key, string account)
        {
            self.sessionKey.Add(key, account);
            self.TimeoutRemoveKey(key).Coroutine();
        }

        public static string Get(this MicroDustGateSessionKeyComponent self, long key)
        {
            self.sessionKey.TryGetValue(key, out var account);
            return account;
        }

        public static void Remove(this MicroDustGateSessionKeyComponent self, long key)
        {
            self.sessionKey.Remove(key);
        }

        private static async ETTask TimeoutRemoveKey(this MicroDustGateSessionKeyComponent self, long key)
        {
            await self.Fiber().TimerComponent.WaitAsync(20000);
            self.sessionKey.Remove(key);
        }
    }
}
