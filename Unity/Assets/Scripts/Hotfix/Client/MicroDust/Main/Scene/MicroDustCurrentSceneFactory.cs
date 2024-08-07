namespace ET.Client
{
    public static class MicroDustCurrentSceneFactory
    {
        public static Scene Create(long id, string name, MicroDustCurrentSceneComponent currentScenesComponent)
        {
            var currentScene = EntitySceneFactory.CreateScene(currentScenesComponent, id, 
                IdGenerater.Instance.GenerateInstanceId(), SceneType.MicroDustCurrent, name);
            currentScenesComponent.Scene = currentScene;

            EventSystem.Instance.Publish(currentScene, new MicroDustAfterCreateCurrentScene());
            return currentScene;
        }
    }
}
