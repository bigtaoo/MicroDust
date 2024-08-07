namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class MicroDustRecruitResultCreate : AEvent<Scene, MicroDustRecruitResult>
    {
        protected override async ETTask Run(Scene scene, MicroDustRecruitResult a)
        {
            await UIHelper.Remove(scene, UIType.MicroDustRecruitResult);
            await UIHelper.Create(scene, UIType.MicroDustRecruitResult, UILayer.Mid);
        }
    }
}
