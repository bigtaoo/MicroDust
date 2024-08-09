using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustBuilding)]
    public class MicroDustBuildingUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/Demo/{UIType.UILobby}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //var uiType = UIType.MicroDustBuilding;
            //var resourcesComponent = uiComponent.Root().GetComponent<ResourcesLoaderComponent>();
            //await resourcesComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));

            //var bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            var uiLayerGameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //var ui = uiComponent.AddChild<UI, string, GameObject>(uiType, uiLayerGameObject);
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustBuilding, gameObject);
            ui.AddComponent<MicroDustBuildingUIComponent>();

            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
