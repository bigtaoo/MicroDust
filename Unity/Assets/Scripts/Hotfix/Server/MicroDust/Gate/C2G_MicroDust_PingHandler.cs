namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2G_MicroDust_PingHandler : MessageSessionHandler<C2G_MicroDust_Ping, G2C_MicroDust_Ping>
    {
        protected override async ETTask Run(Session session, C2G_MicroDust_Ping request, G2C_MicroDust_Ping response)
        {
            response.Time = TimeInfo.Instance.ServerNow();
            await ETTask.CompletedTask;
        }
    }
}
