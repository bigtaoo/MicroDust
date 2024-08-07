namespace ET.Client
{
    [Event(SceneType.MicroDustMain)]
    public class MicroDustEntryEventClient_Init : AEvent<Scene, MicroDustEntryEventClient>
    {
        protected override async ETTask Run(Scene root, MicroDustEntryEventClient a)
        {
            var globalComponent = root.AddComponent<GlobalComponent>();
            root.AddComponent<UIGlobalComponent>();
            root.AddComponent<UIComponent>();
            root.AddComponent<ResourcesComponent>();
            root.AddComponent<ResourcesLoaderComponent>();
            root.AddComponent<MicroDustClientPlayerComponent>();
            root.AddComponent<MicroDustCurrentSceneComponent>();

            // await resourcesComponent.LoadBundleAsync("unit.unity3d");

            var sceneType = EnumHelper.FromString<SceneType>(globalComponent.GlobalConfig.AppType.ToString());
            root.SceneType = sceneType;

            await EventSystem.Instance.PublishAsync(root, new MicroDustAppStartFinished());
        }
    }
}
