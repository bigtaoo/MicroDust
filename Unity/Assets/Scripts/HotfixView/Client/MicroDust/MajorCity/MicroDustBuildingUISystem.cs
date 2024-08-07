using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustBuildingUIComponent))]
    [FriendOf(typeof(MicroDustBuildingUIComponent))]
    [FriendOfAttribute(typeof(MicroDustBuildingUIComponent))]
    public static partial class MicroDustBuildingUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustBuildingUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.Back = rc.Get<GameObject>("back");

            self.Back.GetComponent<Button>().onClick.AddListener(() => { self.OnBackClick().Coroutine(); });
        }

        private static async ETTask OnBackClick(this MicroDustBuildingUIComponent self)
        {
            await UIHelper.Remove(self.Root(), UIType.MicroDustBuilding);
        }
    }
}
