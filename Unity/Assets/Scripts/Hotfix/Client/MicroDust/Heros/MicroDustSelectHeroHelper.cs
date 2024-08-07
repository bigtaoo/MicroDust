namespace ET.Client
{
    public static class MicroDustSelectHeroHelper
    {
        public static void SelectHero(Scene scene, MicroDustHero hero)
        {
            var selectHeroComponent = scene.GetComponent<MicroDustClientSelectedHeroComponent>();
            if (selectHeroComponent ==  null )
            {
                selectHeroComponent = scene.AddComponent<MicroDustClientSelectedHeroComponent>();
            }

            selectHeroComponent.HeroInfo = hero;
            selectHeroComponent.HeroConfig = MicroDustHeroConfigCategory.Instance.Get(hero.ConfigId);
        }
    }
}
