using System.Linq;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2M_MicroDust_HerosHandler : MessageSessionHandler<C2M_MicroDust_Heros, M2C_MicroDust_Heros>
    {
        protected override async ETTask Run(Session session, C2M_MicroDust_Heros request, M2C_MicroDust_Heros response)
        {
            var player = session.GetComponent<MicroDustSessionPlayerComponent>().Player;
            var db = DBFactory.GetDBComponent(session, session.Zone());
            var heros = (await db.Query<MicroDustHeroComponent>(h => h.PlayerId == player.PlayerId,
                MicroDustCollections.Heros)).FirstOrDefault();
            heros ??= new MicroDustHeroComponent();
            response.heros = heros.Heros.Select(h => ToHeroInfo(h)).ToList();
            await ETTask.CompletedTask;
        }

        private MicroDustHeroInfo ToHeroInfo(MicroDustHero hero)
        {
            return new MicroDustHeroInfo
            {
                Id = hero.Id,
                ConfigId = hero.ConfigId,
                Level = hero.Level,
                Star = hero.Star,
            };
        }
    }
}
