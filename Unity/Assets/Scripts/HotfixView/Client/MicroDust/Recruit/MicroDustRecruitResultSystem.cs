using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustRecruitResultUIComponent))]
    [FriendOf(typeof(MicroDustRecruitResultUIComponent))]
    [FriendOfAttribute(typeof(MicroDustRecruitResultUIComponent))]
    public static partial class MicroDustRecruitResultSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustRecruitResultUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Five = rc.Get<GameObject>("five");
            self.Once = rc.Get<GameObject>("once");
            self.PanelOne = rc.Get<GameObject>("panelOne");
            self.PanelOne.SetActive(false);
            self.HeroOne = rc.Get<GameObject>("heroOne");

            var history = self.Root().GetComponent<MicroDustRecruitHistoryComponent>();
            if (history != null )
            {
                self.PanelOne.SetActive(true);
                self.HeroOne.GetComponent<TMPro.TextMeshProUGUI>().text = history.Recruits.LastOrDefault().ToString();
            }

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Once.GetComponent<Button>().onClick.AddListener(() => { self.RecruitOnce().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustRecruitResultUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustRecruitResult);
        }

        private static async ETTask RecruitOnce(this MicroDustRecruitResultUIComponent self)
        {
            await MicroDustRecruitHelper.RecruitOnce(self.Root(), 1);
        }
    }
}
