using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustBattleInfoUIComponent))]
    [FriendOf(typeof(MicroDustBattleInfoUIComponent))]
    [FriendOfAttribute(typeof(MicroDustBattleInfoUIComponent))]
    public static partial class MicroDustBattleInfoUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustBattleInfoUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.Summary = rc.Get<GameObject>("summary");
            self.Details = rc.Get<GameObject>("details");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.Summary.GetComponent<Button>().onClick.AddListener(() => { self.OnSummaryClick().Coroutine(); });
            self.Details.GetComponent<Button>().onClick.AddListener(() => { self.OnDetailsClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustBattleInfoUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustBattleInfo);
        }

        private static async ETTask OnSummaryClick(this MicroDustBattleInfoUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBattleSummary, UILayer.Mid);
        }

        private static async ETTask OnDetailsClick(this MicroDustBattleInfoUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBattleDetails, UILayer.Mid);
        }
    }
}
