using MongoDB.Bson;
using System.Text;

namespace ET.Server
{
    public static class MicroDustBattle
    {
        public static async ETTask OnBattle(Session session, MicroDustBattleArmy army)
        {
            await ETTask.CompletedTask;
            var oldArmy = army;
            var record = new StringBuilder();
            record.AppendLine("Start Battle");

            var prepareRound = OnPrepareRound(army);
            record.AppendLine(prepareRound);

            for (int i = 1; i < 9; i++)
            {
                if (army.Heros[0].Soldiers <= 0 || army.Heros[3].Soldiers <= 0)
                {
                    break;
                }
                for (int j = 0; j < 6; j++)
                {
                    if (army.Heros[j].Soldiers > 0)
                    {
                        var target = GetAttackTarget(army, j);
                        var damage = MicroDustDamageFormula.GetDamage(new MicroDustBattleDamage
                        {
                            AttackerAgility = army.Heros[j].Attribute.Agility,
                            AttackerIntelligence = army.Heros[j].Attribute.Intelligence,
                            AttackerLevel = army.Heros[j].Level,
                            AttackerSoldiers = army.Heros[j].Soldiers,
                            AttackerSpeed = army.Heros[j].Attribute.Speed,
                            AttackerStrength = army.Heros[j].Attribute.Strength,
                            VictimAgility = army.Heros[target].Attribute.Agility,
                            VictimIntelligence = army.Heros[target].Attribute.Intelligence,
                            VictimLevel = army.Heros[target].Level,
                            VictimSoldiers = army.Heros[target].Soldiers,
                            VictimSpeed = army.Heros[target].Attribute.Speed,
                            VictimStrength = army.Heros[target].Attribute.Strength,
                        });
                        record.AppendLine($"Hero {j} attack {target} caused damage {damage}");
                    }
                }
            }
            var summary = GetBattleEndSummary(oldArmy, army);
        }

        private static string OnPrepareRound(MicroDustBattleArmy army)
        {
            var record = new StringBuilder();
            record.AppendLine("Prepare Round");

            return record.ToString();
        }

        private static string GetBattleEndSummary(MicroDustBattleArmy oldArmy, MicroDustBattleArmy army)
        {
            var summary = new StringBuilder();
            summary.AppendLine(army.ToJson());

            return summary.ToString();
        }

        private static int GetAttackTarget(MicroDustBattleArmy army, int attacker)
        {
            var candidates = new ListComponent<int>();
            if (attacker < 3)
            {
                for (int i = 3; i < 6; i++)
                {
                    if (army.Heros[i].Soldiers > 0)
                    {
                        candidates.Add(i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 3; i++)
                {
                    if (army.Heros[i].Soldiers > 0)
                    {
                        candidates.Add(i);
                    }
                }
            }

            var random = (int)RandomGenerator.RandUInt32() % candidates.Count;
            return candidates[random];
        }
    }
}
