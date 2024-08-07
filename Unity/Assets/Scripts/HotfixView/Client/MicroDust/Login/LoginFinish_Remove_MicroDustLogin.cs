namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class LoginFinish_Remove_MicroDustLogin : AEvent<Scene, MicroDustLoginFinished>
    {
        protected override async ETTask Run(Scene scene, MicroDustLoginFinished a)
        {
            await UIHelper.Remove(scene, UIType.MicroDustLogin);
        }
    }
}
