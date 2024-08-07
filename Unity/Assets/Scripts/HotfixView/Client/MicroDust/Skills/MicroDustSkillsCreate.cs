namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class MicroDustSkillsCreate : AEvent<Scene, MicroDustFetchSkillsFinished>
    {
        protected override async ETTask Run(Scene scene, MicroDustFetchSkillsFinished a)
        {
            await UIHelper.Remove(scene, a.uiType);
            await UIHelper.Create(scene, a.uiType, UILayer.Mid);
        }
    }
}
