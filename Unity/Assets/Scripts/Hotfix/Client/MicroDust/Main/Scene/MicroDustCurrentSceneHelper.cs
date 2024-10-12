namespace ET.Client
{
    public static partial class MicroDustCurrentSceneHelper
    {
        public static MicroDustPlayerComponent PlayerComponent(this Scene scene)
        {
            return scene.MicroDustCurrentScene().GetComponent<MicroDustPlayerComponent>();
        }
    }
}