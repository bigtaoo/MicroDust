using UnityEngine;
using UnityEngine.UI;

namespace ET.Client
{

    [EntitySystemOf(typeof(MicroDustLoadingUIComponent))]
    [FriendOf(typeof(MicroDustLoadingUIComponent))]
    [FriendOfAttribute(typeof(MicroDustLoadingUIComponent))]
    public static partial class MicroDustLoadingSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustLoadingUIComponent self)
        {
            ReferenceCollector rc = self.GetParent<UI>().GameObject.GetComponent<ReferenceCollector>();

            self.EnterMapButton = rc.Get<GameObject>("entermap");
            self.EnterMapButton.GetComponent<Button>().onClick.AddListener(() => { self.EnterMap().Coroutine(); });
        }

        public static async ETTask EnterMap(this MicroDustLoadingUIComponent self)
        {
            Scene root = self.Root();
            await MicroDustEnterMapHelper.EnterMapAsync(root);
            await UIHelper.Remove(root, UIType.MicroDustLoading);
        }
    }
}