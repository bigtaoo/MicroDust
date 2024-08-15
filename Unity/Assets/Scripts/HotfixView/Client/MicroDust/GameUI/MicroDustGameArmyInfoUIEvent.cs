using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustGameArmyInfo)]
    public class MicroDustGameArmyInfoUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/Game/{UIType.MicroDustGameArmyInfo}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustGameArmyInfo, gameObject);
            ui.AddComponent<MicroDustGameArmyInfoUIComponent>();

            return ui;
            //Fiber fiber = uiComponent.Fiber();
            //try
            //{
            //    var uiType = UIType.MicroDustGameArmyInfo;
            //    ResourcesComponent resourcesComponent = fiber.Root.GetComponent<ResourcesComponent>();
            //    await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));
            //    GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            //    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //    UI ui = uiComponent.AddChild<UI, string, GameObject>(uiType, gameObject);

            //    ui.AddComponent<MicroDustGameArmyInfoUIComponent>();
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
