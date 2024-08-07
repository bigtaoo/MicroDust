namespace ET.Client
{
    [Event(SceneType.MicroDustCurrent)]
    public class MicroDust_SceneChangeFinish_CreateUI : AEvent<Scene, MicroDustSceneChangeFinish>
    {
        protected override async ETTask Run(Scene scene, MicroDustSceneChangeFinish a)
        {
            await UIHelper.Create(scene, UIType.MicroDustGameUserInfo, UILayer.Mid);
            await UIHelper.Create(scene, UIType.MicroDustGameInfo, UILayer.Mid);
            await UIHelper.Create(scene, UIType.MicroDustGameResource, UILayer.Mid);
            await UIHelper.Create(scene, UIType.MicroDustGameUtility, UILayer.Mid);
            await UIHelper.Create(scene, UIType.MicroDustGameMain, UILayer.Mid);
            await UIHelper.Create(scene, UIType.MicroDustGameArmyInfo, UILayer.Mid);
        }
    }
}
