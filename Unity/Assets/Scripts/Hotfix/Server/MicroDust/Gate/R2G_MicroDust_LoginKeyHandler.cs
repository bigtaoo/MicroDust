namespace ET.Server
{
    [MessageHandler(SceneType.MicroDustGate)]
    public class R2G_MicroDust_LoginKeyHandler : MessageHandler<Scene, R2G_MicroDust_LoginKey, G2R_MicroDust_LoginKey>
    {
        protected override async ETTask Run(Scene scene, R2G_MicroDust_LoginKey request, G2R_MicroDust_LoginKey response)
        {
            long key = RandomGenerator.RandInt64();
            scene.GetComponent<MicroDustGateSessionKeyComponent>().Add(key, request.Account);
            response.Key = key;
            response.GateId = scene.Id;
            await ETTask.CompletedTask;
        }
    }
}
