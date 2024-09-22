using System.Linq;

namespace ET.Server
{
    [FriendOfAttribute(typeof(ET.MicroDustMajorCityComponent))]
    public static class MicroDustMajorCityHelper
    {
        public static async ETTask LoadData(MicroDustPlayerComponent player)
        {
            var db = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(1);
            var majorCity = (await db.Query<MicroDustMajorCityComponent>(p => p.UserId == player.UserId, MicroDustCollections.MajorCity))
                .FirstOrDefault();
            if (majorCity == null)
            {
                await InitializeMajorCity(player);
                return;
            }
            Log.Debug($"MajorCity, load data from db. {majorCity.ToJson()}");
            player.RemoveComponent<MicroDustArmyComponent>();
            player.AddComponent(majorCity);
        }

        private static async ETTask InitializeMajorCity(MicroDustPlayerComponent player)
        {
            Log.Debug("MajorCity, InitializeMajorCity");
            var majorCity = player.AddComponent<MicroDustMajorCityComponent>();
            majorCity.UserId = player.UserId;
            majorCity.MajorCityInfo.X = RandomGenerator.RandomNumber(-70, 70);
            majorCity.MajorCityInfo.Y = RandomGenerator.RandomNumber(-70, 70);
            majorCity.MajorCityInfo.Level = 0;

            var db = player.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(1);
            await db.Save(majorCity, MicroDustCollections.MajorCity);

            Log.Debug($"MajorCity, initialize major city: {majorCity.ToJson()}");
        }
    }
}
