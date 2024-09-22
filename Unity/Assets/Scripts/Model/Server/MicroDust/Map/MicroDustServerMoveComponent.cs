namespace ET.Server
{
    [ComponentOf(typeof(MicroDustPlayerComponent))]
    public class MicroDustServerMoveComponent : Entity, IAwake, IUpdate
    {
        public ListComponent<MicroDustServerMoveData> MoveData = new();
    }
}
