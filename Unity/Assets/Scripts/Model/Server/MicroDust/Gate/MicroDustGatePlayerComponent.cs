namespace ET.Server
{
    [ChildOf(typeof(MicroDustAllGatePlayersComponent))]
    public sealed class MicroDustGatePlayerComponent : Entity, IAwake<string>
    {
        public string Account { get; set; }
        public string PlayerId { get; set; }
    }
}
