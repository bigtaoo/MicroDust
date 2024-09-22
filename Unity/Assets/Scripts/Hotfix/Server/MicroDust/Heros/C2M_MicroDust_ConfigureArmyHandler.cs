namespace ET.Server
{
    [MessageLocationHandler(SceneType.Map)]
    [FriendOfAttribute(typeof(ET.MicroDustArmyComponent))]
    public class C2M_MicroDust_ConfigureArmyHandler : MessageLocationHandler<MicroDustLocationComponent, C2M_MicroDust_ConfigureArmy, M2C_MicroDust_ConfigureArmy>
    {
        protected override async ETTask Run(MicroDustLocationComponent unit, C2M_MicroDust_ConfigureArmy request, M2C_MicroDust_ConfigureArmy response)
        {
            //Log.Debug($"Army: configure army request: {request.ToJson()}");
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
            if (army == null)
            {
                army = player.AddComponent<MicroDustArmyComponent>();
            }
            if (MicroDustHeroHelper.IsHeroInUse(request.HeroId, army))
            {
                response.Error = 30003;
                return;
            }
            //Log.Debug($"Army: {army.ToJson()}");
            army.userId = player.UserId;
            army.Armies[request.Army].HeroIds[request.Position] = request.HeroId;

            await MicroDustArmyHelper.SaveData(player);
            MicroDustArmyHelper.SendArmyInfoToClient(player);
        }
    }
}
