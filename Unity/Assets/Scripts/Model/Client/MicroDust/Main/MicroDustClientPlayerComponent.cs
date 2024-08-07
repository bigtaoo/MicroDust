namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustClientPlayerComponent : Entity, IAwake
    {
        public long MyId { get; set; }
        public string UserId { get; set; }
    }
}
