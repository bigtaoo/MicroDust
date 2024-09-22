using System;

namespace ET.Server
{
    [FriendOf(typeof(MicroDustDatabaseManagerComponent))]
    public static partial class MicroDustDatabaseManagerSystem
    {
        public static MicroDustDatabaseComponent GetZoneDB(this MicroDustDatabaseManagerComponent self, int zone)
        {
            var dbComponent = self.GetChild<MicroDustDatabaseComponent>(zone);
            if (dbComponent != null)
            {
                return dbComponent;
            }

            var startZoneConfig = StartZoneConfigCategory.Instance.Get(zone);
            if (startZoneConfig.DBConnection == "")
            {
                throw new Exception($"zone: {zone} not found mongo connect string");
            }

            dbComponent = self.AddChildWithId<MicroDustDatabaseComponent, string, string>(zone, startZoneConfig.DBConnection, startZoneConfig.DBName);
            return dbComponent;
        }
    }
}