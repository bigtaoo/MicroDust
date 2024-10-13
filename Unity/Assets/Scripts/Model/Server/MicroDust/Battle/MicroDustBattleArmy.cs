namespace ET.Server
{
    public struct MicroDustBattleArmy
    {
        public MicroDustBattleArmy(MicroDustBattleHero[] heros)
        {
            Heros = heros;
        }

        public MicroDustBattleHero[] Heros { get; set; }
    }
}
