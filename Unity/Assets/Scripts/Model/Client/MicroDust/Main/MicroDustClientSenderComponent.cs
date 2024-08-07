namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustClientSenderComponent : Entity, IAwake, IDestroy
    {
        public int fiberId;

        public ActorId netClientActorId;
    }
}
