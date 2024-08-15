using ET;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustLogin)]
    public class MicroDustLoginUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/Heros/{UIType.MicroDustLogin}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustLogin, gameObject);
            ui.AddComponent<MicroDustLoginUIComponent>();

            return ui;

            //ResourcesComponent resourcesComponent = uiComponent.Root().GetComponent<ResourcesComponent>();
            //await resourcesComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(UIType.MicroDustLogin));

            //GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(UIType.MicroDustLogin), UIType.MicroDustLogin);
            //GameObject uiLayerGameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustLogin, uiLayerGameObject);
            //ui.AddComponent<MicroDustLoginUIComponent>();

            //return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
