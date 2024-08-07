using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustGameUtilityUIComponent))]
    [FriendOf(typeof(MicroDustGameUtilityUIComponent))]
    [FriendOfAttribute(typeof(MicroDustGameUtilityUIComponent))]
    public static partial class MicroDustGameUtilityUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustGameUtilityUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Map = rc.Get<GameObject>("map");
            self.Battle = rc.Get<GameObject>("battle");
            self.Friend = rc.Get<GameObject>("friend");
            self.Mail = rc.Get<GameObject>("mail");

            self.Battle.GetComponent<Button>().onClick.AddListener(() => { self.OnBattleClick().Coroutine(); });
        }

        private static async ETTask OnBattleClick(this MicroDustGameUtilityUIComponent self)
        {
            await UIHelper.Create(self.Root(), UIType.MicroDustBattleList, UILayer.Mid);
        }
    }
}
