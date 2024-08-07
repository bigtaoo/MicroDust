namespace ET.Server
{
    [ComponentOf(typeof(Session))]
    public class MicroDustSessionPlayerComponent : Entity, IAwake, IDestroy
    {
        private EntityRef<MicroDustGatePlayerComponent> player;

        public MicroDustGatePlayerComponent Player
        {
            get
            {
                return this.player;
            }
            set
            {
                this.player = value;
            }
        }
    }
}
