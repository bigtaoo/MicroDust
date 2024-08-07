using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustBattleDetailsUIComponent))]
    [FriendOf(typeof(MicroDustBattleDetailsUIComponent))]
    [FriendOfAttribute(typeof(MicroDustBattleDetailsUIComponent))]
    public static partial class MicroDustBattleDetailsUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustBattleDetailsUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();
            self.Back = rc.Get<GameObject>("back");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustBattleDetailsUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustBattleDetails);
        }
    }
}
