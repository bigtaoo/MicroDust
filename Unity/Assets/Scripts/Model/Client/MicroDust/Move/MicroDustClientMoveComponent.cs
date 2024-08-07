namespace ET.Client
{
    public class MicroDustClientMoveComponent : Entity, IAwake, IUpdate
    {
        public ListComponent<MicroDustClientMoveData> MoveDatas { get; set; } = new();
    }
}
