namespace ET.Server
{
    [EntitySystemOf(typeof(MicroDustArmyComponent))]
    public static partial class MicroDustArmySystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustArmyComponent self)
        {
            self.AvailableArmies = MicroDustArmyComponent.MaxAvailableArmies;
            for (int i = 0; i < self.AvailableArmies; i++)
            {
                var army = new MicroDustArmy();
                for (int j = 0; j < MicroDustArmy.MaxHeros; j++)
                {
                    army.HeroIds.Add(string.Empty);
                }
                self.Armies.Add(army);
            }
        }
    }
}
