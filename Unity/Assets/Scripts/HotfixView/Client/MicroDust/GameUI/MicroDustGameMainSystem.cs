using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustGameMainUIComponent))]
    [FriendOf(typeof(MicroDustGameMainUIComponent))]
    [FriendOfAttribute(typeof(MicroDustGameMainUIComponent))]
    public static partial class MicroDustGameMainSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustGameMainUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Chat = rc.Get<GameObject>("Chat");
            self.Recruit = rc.Get<GameObject>("Recruit");
            self.Mission = rc.Get<GameObject>("Mission");
            self.More = rc.Get<GameObject>("More");
            self.Politic = rc.Get<GameObject>("Politic");
            self.Skill = rc.Get<GameObject>("Skill");
            self.Hero = rc.Get<GameObject>("Hero");

            self.Recruit.GetComponent<Button>().onClick.AddListener(() => { self.OnRecruitClick().Coroutine(); });
            self.Hero.GetComponent<Button>().onClick.AddListener(() => { self.OnHerosClick().Coroutine(); });
            self.More.GetComponent<Button>().onClick.AddListener(() => { self.OnMoreClick().Coroutine();});
            self.Skill.GetComponent<Button>().onClick.AddListener(() => { self.OnSkillsClick().Coroutine(); });
        }

        private static async ETTask OnRecruitClick(this MicroDustGameMainUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustRecruit, UILayer.Mid);
        }

        private static async ETTask OnHerosClick(this MicroDustGameMainUIComponent self)
        {
            await MicroDustHerosHelper.GetHerosInfo(self.Root(), UIType.MicroDustHeros);
        }

        private static async ETTask OnMoreClick(this MicroDustGameMainUIComponent self)
        {
            if (UIHelper.GetUI(self.Root(), UIType.MicroDustMore) != null)
            {
                await UIHelper.Remove(self.Root(), UIType.MicroDustMore);
            }
            else
            {
                await UIHelper.Create(self.Root(), UIType.MicroDustMore, UILayer.Mid);
            }
        }

        private static async ETTask OnSkillsClick(this MicroDustGameMainUIComponent self)
        {
            await MicroDustSkillCommandHelper.GetSkillsInfo(self.Root(), UIType.MicroDustSkills);
        }
    }
}
