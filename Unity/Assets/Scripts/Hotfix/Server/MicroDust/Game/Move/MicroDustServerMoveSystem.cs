using System.Linq;

namespace ET.Server
{
    [EntitySystemOf(typeof(MicroDustServerMoveComponent))]
    [FriendOf(typeof(MicroDustServerMoveComponent))]
    public static partial class MicroDustServerMoveSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustServerMoveComponent self)
        {
            
        }

        [EntitySystem]
        private static void Update(this MicroDustServerMoveComponent self)
        {
            var time = TimeInfo.Instance.ServerNow();
            for (var i = self.MoveData.Count - 1; i >= 0; i--)
            {
                var moveData = self.MoveData[i];
                if (moveData.LastUpdateTime + moveData.UpdateDeltaTime < time)
                {
                    moveData.LastUpdateTime += moveData.UpdateDeltaTime;
                    if (moveData.Paths.Count > 1)
                    {
                        self.Move(moveData);
                    }
                    else
                    {
                        self.Arrive(moveData);
                    }    
                }
                if (!moveData.Paths.Any())
                {
                    Log.Debug("Path, movement finished.");
                    self.MoveData.RemoveAt(i);
                }
            }
            //self.MoveData.RemoveAll(item => !item.Paths.Any());
        }

        private static void Move(this MicroDustServerMoveComponent self, MicroDustServerMoveData moveData)
        {
            //var playerComponent = self.Parent as MicroDustPlayerComponent;
            //var moveMessage = new M2C_MicroDust_ArmyMove
            //{
            //    ArmyType = (int)moveData.ArmyType,
            //    Current = moveData.Paths[0],
            //    Encourage = 100,
            //    Next = moveData.Paths[1],
            //    Time = (int)moveData.UpdateDeltaTime,
            //    UserId = moveData.UserId,
            //    ArmyIndex = moveData.ArmyIndex,
            //};
            //MicroDustMapMessageHelper.SendToClient(playerComponent, moveMessage);

            Log.Debug($"Path, server update position from {moveData.Paths[0]}");
            moveData.Paths.RemoveAt(0);
        }

        private static void Arrive(this MicroDustServerMoveComponent self, MicroDustServerMoveData moveData)
        {
            Log.Debug($"Path, server update position arrive {moveData.Paths[0]}");
            moveData.Paths.RemoveAt(0);
        }
    }
}
