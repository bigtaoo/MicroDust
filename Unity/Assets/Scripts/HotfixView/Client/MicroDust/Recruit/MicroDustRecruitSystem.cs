using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(MicroDustRecruitUIComponent))]
    [FriendOf(typeof(MicroDustRecruitUIComponent))]
    [FriendOfAttribute(typeof(MicroDustRecruitUIComponent))]
    public static partial class MicroDustRecruitSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustRecruitUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Five = rc.Get<GameObject>("five");
            self.Once = rc.Get<GameObject>("once");
            self.NormalPack = rc.Get<GameObject>("normalpack");
            self.GoodPack = rc.Get<GameObject>("goodpack");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Once.GetComponent<Button>().onClick.AddListener(() => { self.RecruitOnce().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustRecruitUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustRecruit);
        }

        private static async ETTask RecruitOnce(this MicroDustRecruitUIComponent self)
        {
            await MicroDustRecruitHelper.RecruitOnce(self.Root(), 1);
        }
    }
}