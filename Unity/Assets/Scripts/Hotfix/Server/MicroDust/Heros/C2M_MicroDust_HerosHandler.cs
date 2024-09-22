using System.Linq;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2M_MicroDust_HerosHandler : MessageSessionHandler<C2M_MicroDust_Heros, M2C_MicroDust_Heros>
    {
        protected override async ETTask Run(Session session, C2M_MicroDust_Heros request, M2C_MicroDust_Heros response)
        {
            var player = session.GetComponent<MicroDustSessionPlayerComponent>().Player;
            var db = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(session.Zone());
            var heros = (await db.Query<MicroDustHeroComponent>(h => h.PlayerId == player.PlayerId,
                MicroDustCollections.Heros)).FirstOrDefault();
            heros ??= new MicroDustHeroComponent();
            response.heros = heros.Heros.Select(h => ToHeroInfo(h)).ToList();
            await ETTask.CompletedTask;
        }

        private MicroDustHeroInfo ToHeroInfo(MicroDustHero hero)
        {
            var result = MicroDustHeroInfo.Create();

            result.Id = hero.Id;
            result.ConfigId = hero.ConfigId;
            result.Level = hero.Level;
            result.Star = hero.Star;

            return result;
        }
    }
}
