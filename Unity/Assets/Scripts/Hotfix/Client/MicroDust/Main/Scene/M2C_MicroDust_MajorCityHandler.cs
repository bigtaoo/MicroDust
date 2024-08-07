namespace ET.Client
{
    [MessageHandler(SceneType.MicroDust)]
    public class M2C_MicroDust_MajorCityHandler : MessageHandler<Scene, M2C_MicroDust_MajorCity>
    {
        protected override async ETTask Run(Scene scene, M2C_MicroDust_MajorCity message)
        {
            var majorCityComponent = scene.MicroDustCurrentScene().AddComponent<MicroDustMajorCityComponent>();
            majorCityComponent.MajorCityInfo.X = message.Position.X;
            majorCityComponent.MajorCityInfo.Y = message.Position.Y;
            majorCityComponent.MajorCityInfo.Level = 1;
            await ETTask.CompletedTask;
        }
    }
}
