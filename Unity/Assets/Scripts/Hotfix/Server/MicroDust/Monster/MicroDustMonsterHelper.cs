using System.Linq;

namespace ET.Server
{
    public static class MicroDustMonsterHelper
    {
        public static async ETTask<int> GetMonsterConfigIdByTile(Session session, int tilePosX, int tilePosY)
        {
            var db = DBFactory.GetDBComponent(session, session.Zone());
            var monster = (await db.Query<MicroDustServerMonsterComponent>(
                m => m.TilePositionX == tilePosX && m.TilePositionY == tilePosY,
                MicroDustCollections.Monsters)).FirstOrDefault();
            var tileInfo = (await db.Query<MicroDustTileInfo>(
                t => t.PosX == tilePosX && t.PosY == tilePosY, MicroDustCollections.BaseTileMap)).FirstOrDefault();
            if (tileInfo == null)
            {
                return 0;
            }
            if (monster == null || !MicroDustTimeHelper.IsTheSameDayOfYear(monster.CreatedTime))
            {
                monster = new MicroDustServerMonsterComponent
                {
                    MonsterConfigId = GetRandomMonsterConfigId(tileInfo.Level),
                    TilePositionX = tilePosX,
                    TilePositionY = tilePosY,
                    CreatedTime = MicroDustTimeHelper.FormatUtcTimeNow(),
                };
                monster.ForceIdInit();
                await db.Save(monster);
            }
            return monster.MonsterConfigId;
        }

        private static int GetRandomMonsterConfigId(int tileLevel)
        {
            var allConfigs = MicroDustMonsterConfigCategory.Instance.GetAll().Values.ToList();
            var availableConfigs = allConfigs.Where(m => m.TileLevel == tileLevel).ToList();
            if (availableConfigs.Count == 0)
            {
                return 1001;
            }
            var index = (int)RandomGenerator.RandUInt32() % availableConfigs.Count;
            return availableConfigs[index].Id;
        }
    }
}
