using System;

namespace ET.Client
{
    public static class MicroDustRecruitHelper
    {
        public static async ETTask RecruitOnce(Scene root, int packId)
        {
            try
            {
                var result = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    new C2M_MicroDust_RecruitOnce { PackId = packId }) as M2C_MicroDust_RecruitOnce;

                var history = root.GetComponent<MicroDustRecruitHistoryComponent>();
                if (history == null)
                {
                    history = root.AddComponent<MicroDustRecruitHistoryComponent>();
                }
                history.Recruits.Add(result.HeroConfigId);

                EventSystem.Instance.Publish(root, new MicroDustRecruitResult());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
