namespace ET.Server
{
    public static partial class MicroDustTransferHelper
    {
        public static async ETTask TransferAtFrameFinish(MicroDustPlayerComponent unit, ActorId sceneInstanceId, string sceneName)
        {
            await unit.Fiber().WaitFrameFinish();

            await Transfer(unit, sceneInstanceId, sceneName);
        }

        private static async ETTask Transfer(MicroDustPlayerComponent unit, ActorId sceneInstanceId, string sceneName)
        {
            var root = unit.Root();
            var localtion = unit.GetComponent<MicroDustLocationComponent>();
            var localtionId = localtion.Id;
            //Log.Warning($"Net, transfer unit id:{localtionId}");

            var request = M2M_MicroDust_UnitTransferRequest.Create();
            request.OldActorId = localtion.GetActorId();
            request.Unit = unit.ToBson();
            foreach (Entity entity in unit.Components.Values)
            {
                if (entity is ITransfer)
                {
                    request.Entitys.Add(entity.ToBson());
                }
            }
            unit.Dispose();

            await root.GetComponent<LocationProxyComponent>().Lock(LocationType.Player, localtionId, request.OldActorId);
            await root.GetComponent<MessageSender>().Call(sceneInstanceId, request);
        }
    }
}
