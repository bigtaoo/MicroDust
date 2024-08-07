namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustPlayerComponent : Entity, IAwake, IDestroy, ITransfer
    {
        public string UserId { get; set; }
    }
}
