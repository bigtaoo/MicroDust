using System.Linq;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public static class MicroDustArmyHelper
    {
        public static async ETTask SaveData(MicroDustPlayerComponent player)
        {
            var db = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(1);
            var army = player.GetComponent<MicroDustArmyComponent>();
            await db.Save(army, MicroDustCollections.Army);
        }

        public static async ETTask LoadData(MicroDustPlayerComponent player, string userId)
        {
            var db = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(1);
            var army = (await db.Query<MicroDustArmyComponent>(p => p.userId == userId, MicroDustCollections.Army))
                .FirstOrDefault();
            army ??= new MicroDustArmyComponent();
            player.RemoveComponent<MicroDustArmyComponent>();
            player.AddComponent(army);
        }

        public static void SendArmyInfoToClient(MicroDustPlayerComponent player)
        {
            var armies = M2C_MicroDustArmies.Create();
            var armyComponent = player.GetComponent<MicroDustArmyComponent>();
            for (var i = 0; i < armyComponent.Armies.Count; ++i)
            {
                var army = armyComponent.GetArmyByIndex(i);
                var a = MicroDustArmyMessage.Create();
                foreach (var hero in army.HeroIds)
                {
                    a.HeroIds.Add(hero);
                }
                armies.Arimes.Add(a);
            }
            MicroDustMapMessageHelper.SendToClient(player, armies);

            //Log.Warning($"send army info: {armies.ToJson()}");
        }
    }
}
