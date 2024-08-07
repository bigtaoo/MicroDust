namespace ET
{
    public static partial class MicroDustCurrentSceneSystem
    {
        public static Scene MicroDustCurrentScene(this Scene root)
        {
            return root.GetComponent<MicroDustCurrentSceneComponent>()?.Scene;
        }
    }
}
