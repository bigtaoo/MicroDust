using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustBattleSummaryUIComponent))]
    [FriendOf(typeof(MicroDustBattleSummaryUIComponent))]
    [FriendOfAttribute(typeof(MicroDustBattleSummaryUIComponent))]
    public static partial class MicroDustBattleSummaryUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustBattleSummaryUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustBattleSummaryUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustBattleSummary);
        }
    }
}
