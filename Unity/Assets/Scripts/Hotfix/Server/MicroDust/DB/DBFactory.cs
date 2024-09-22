//namespace ET.Server
//{
//    public static class DBFactory
//    {
//        public static DBComponent GetDBComponent(Entity entity, int zone)
//        {
//            var dbManager = entity.GetComponent<DBManagerComponent>();
//            if (dbManager == null)
//            {
//                dbManager = entity.AddComponent<DBManagerComponent>();
//            }
//            return dbManager.GetZoneDB(zone);
//        }
//    }
//}
