using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustGameInfo)]
    public class MicroDustGameInfoEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/Game/{UIType.MicroDustGameInfo}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustGameInfo, gameObject);
            ui.AddComponent<MicroDustGameInfoUIComponent>();

            return ui;

            //Fiber fiber = uiComponent.Fiber();
            //try
            //{
            //    var uiType = UIType.MicroDustGameInfo;
            //    ResourcesComponent resourcesComponent = fiber.Root.GetComponent<ResourcesComponent>();
            //    await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));
            //    GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            //    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //    UI ui = uiComponent.AddChild<UI, string, GameObject>(uiType, gameObject);

            //    ui.AddComponent<MicroDustGameInfoUIComponent>();
            //    return ui;
            //}
            //catch (Exception e)
            //{
            //    fiber.Error(e);
            //    return null;
            //}
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
