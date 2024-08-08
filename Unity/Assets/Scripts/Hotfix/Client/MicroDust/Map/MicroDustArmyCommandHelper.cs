using MongoDB.Bson;
using System;

namespace ET.Client
{
    public static class MicroDustArmyCommandHelper
    {
        public static async ETTask SendArmyCommand(Scene root, int army, int posX, int posY)
        {
            try
            {
                var request = new C2M_MicroDust_ArmyCommand
                {
                    Army = army,
                    Target = new MicroDustPosition
                    {
                        X = posX,
                        Y = posY
                    },
                };
                var response = await root.GetComponent<MicroDustClientSenderComponent>().Call(
                        request) as M2C_MicroDust_ArmyCommand;
                var armyComponent = root.GetComponent<MicroDustArmyComponent>();
                armyComponent.Armies[army].Path.Clear();
                foreach (var pos in response.Path)
                {
                    armyComponent.Armies[army].Path.Add(pos);
                }
                Log.Debug($"Move, add pos {armyComponent.Armies[army].Path.ToJson()}");

                AddMoveData(root, army, response.Time, armyComponent.Armies[army].Path);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }

        private static void AddMoveData(Scene scene, int armyIndex, int deltaTime, ListComponent<MicroDustPosition> path)
        {
            var moveComponent = scene.MicroDustCurrentScene().GetComponent<MicroDustClientMoveComponent>();
            if (moveComponent == null)
            {
                moveComponent = scene.MicroDustCurrentScene().AddComponent<MicroDustClientMoveComponent>();
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
    }
}
