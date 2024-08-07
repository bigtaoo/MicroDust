namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class AppStartInitFinish_Create_MicroDustLogin : AEvent<Scene, MicroDustAppStartFinished>
    {
        protected override async ETTask Run(Scene scene, MicroDustAppStartFinished a)
        {
            await UIHelper.Create(scene, UIType.MicroDustLogin, UILayer.Mid);
        }
    }
}
