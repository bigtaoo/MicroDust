using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustMajorCity)]
    public class MicroDustMajorCityUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/MajorCity/{UIType.MicroDustMajorCity}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustMajorCity, gameObject);
            ui.AddComponent<MicroDustMajorCityUIComponent>();

            //var uiType = UIType.MicroDustMajorCity;
            //var resourcesComponent = uiComponent.Root().GetComponent<ResourcesComponent>();
            //await resourcesComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));

            //var bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            //var uiLayerGameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //var ui = uiComponent.AddChild<UI, string, GameObject>(uiType, uiLayerGameObject);
            //ui.AddComponent<MicroDustMajorCityUIComponent>();

            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
