namespace ET.Client
{
    [ChildOf(typeof(NetComponent))]
    public class MicroDustRouterConnector : Entity, IAwake, IDestroy
    {
        public byte Flag { get; set; }
    }
}