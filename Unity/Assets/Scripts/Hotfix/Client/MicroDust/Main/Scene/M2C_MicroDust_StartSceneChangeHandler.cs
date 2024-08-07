namespace ET.Client
{
    [MessageHandler(SceneType.MicroDust)]
    public class M2C_MicroDust_StartSceneChangeHandler : MessageHandler<Scene, M2C_MicroDust_StartSceneChange>
    {
        protected override async ETTask Run(Scene root, M2C_MicroDust_StartSceneChange message)
        {
            await MicroDustSceneChangeHelper.SceneChangeTo(root, message.SceneName, message.SceneInstanceId);
        }
    }
}
