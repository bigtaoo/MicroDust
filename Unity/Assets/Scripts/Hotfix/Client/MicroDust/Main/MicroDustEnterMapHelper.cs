using System;

namespace ET.Client
{
    public static partial class MicroDustEnterMapHelper
    {
        public static async ETTask EnterMapAsync(Scene root)
        {
            try
            {
                G2C_MicroDust_EnterMap g2CEnterMap = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                    new C2G_MicroDust_EnterMap()) as G2C_MicroDust_EnterMap;

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
