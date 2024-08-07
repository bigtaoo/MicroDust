namespace ET.Client
{
    public class MicroDustClientSelectedHeroComponent : Entity, IAwake
    {
        public MicroDustHero HeroInfo { get; set; }
        public MicroDustHeroConfig HeroConfig { get; set; }
    }
}
