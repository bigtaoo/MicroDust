using System;
using System.Linq;

namespace ET.Server
{
    public static class MicroDustSkillHelper
    {
        public static async ETTask<MicroDustSkill> GenerateSkill(Session session, string playerId, string heroId)
        {
            var db = DBFactory.GetDBComponent(session, session.Zone());
            var heros = (await db.Query<MicroDustHeroComponent>(h => h.PlayerId == playerId,
                MicroDustCollections.Heros)).FirstOrDefault();
            var hero = heros.Heros.FirstOrDefault(h => h.Id == heroId);
            if (hero == null)
            {
                return null;
            }
            var heroConfig = MicroDustHeroConfigCategory.Instance.Get(hero.ConfigId);
            var skillConfigId = heroConfig.GenerateSkillId;

            var skills = (await db.Query<MicroDustSkillComponent>(s => s.PlayerId == playerId,
                MicroDustCollections.Skills)).FirstOrDefault();
            if (skills == null)
            {
                skills = new MicroDustSkillComponent();
                skills.ForceIdInit();
            }

            if (skills.Skills.Any(s => s.ConfigId == skillConfigId))
            {
                return null;
            }

            var skill = new MicroDustSkill
            {
                SkillId = Guid.NewGuid().ToString(),
                ConfigId = skillConfigId,
                UsedByHeroId = string.Empty,
            };
            skills.Skills.Add(skill);
            skills.PlayerId = playerId;
            await db.Save(skills, MicroDustCollections.Skills);

            heros.Heros.Remove(hero);
            await db.Save(heros, MicroDustCollections.Heros);

            return skill;
        }
    }
}
