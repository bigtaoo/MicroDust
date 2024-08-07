﻿namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class M2M_MicroDust_UnitTransferHandler : MessageHandler<Scene, M2M_MicroDust_UnitTransferRequest, M2M_MicroDust_UnitTransferResponse>
    {
        protected override async ETTask Run(Scene scene, M2M_MicroDust_UnitTransferRequest request, M2M_MicroDust_UnitTransferResponse response)
        {
            scene.RemoveComponent<MicroDustPlayerComponent>();
            var playerComponent = scene.AddComponent(MongoHelper.Deserialize<MicroDustPlayerComponent>(request.Unit)) as MicroDustPlayerComponent;

            foreach (byte[] bytes in request.Entitys)
            {
                var entity = MongoHelper.Deserialize<Entity>(bytes);
                //Log.Info($"Net, UnitTransfer, add unit component:{entity.ToJson()}");
                playerComponent.AddComponent(entity);
            }
            //Log.Debug($"Net, unit transfer location id: {unitComponent.GetComponent<MicroDustLocationComponent>().Id}");

            playerComponent.GetComponent<MicroDustLocationComponent>().AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.OrderedMessage);

            SendSceneChange(scene, playerComponent);
            SendGameInfo(playerComponent);
            await SendMajorCityInfo(playerComponent);
            await SendArmyInfo(playerComponent);

            // 加入aoi
            //unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);

            // 解锁location，可以接收发给Unit的消息
            var location = playerComponent.GetComponent<MicroDustLocationComponent>();
            await scene.Root().GetComponent<LocationProxyComponent>().UnLock(
                LocationType.Player, location.Id, request.OldActorId, location.GetActorId());
        }

        private static async ETTask SendArmyInfo(MicroDustPlayerComponent playerComponent)
        {
            await MicroDustArmyHelper.LoadData(playerComponent, playerComponent.UserId);
            MicroDustArmyHelper.SendArmyInfoToClient(playerComponent);
        }

        private static async ETTask SendMajorCityInfo(MicroDustPlayerComponent playerComponent)
        {
            await MicroDustMajorCityHelper.LoadData(playerComponent);
            var majorCityComponent = playerComponent.GetComponent<MicroDustMajorCityComponent>();
            M2C_MicroDust_MajorCity majorCity = new()
            {
                Position = new MicroDustPosition 
                {
                    X = majorCityComponent.MajorCityInfo.X,
                    Y = majorCityComponent.MajorCityInfo.Y,
                }
            };
            MicroDustMapMessageHelper.SendToClient(playerComponent, majorCity);
        }

        private static void SendGameInfo(MicroDustPlayerComponent playerComponent)
        {
            M2C_MicroDust_PlayerGameInfo playerGameInfo = new();
            var numericDataComponent = playerComponent.GetComponent<MicroDustNumericComponent>();
            foreach (var num in numericDataComponent.NumericDic)
            {
                //Log.Debug($"Game, server add numeric data type:{num.Key} value:{num.Value}");
                playerGameInfo.NumericDatas.Add(new MicroDustNumericData { Type = (int)num.Key, Value = num.Value });
            }
            MicroDustMapMessageHelper.SendToClient(playerComponent, playerGameInfo);
        }

        private static void SendSceneChange(Scene scene, MicroDustPlayerComponent playerComponent)
        {
            var m2CStartSceneChange = new M2C_MicroDust_StartSceneChange { SceneInstanceId = scene.InstanceId, SceneName = scene.Name };
            MicroDustMapMessageHelper.SendToClient(playerComponent, m2CStartSceneChange);
        }
    }
}
