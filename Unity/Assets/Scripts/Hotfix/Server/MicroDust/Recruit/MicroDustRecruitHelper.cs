using System;
using System.Linq;

namespace ET.Server
{
    public static class MicroDustRecruitHelper
    {
        public static int RecruitOnce(Session session, string playerId)
        {
            var heros = MicroDustHeroConfigCategory.Instance.GetAll();
            var hero = heros.ElementAtOrDefault(RandomGenerator.RandomNumber(0, heros.Count()));
            SaveHero(session, playerId, hero.Key).Coroutine();
            return hero.Key;
        }

        private static async ETTask SaveHero(Session session, string playerId, int heroId)
        {
            var db = session.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(session.Zone());
            var heros = (await db.Query<MicroDustHeroComponent>(h => h.PlayerId == playerId,
                MicroDustCollections.Heros)).FirstOrDefault();
            if (heros == null)
            {
                heros = new MicroDustHeroComponent();
                heros.ForceIdInit();
            }
            heros.PlayerId = playerId;
            heros.Heros.Add(new MicroDustHero
            {
                Id = Guid.NewGuid().ToString(),
                ConfigId = heroId,
                Level = 1,
                Star = 0,
            });
            await db.Save(heros, MicroDustCollections.Heros);
        }
    }
}
