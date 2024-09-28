namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustConfigureArmyComponent : Entity, IAwake
    {
        public int SelectedArmy;
        public int SelectedHero;
    }
}
