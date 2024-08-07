namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2M_MicroDust_RecruitOnceHandler : MessageSessionHandler<C2M_MicroDust_RecruitOnce, M2C_MicroDust_RecruitOnce>
    {
        protected override async ETTask Run(Session session, C2M_MicroDust_RecruitOnce request, M2C_MicroDust_RecruitOnce response)
        {
            var player = session.GetComponent<MicroDustSessionPlayerComponent>().Player;
            response.HeroConfigId = MicroDustRecruitHelper.RecruitOnce(session, player.PlayerId);
            await ETTask.CompletedTask;
        }
    }
}
