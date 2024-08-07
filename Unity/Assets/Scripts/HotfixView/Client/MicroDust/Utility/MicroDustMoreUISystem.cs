using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustMoreUIComponent))]
    [FriendOf(typeof(MicroDustMoreUIComponent))]
    [FriendOfAttribute(typeof(MicroDustMoreUIComponent))]
    public static partial class MicroDustMoreUISystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustMoreUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.InitializeMap = rc.Get<GameObject>("initializemap");
            self.InitializeMap.GetComponent<Button>().onClick.AddListener(() => { self.InitializeMap().Coroutine(); });

            self.InitializeMap.SetActive(false);
        }

        private static async ETTask InitializeMap(this MicroDustMoreUIComponent self)
        {
            await MicroDustInitializeMapHelper.ReportMapInfo(self.Root());
        }
    }
}
