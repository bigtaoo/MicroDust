namespace ET.Client
{
    [ComponentOf(typeof(Session))]
    public class MicroDustPingComponent : Entity, IAwake, IDestroy
    {
        public long Ping { get; set; }
    }
}
