using System.Linq;

namespace ET
{
    public static class MicroDustHeroHelper
    {
        public static MicroDustHeroConfig GetHeroConfigById(this MicroDustHeroComponent heroComponent, string id)
        {
            //Log.Debug($"Hero: get hero config: {heroComponent.ToJson()}");
            var hero = heroComponent.Heros.FirstOrDefault(h => h.Id == id);

            return hero == null ? null : MicroDustHeroConfigCategory.Instance.Get(hero.ConfigId);
        }

        public static MicroDustHero GetHeroById(this MicroDustHeroComponent heroComponent, string id)
        {
            return heroComponent.Heros.FirstOrDefault(h => h.Id == id);
        }
    }
}
