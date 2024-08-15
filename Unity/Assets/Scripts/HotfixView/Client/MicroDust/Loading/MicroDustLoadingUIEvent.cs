using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustLoading)]
    public class MicroDustLoadinUIgEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/Heros/{UIType.MicroDustLoading}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustLoading, gameObject);
            ui.AddComponent<MicroDustLoadingUIComponent>();

            return ui;

            //await ETTask.CompletedTask;

            //ResourcesComponent resourcesComponent = uiComponent.Root().GetComponent<ResourcesComponent>();
            //await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(UIType.MicroDustLoading));
            //GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(UIType.MicroDustLoading), UIType.MicroDustLoading);
            //GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustLoading, gameObject);

            //ui.AddComponent<MicroDustLoadingUIComponent>();
            //return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
