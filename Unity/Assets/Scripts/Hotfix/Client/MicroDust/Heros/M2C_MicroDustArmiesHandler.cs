namespace ET.Client
{
    [MessageHandler(SceneType.MicroDust)]
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public class M2C_MicroDustArmiesHandler : MessageHandler<Scene, M2C_MicroDustArmies>
    {
        protected override async ETTask Run(Scene scene, M2C_MicroDustArmies message)
        {
            Log.Debug($"Army: {message.ToJson()}");

            scene.PlayerComponent().RemoveComponent<MicroDustArmyComponent>();
            var army = scene.PlayerComponent().AddComponent<MicroDustArmyComponent>();
            //Log.Warning($"army count: {army.Armies.Count}");
            for (int i = 0; i < message.Arimes.Count; i++)
            {
                var a = message.Arimes[i];
                for (int j = 0; j < a.HeroIds.Count; j++)
                {
                    army.Armies[i].HeroIds[j] = a.HeroIds[j];
                }
            }

            //Log.Warning($"army config: {army.ToJson()}");

            await ETTask.CompletedTask;
        }
    }
}
