using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class MicroDust_SceneChangeStart_AddComponents : AEvent<Scene, MicroDustSceneChangeStart>
    {
        protected override async ETTask Run(Scene root, MicroDustSceneChangeStart args)
        {
            try
            {
                var currentScene = root.MicroDustCurrentScene();
                var resourcesLoaderComponent = currentScene.GetComponent<ResourcesLoaderComponent>();

                await resourcesLoaderComponent.LoadSceneAsync($"Assets/Bundles/Scenes/{currentScene.Name}.unity", LoadSceneMode.Single);

                //await resourcesComponent.LoadBundleAsync($"{currentScene.Name}.unity3d");
                //await SceneManager.LoadSceneAsync(currentScene.Name);

                currentScene.AddComponent<MicroDustCameraComponent>();
                currentScene.AddComponent<MicroDustTileMapComponent>();
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
