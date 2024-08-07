using MongoDB.Bson;
using System.Linq;

namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    public class C2M_MicroDust_ArmyCommandHandler : MessageLocationHandler<MicroDustLocationComponent, C2M_MicroDust_ArmyCommand, M2C_MicroDust_ArmyCommand>
    {
        protected override async ETTask Run(MicroDustLocationComponent unit, C2M_MicroDust_ArmyCommand request, M2C_MicroDust_ArmyCommand response)
        {
            const int time = 3 * 1000;
            var playerComponent = unit.Parent as MicroDustPlayerComponent;
            var moveComponent = playerComponent.GetComponent<MicroDustServerMoveComponent>();
            if (moveComponent == null)
            {
                moveComponent = playerComponent.AddComponent<MicroDustServerMoveComponent>();
            }
            var moveData = moveComponent.MoveData.FirstOrDefault(m => m.ArmyIndex == request.Army && m.UserId == playerComponent.UserId);
            if (moveData == null)
            {
                moveData = new MicroDustServerMoveData
                {
                    UserId = playerComponent.UserId,
                    ArmyIndex = request.Army,
                };
                moveComponent.MoveData.Add(moveData);
            }
            moveData.TargetPosition = request.Target;
            moveData.UpdateDeltaTime = time;
            moveData.LastUpdateTime = TimeInfo.Instance.ServerNow();
            moveData.ArmyType = MicroDustArmyDisplayType.Fire;

            var armyComponent = playerComponent.GetComponent<MicroDustArmyComponent>();
            var army = armyComponent.Armies[request.Army];

            var majorCity = playerComponent.GetComponent<MicroDustMajorCityComponent>();
            var start = new MicroDustPosition
            {
                X = majorCity.MajorCityInfo.X,
                Y = majorCity.MajorCityInfo.Y,
            };
            var path = MicroDustPathFinder.FindPath(start, request.Target);
            Log.Debug($"Path, result- {path.ToJson()}");
            moveData.Paths.Clear();
            moveData.Paths.AddRange(path);
            response.Path.AddRange(path);
            response.Time = time;

            await ETTask.CompletedTask;
        }
    }
}
