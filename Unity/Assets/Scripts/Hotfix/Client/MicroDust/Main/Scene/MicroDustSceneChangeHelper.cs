namespace ET.Client
{
    public static partial class MicroDustSceneChangeHelper
    {
        public static async ETTask SceneChangeTo(Scene root, string sceneName, long sceneInstanceId)
        {
            Log.Debug($"Start scene change to {sceneName}");
            root.RemoveComponent<AIComponent>();

            var currentScenesComponent = root.GetComponent<MicroDustCurrentSceneComponent>();
            currentScenesComponent.Scene?.Dispose();
            Scene currentScene = MicroDustCurrentSceneFactory.Create(sceneInstanceId, sceneName, currentScenesComponent);
            var unitComponent = currentScene.AddComponent<MicroDustPlayerComponent>();

            EventSystem.Instance.Publish(root, new MicroDustSceneChangeStart());

            //Wait_CreateMyUnit waitCreateMyUnit = await root.GetComponent<ObjectWait>().Wait<Wait_CreateMyUnit>();
            //M2C_CreateMyUnit m2CCreateMyUnit = waitCreateMyUnit.Message;
            //Unit unit = UnitFactory.Create(currentScene, m2CCreateMyUnit.Unit);
            //unitComponent.Add(unit);
            //root.RemoveComponent<AIComponent>();

            EventSystem.Instance.Publish(currentScene, new MicroDustSceneChangeFinish());

            root.GetComponent<ObjectWait>().Notify(new MicroDust_Wait_SceneChangeFinish());
            await ETTask.CompletedTask;
        }
    }
}
