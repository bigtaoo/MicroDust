using System;

namespace ET.Client
{
    public static partial class MicroDustEnterMapHelper
    {
        public static async ETTask EnterMapAsync(Scene root)
        {
            try
            {
                var request = C2G_MicroDust_EnterMap.Create();
                G2C_MicroDust_EnterMap g2CEnterMap = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    request) as G2C_MicroDust_EnterMap;

                //Log.Warning($"Enter map response: {g2CEnterMap.ToJson()}");
                // 等待场景切换完成
                await root.GetComponent<ObjectWait>().Wait<MicroDust_Wait_SceneChangeFinish>();

                EventSystem.Instance.Publish(root, new MicroDustEnterMapFinish());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
