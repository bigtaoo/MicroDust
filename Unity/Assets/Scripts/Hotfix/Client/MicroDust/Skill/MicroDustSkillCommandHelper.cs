using System;
using System.Linq;

namespace ET.Client
{
    public static class MicroDustSkillCommandHelper
    {
        public static async ETTask SendGenerateSkillCommand(Scene root, string heroId)
        {
            try
            {
                var request = new C2G_MicroDustGenerateSkill_Request
                {
                    HeroId = heroId,
                };
                var response = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                        request, false) as G2C_MicroDustGenerateSkill_Response;
                if (response.Error != 0)
                {
                    Log.Warning($"Generate skill failed. Error Code: {response.Error}");
                    return;
                }
                var heroComponent = root.GetComponent<MicroDustHeroComponent>();
                if (heroComponent != null)
                {
                    heroComponent.Heros.RemoveAll(h => h.Id == response.HeroId);
                }
                var skillComponent = root.GetComponent<MicroDustSkillComponent>();
                if (skillComponent != null)
                {
                    skillComponent.Skills.Add(new MicroDustSkill
                    {
                        ConfigId = response.GeneratedSkill.SkillConfigId,
                        SkillId = response.GeneratedSkill.SkillId,
                        UsedByHeroId = response.GeneratedSkill.UsedByHeroId,
                    });
                }
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        public static async ETTask GetSkillsInfo(Scene root, string uiType)
        {
            try
            {
                var result = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    new C2G_MicroDustSkills_Request()) as G2C_MicroDustSkills_Response;

                root.RemoveComponent<MicroDustSkillComponent>();
                var skills = root.AddComponent<MicroDustSkillComponent>();
                skills.Skills = result.Skills.Select(h => ToSkill(h)).ToList();

                EventSystem.Instance.Publish(root, new MicroDustFetchSkillsFinished() { uiType = uiType });
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static MicroDustSkill ToSkill(MicroDustSkillInfo skill)
        {
            return new MicroDustSkill
            {
                ConfigId = skill.SkillConfigId,
                SkillId = skill.SkillId,
                UsedByHeroId = skill.UsedByHeroId,
            };
        }
    }
}
