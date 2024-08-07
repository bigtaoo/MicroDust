namespace ET.Server
{
    public class MicroDustServerMoveComponent : Entity, IAwake, IUpdate
    {
        public ListComponent<MicroDustServerMoveData> MoveData = new();
    }
}
