using ET.Server;
using MongoDB.Bson;
using System;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public static class MicroDustArmyCommandHelper
    {
        public static async ETTask SendArmyCommand(Scene root, int army, int posX, int posY)
        {
            try
            {
                var request = C2M_MicroDust_ArmyCommand.Create();

                request.Army = army;
                request.Target = MicroDustPosition.Create();
                request.Target.X = posX;
                request.Target.Y = posY;

                var response = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                        request) as M2C_MicroDust_ArmyCommand;
                var armyComponent = GetMicroDustPlayerComponent(root).GetComponent<MicroDustArmyComponent>();
                var armyResult = armyComponent.GetArmyByIndex(army);
                armyResult.Path.Clear();
                foreach (var pos in response.Path)
                {
                    armyResult.Path.Add(pos);
                }
                Log.Debug($"Move, add pos {armyResult.Path.ToJson()}");

                AddMoveData(root, army, response.Time, armyResult.Path);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void AddMoveData(Scene scene, int armyIndex, int deltaTime, ListComponent<MicroDustPosition> path)
        {
            var moveComponent = GetMicroDustPlayerComponent(scene).GetComponent<MicroDustClientMoveComponent>();
            if (moveComponent == null)
            {
                moveComponent = GetMicroDustPlayerComponent(scene).AddComponent<MicroDustClientMoveComponent>();
            }
            var userComponent = scene.GetComponent<MicroDustClientPlayerComponent>();

            foreach (var d in moveComponent.MoveDatas)
            {
                if (d.ArmyIndex == armyIndex && d.UserId == userComponent.UserId)
                {
                    moveComponent.MoveDatas.Remove(d);
                    break;
                }
            }

            var moveData = new MicroDustClientMoveData
            {
                ArmyIndex = armyIndex,
                MoveIndex = 0,
                UserId = userComponent.UserId,
                Path = path,
                Time = deltaTime,
                LastUpdatedTime = 0,
            };
            moveComponent.MoveDatas.Add(moveData);
        }

        private static MicroDustPlayerComponent GetMicroDustPlayerComponent(Scene scene)
        {
            return scene.MicroDustCurrentScene().GetComponent<MicroDustPlayerComponent>();
        }
    }
}
