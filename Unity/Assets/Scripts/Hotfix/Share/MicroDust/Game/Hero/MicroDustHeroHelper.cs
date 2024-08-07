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

        public static bool IsHeroInUse(string id, MicroDustArmyComponent armyComponent)
        {
            foreach (var army in armyComponent.Armies)
            {
                foreach (var hero in army.HeroIds)
                {
                    if (string.Equals(id, hero))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static MicroDustHero GetHeroById(this MicroDustHeroComponent heroComponent, string id)
        {
            return heroComponent.Heros.FirstOrDefault(h => h.Id == id);
        }
    }
}
