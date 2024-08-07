using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustBattleListUIComponent))]
    [FriendOf(typeof(MicroDustBattleListUIComponent))]
    [FriendOfAttribute(typeof(MicroDustBattleListUIComponent))]
    public static partial class MicroDustBattleListUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustBattleListUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");
            self.BattleInfo = rc.Get<GameObject>("battleinfo");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
            self.BattleInfo.GetComponent<Button>().onClick.AddListener(() => { self.OnBattleInfoClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustBattleListUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustBattleList);
        }

        private static async ETTask OnBattleInfoClick(this MicroDustBattleListUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBattleInfo, UILayer.Mid);
        }
    }
}
