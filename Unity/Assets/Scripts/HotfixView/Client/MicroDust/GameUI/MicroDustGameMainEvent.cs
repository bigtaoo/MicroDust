﻿using System;
using UnityEngine;

namespace ET.Client
{
    [UIEvent(UIType.MicroDustGameMain)]
    public class MicroDustGameMainEvent : AUIEvent
    {
        public override async ETTask<UI> OnCreate(UIComponent uiComponent, UILayer uiLayer)
        {
            await ETTask.CompletedTask;
            string assetsName = $"Assets/Bundles/UI/MicroDust/Game/{UIType.MicroDustGameMain}.prefab";
            GameObject bundleGameObject = await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAssetAsync<GameObject>(assetsName);
            GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            UI ui = uiComponent.AddChild<UI, string, GameObject>(UIType.MicroDustGameMain, gameObject);
            ui.AddComponent<MicroDustGameMainUIComponent>();

            return ui;
            //Fiber fiber = uiComponent.Fiber();
            //try
            //{
            //    var uiType = UIType.MicroDustGameMain;
            //    ResourcesComponent resourcesComponent = fiber.Root.GetComponent<ResourcesComponent>();
            //    await uiComponent.Scene().GetComponent<ResourcesLoaderComponent>().LoadAsync(resourcesComponent.StringToAB(uiType));
            //    GameObject bundleGameObject = (GameObject)resourcesComponent.GetAsset(resourcesComponent.StringToAB(uiType), uiType);
            //    GameObject gameObject = UnityEngine.Object.Instantiate(bundleGameObject, uiComponent.UIGlobalComponent.GetLayer((int)uiLayer));
            //    UI ui = uiComponent.AddChild<UI, string, GameObject>(uiType, gameObject);

            //    ui.AddComponent<MicroDustGameMainUIComponent>();
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
