namespace ET.Client
{
    [ComponentOf(typeof(MicroDustPlayerComponent))]
    public class MicroDustClientMoveComponent : Entity, IAwake, IUpdate
    {
        public ListComponent<MicroDustClientMoveData> MoveDatas { get; set; } = new();
    }
}
