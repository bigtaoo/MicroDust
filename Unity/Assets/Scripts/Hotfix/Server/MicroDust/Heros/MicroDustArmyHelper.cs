using System.Linq;

namespace ET.Server
{
    public static class MicroDustArmyHelper
    {
        public static async ETTask SaveData(MicroDustPlayerComponent player)
        {
            var db = DBFactory.GetDBComponent(player.Root(), 1);
            var army = player.GetComponent<MicroDustArmyComponent>();
            await db.Save(army, MicroDustCollections.Army);
        }

        public static async ETTask LoadData(MicroDustPlayerComponent player, string userId)
        {
            var db = DBFactory.GetDBComponent(player.Root(), 1);
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
                var a = new MicroDustArmyMessage();
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
