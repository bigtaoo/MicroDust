namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
	public class C2G_MicroDust_EnterMapHandler : MessageSessionHandler<C2G_MicroDust_EnterMap, G2C_MicroDust_EnterMap>
	{
		protected override async ETTask Run(Session session, C2G_MicroDust_EnterMap request, G2C_MicroDust_EnterMap response)
		{
			var player = session.GetComponent<MicroDustSessionPlayerComponent>().Player;
			Log.Debug($"Net, enter map playerId:{player.Id}");

			var gateMapComponent = player.AddComponent<MicroDustGateMapComponent>();
			gateMapComponent.Scene = await MicroDustGateMapFactory.Create(
				gateMapComponent, player.Id, IdGenerater.Instance.GenerateInstanceId(), "GateMap");

			var scene = gateMapComponent.Scene;
			var dbComponent = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(session.Zone());
			var unit = (await dbComponent.QueryWithComponents<MicroDustPlayerComponent>(
				scene, u => u.PlayerId == player.PlayerId, MicroDustCollections.UserInfo));
			if (unit == null)
			{
                unit = MicroDustUnitFactory.Create(scene, UnitType.Player);
				unit.UserId = player.PlayerId;
				await dbComponent.SaveWithComponents(unit, MicroDustCollections.UserInfo);
            }
			await MicroDustResourceHelper.UpdateResource(unit, dbComponent);

			unit.AddComponentWithId<MicroDustLocationComponent>(player.Id);
			Log.Debug($"Net, location component id: {unit.GetComponent<MicroDustLocationComponent>().Id}");
			
			var startSceneConfig = StartSceneConfigCategory.Instance.GetBySceneName(session.Zone(), "Game");
			response.SelfId = player.PlayerId;

			MicroDustTransferHelper.TransferAtFrameFinish(unit, startSceneConfig.ActorId, startSceneConfig.Name).Coroutine();
		}
	}
}