namespace ET.Server
{
    [MessageLocationHandler(SceneType.MicroDustMap)]
    [FriendOfAttribute(typeof(MicroDustArmyComponent))]
    [FriendOfAttribute(typeof(ET.MicroDustArmy))]
    public class C2M_MicroDust_ConfigureArmyHandler : MessageLocationHandler<MicroDustLocationComponent, C2M_MicroDust_ConfigureArmy, M2C_MicroDust_ConfigureArmy>
    {
        protected override async ETTask Run(MicroDustLocationComponent unit, C2M_MicroDust_ConfigureArmy request, M2C_MicroDust_ConfigureArmy response)
        {
            //Log.Warning($"Army: configure army request: {request.ToJson()}");
            if (request.Army < 0 || request.Army >= MicroDustArmyComponent.MaxAvailableArmies)
            {
                response.Error = 30001;
                return;
            }
            if (request.Position < 0 || request.Position >= MicroDustArmy.MaxHeros)
            {
                response.Error = 30002;
                return;
            }
            var player = unit.Parent as MicroDustPlayerComponent;
            var root = player.Root();
            var army = player.GetComponent<MicroDustArmyComponent>();
            //Log.Warning($"army is null: {army == null}");
            if (army == null)
            {
                army = player.AddComponent<MicroDustArmyComponent>();
            }
            //if (army.Armies.Count == 0)
            //{
            //    player.RemoveComponent<MicroDustArmyComponent>();
            //    army = player.AddComponent<MicroDustArmyComponent>();
            //}
            if (army.IsHeroInUse(request.HeroId))
            {
                response.Error = 30003;
                return;
            }
            //Log.Warning($"Army: {army.ToJson()}");
            army.userId = player.UserId;
            //army.Armies[request.Army].HeroIds[request.Position] = request.HeroId;
            //army.Armies[0].HeroIds[0] = request.HeroId;
            var armyRef = army.GetArmyByIndex(request.Army);
            armyRef.HeroIds[request.Position] = request.HeroId;

            await MicroDustArmyHelper.SaveData(player);
            MicroDustArmyHelper.SendArmyInfoToClient(player);
        }
    }
}
