namespace ET.Server
{
    [FriendOf(typeof(MicroDustAllGatePlayersComponent))]
    public static partial class MicroDustPlayerSystem
    {
        public static void Add(this MicroDustAllGatePlayersComponent self, MicroDustGatePlayerComponent player)
        {
            self.dictionary.Add(player.Account, player);
        }

        public static void Remove(this MicroDustAllGatePlayersComponent self, MicroDustGatePlayerComponent player)
        {
            self.dictionary.Remove(player.Account);
            player.Dispose();
        }

        public static MicroDustGatePlayerComponent GetByAccount(this MicroDustAllGatePlayersComponent self, string account)
        {
            self.dictionary.TryGetValue(account, out var player);
            return player;
        }
    }
}
