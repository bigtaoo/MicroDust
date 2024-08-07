using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustGameUserInfo)]
    public class MicroDustGameUserInfoUIEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            Fiber fiber = uiComponent.Fiber();
            try
            {
                ResourcesComponent resourcesComponent = fiber.Root.GetComponent<ResourcesComponent>();
                await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(UIType.MicroDustGameUserInfo));
                GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(UIType.MicroDustGameUserInfo), UIType.MicroDustGameUserInfo);
                GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
                UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustGameUserInfo, gameObject);

                ui.AddComponent<MicroDustGameUserInfoUIComponent>();
                return ui;
            }
            catch (Exception e)
            {
                fiber.Error(e);
                return null;
            }
        }

        public override void OnRemove(UIComponent uiComponent)
        {
        }
    }
}
