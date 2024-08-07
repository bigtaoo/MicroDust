namespace ET.Client
{
    [Event(SceneType.MicroDust)]
    public class MicroDustHerosUICreate : AEvent<Scene, MicroDustFetchHerosFinished>
    {
        protected override async ETTask Run(Scene scene, MicroDustFetchHerosFinished a)
        {
            await UIHelper.Remove(scene, a.uiType);
            await UIHelper.Create(scene, a.uiType, UILayer.Mid);
        }
    }
}
