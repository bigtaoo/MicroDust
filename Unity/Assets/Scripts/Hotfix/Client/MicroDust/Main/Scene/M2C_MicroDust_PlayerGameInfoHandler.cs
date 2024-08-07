namespace ET.Client
{
    [MessageHandler(SceneType.MicroDust)]
    public class M2C_MicroDust_PlayerGameInfoHandler : MessageHandler<Scene, M2C_MicroDust_PlayerGameInfo>
    {
        protected override async ETTask Run(Scene entity, M2C_MicroDust_PlayerGameInfo message)
        {
            var playerComponent = entity.GetComponent<MicroDustClientPlayerComponent>();
            var numericDataComponent = playerComponent.GetComponent<MicroDustNumericComponent>();
            numericDataComponent ??= playerComponent.AddComponent<MicroDustNumericComponent>();
            foreach (var num in message.NumericDatas)
            {
                numericDataComponent.NumericDic[(MicroDustNumericTypes)num.Type] = num.Value;
                //Log.Debug($"Game, add numeric data: type:{(MicroDustNumericTypes)num.Type}, value:{num.Value}");
            }

            await ETTask.CompletedTask;
        }
    }
}
