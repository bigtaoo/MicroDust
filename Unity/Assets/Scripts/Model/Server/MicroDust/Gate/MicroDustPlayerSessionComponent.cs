namespace ET.Server
{
    [ComponentOf(typeof(MicroDustGatePlayerComponent))]
    public class MicroDustPlayerSessionComponent : Entity, IAwake
    {
        private EntityRef<Session> session;

        public Session Session
        {
            get
            {
                return this.session;
            }
            set
            {
                this.session = value;
            }
        }
    }
}
