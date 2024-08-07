namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2G_MicroDust_GenerateSkillHandler :
        MessageSessionHandler<C2G_MicroDustGenerateSkill_Request, G2C_MicroDustGenerateSkill_Response>
    {
        protected override async ETTask Run(Session session, 
            C2G_MicroDustGenerateSkill_Request request, G2C_MicroDustGenerateSkill_Response response)
        {
            var player = session.GetComponent<MicroDustSessionPlayerComponent>().Player;
            var skill = await MicroDustSkillHelper.GenerateSkill(session, player.PlayerId, request.HeroId);
            if (skill == null)
            {
                response.Error = 30001;
                return;
            }
            var generatedSkill = new MicroDustSkillInfo
            {
                SkillConfigId = skill.ConfigId,
                SkillId = skill.SkillId,
                UsedByHeroId = skill.UsedByHeroId,
            };
            response.GeneratedSkill = generatedSkill;
            response.HeroId = request.HeroId;
        }
    }
}
