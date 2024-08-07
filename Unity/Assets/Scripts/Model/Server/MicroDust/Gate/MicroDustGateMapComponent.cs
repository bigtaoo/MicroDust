namespace ET.Server
{
    [ComponentOf(typeof(MicroDustGatePlayerComponent))]
    public class MicroDustGateMapComponent : Entity, IAwake
    {
        private EntityRef<Scene> scene;

        public Scene Scene
        {
            get
            {
                return this.scene;
            }
            set
            {
                this.scene = value;
            }
        }
    }
}
