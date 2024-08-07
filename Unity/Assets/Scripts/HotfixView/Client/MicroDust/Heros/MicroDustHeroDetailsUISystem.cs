using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustHeroDetailsUIComponent))]
    [FriendOf(typeof(MicroDustHeroDetailsUIComponent))]
    [FriendOfAttribute(typeof(MicroDustHeroDetailsUIComponent))]
    public static partial class MicroDustHeroDetailsUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustHeroDetailsUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Reset = rc.Get<GameObject>("reset");
            self.LevelUp = rc.Get<GameObject>("levelup");
            self.GenerateSkill = rc.Get<GameObject>("generateskill");
            self.Skill3 = rc.Get<GameObject>("skill3");
            self.Skill2 = rc.Get<GameObject>("skill2");
            self.Skill1 = rc.Get<GameObject>("skill1");
            self.AddPolitic = rc.Get<GameObject>("addPolitic");
            self.CurrentPolitic = rc.Get<GameObject>("currentPolitic");
            self.AddAgility = rc.Get<GameObject>("addAgility");
            self.CurrentAgility = rc.Get<GameObject>("currentAgility");
            self.AddIntelligence = rc.Get<GameObject>("addIntelligence");
            self.CurrentIntelligence = rc.Get<GameObject>("currentIntelligence");
            self.AddStrength = rc.Get<GameObject>("addStrength");
            self.CurrentStrength = rc.Get<GameObject>("currentStrength");
            self.Energevalue = rc.Get<GameObject>("energevalue");
            self.Levelvalue = rc.Get<GameObject>("levelvalue");
            self.Camp = rc.Get<GameObject>("camp");
            self.Power = rc.Get<GameObject>("power");
            for (int i = 0; i < 5; i++)
            {
                self.Stars[i] = rc.Get<GameObject>($"star{i+1}");
            }           
            self.Name = rc.Get<GameObject>("name");
            self.Hero = rc.Get<GameObject>("hero");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.GenerateSkill.GetComponent<Button>().onClick.AddListener(() => { self.OnGenerateSkillClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustHeroDetailsUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustHeroDetails);
        }

        private static async ETTask OnGenerateSkillClick(this MicroDustHeroDetailsUIComponent self)
        {
            var selectedHeroComponent = self.Root().GetComponent<MicroDustClientSelectedHeroComponent>();
            await MicroDustSkillCommandHelper.SendGenerateSkillCommand(self.Root(), selectedHeroComponent.HeroInfo.Id);
            await UIHelper.Remove(self.Root(), UIType.MicroDustHeros);
            await UIHelper.Remove(self.Root(), UIType.MicroDustHeroDetails);  
        }
    }
}
