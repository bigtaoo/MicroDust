namespace ET.Client
{
    [Event(SceneType.MicroDustCurrent)]
    public class MicroDust_AfterCurrentScene_AddComponents : AEvent<Scene, MicroDustAfterCreateCurrentScene>
    {
        protected override async ETTask Run(Scene scene, MicroDustAfterCreateCurrentScene a)
        {
            scene.AddComponent<UIComponent>();
            scene.AddComponent<ResourcesLoaderComponent>();
            await ETTask.CompletedTask;
        }
    }
}
