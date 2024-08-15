using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustConfigureArmy)]
    public class MicroDustConfigureArmyUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/MajorCity/{UIType.MicroDustConfigureArmy}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustConfigureArmy, gameObject);
            ui.AddComponent<MicroDustConfigureArmyUIComponent>();

            //var uiType = UIType.MicroDustConfigureArmy;
            //var resourcesComponent = uiComponent.Root().GetComponent<ResourcesComponent>();
            //await resourcesComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));

            //var bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            //var uiLayerGameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //var ui = uiComponent.AddChild<UI, string, GameObject>(uiType, uiLayerGameObject);
            //ui.AddComponent<MicroDustConfigureArmyUIComponent>();

            return ui;
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
