using System.Linq;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
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
            M2C_MicroDustArmies armies = new();
            var armyComponent = player.GetComponent<MicroDustArmyComponent>();
            foreach (var army in armyComponent.Armies)
            {
                var a = MicroDustArmyMessage.Create();
                foreach (var hero in army.HeroIds)
                {
                    a.HeroIds.Add(hero);
                }
                armies.Arimes.Add(a);
            }
            MicroDustMapMessageHelper.SendToClient(player, armies);
        }
    }
}
