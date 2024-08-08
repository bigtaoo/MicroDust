using System;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustPingComponent))]
    public static partial class MicroDustPingSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustPingComponent self)
        {
            self.PingAsync().Coroutine();
        }

        [EntitySystem]
        private static void Destroy(this MicroDustPingComponent self)
        {
            self.Ping = default;
        }

        private static async ETTask PingAsync(this MicroDustPingComponent self)
        {
            Session session = self.GetParent<Session>();
            long instanceId = self.InstanceId;
            Fiber fiber = self.Fiber();

            while (true)
            {
                if (self.InstanceId != instanceId)
                {
                    return;
                }

                long time1 = TimeInfo.Instance.ClientNow();
                try
                {
                    var c2GPing = C2G_MicroDust_Ping.Create(true);
                    var response = await session.Call(c2GPing) as G2C_MicroDust_Ping;

                    if (self.InstanceId != instanceId)
                    {
                        return;
                    }

                    long time2 = TimeInfo.Instance.ClientNow();
                    self.Ping = time2 - time1;

                    TimeInfo.Instance.ServerMinusClientTime = response.Time + (time2 - time1) / 2 - time2;

                    await self.Root().GetComponent<TimerComponent>().WaitAsync(2000);
                }
                catch (RpcException e)
                {
                    Log.Info($"ping error: {self.Id} {e.Error}");
                    return;
                }
                catch (Exception e)
                {
                    Log.Error($"ping error: \n{e}");
                }
            }
        }
    }
}
