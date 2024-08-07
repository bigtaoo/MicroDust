namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustClientMoveComponent))]
    [FriendOf(typeof(MicroDustClientMoveComponent))]
    public static partial class MicroDustClientMoveSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustClientMoveComponent self)
        {

        }

        [EntitySystem]
        private static void Update(this MicroDustClientMoveComponent self)
        {
            for(var i = self.MoveDatas.Count - 1; i >= 0; --i)
            {
                var moveData = self.MoveDatas[i];
                if (moveData.MoveIndex >= moveData.Path.Count - 1)
                {
                    self.MoveDatas.Remove(moveData);
                    continue;
                }
                var clientTime = TimeInfo.Instance.ClientFrameTime();
                if (clientTime - moveData.LastUpdatedTime > moveData.Time)
                {
                    EventSystem.Instance.Publish(self.Root().MicroDustCurrentScene(),
                        new MicroDustUpdateArmyPosition
                        {
                            currentX = moveData.Path[moveData.MoveIndex].X,
                            currentY = moveData.Path[moveData.MoveIndex].Y,
                            nextX = moveData.Path[moveData.MoveIndex + 1].X,
                            nextY = moveData.Path[moveData.MoveIndex + 1].Y,
                            time = moveData.Time,
                        });
                    moveData.LastUpdatedTime = clientTime;
                    moveData.MoveIndex++;
                }
            }
        }
    }
}
