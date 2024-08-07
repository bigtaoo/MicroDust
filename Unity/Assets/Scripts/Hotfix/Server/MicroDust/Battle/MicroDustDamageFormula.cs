namespace ET.Server
{
    public static class MicroDustDamageFormula
    {
        public static int GetDamage(MicroDustBattleDamage damage)
        {
            return damage.AttackerStrength + damage.AttackerSoldiers / 10 - damage.VictimAgility;
        }
    }
}
