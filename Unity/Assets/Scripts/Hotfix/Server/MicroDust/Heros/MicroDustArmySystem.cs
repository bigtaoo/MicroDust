namespace ET
{
    [EntitySystemOf(typeof(MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
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

        public static MicroDustArmy GetArmyByIndex(this MicroDustArmyComponent self, int index)
        {
            return self.Armies[index];
        }

        public static bool IsHeroInUse(this MicroDustArmyComponent self, string id)
        {
            for ( var i = 0; i < self.Armies.Count; ++i)
            {
                var army = self.GetArmyByIndex(i);
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
    }
}
