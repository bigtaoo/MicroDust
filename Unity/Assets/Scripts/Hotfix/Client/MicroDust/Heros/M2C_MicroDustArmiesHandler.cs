namespace ET.Client
{
    [MessageHandler(SceneType.MicroDust)]
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public class M2C_MicroDustArmiesHandler : MessageHandler<Scene, M2C_MicroDustArmies>
    {
        protected override async ETTask Run(Scene entity, M2C_MicroDustArmies message)
        {
            Log.Debug($"Army: {message.ToJson()}");

            entity.RemoveComponent<MicroDustArmyComponent>();
            var army = entity.GetComponent<MicroDustPlayerComponent>().AddComponent<MicroDustArmyComponent>();
            for (int i = 0; i < message.Arimes.Count; i++)
            {
                var a = message.Arimes[i];
                for (int j = 0; j < a.HeroIds.Count; j++)
                {
                    var armyRef = army.GetArmyByIndex(j);
                    armyRef.HeroIds[j] = a.HeroIds[j];
                }
            }

            await ETTask.CompletedTask;
        }
    }
}
