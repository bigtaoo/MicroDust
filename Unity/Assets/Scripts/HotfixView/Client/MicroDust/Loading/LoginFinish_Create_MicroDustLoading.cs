namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class LoginFinish_Create_MicroDustLoading : AEvent<Scene, MicroDustLoginFinished>
    {
        protected override async ETTask Run(Scene scene, MicroDustLoginFinished a)
        {
            await UIHelper.Create(scene, UIType.MicroDustLoading, UILayer.Mid);
        }
    }
}
