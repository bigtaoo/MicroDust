namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustCurrentSceneComponent : Entity, IAwake
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
