using System;

namespace ET.Client
{
    public static class MicroDustConfigureArmyHelper
    {
        public static async ETTask ConfigureArmy(Scene root, int army, int position, string heroId)
        {
            try
            {
                var request = C2M_MicroDust_ConfigureArmy.Create();
                request.Army = army;
                request.HeroId = heroId;
                request.Position = position;
                
                var result = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    request) as M2C_MicroDust_ConfigureArmy;
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
