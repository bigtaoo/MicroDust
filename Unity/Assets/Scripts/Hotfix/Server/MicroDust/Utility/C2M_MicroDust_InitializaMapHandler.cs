using System.Linq;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2M_MicroDust_InitializaMapHandler : MessageSessionHandler<C2G_MicroDustInitializeMap_Request, G2C_MicroDustInitializeMap_Response>
    {
        protected override async ETTask Run(Session session, C2G_MicroDustInitializeMap_Request request, G2C_MicroDustInitializeMap_Response response)
        {
            var db = DBFactory.GetDBComponent(session, session.Zone());
            foreach (var tile in request.MapTiles)
            {
                var t = (await db.Query<MicroDustTileInfo>(d => d.PosX == tile.PosX && d.PosY == tile.PosY, MicroDustCollections.BaseTileMap))
                    .FirstOrDefault();
                t ??= new MicroDustTileInfo
                    {
                        PosX = tile.PosX,
                        PosY = tile.PosY,
                        TileType = tile.TileType,
                    };
                t.ForceIdInit();
                await db.Save(t, MicroDustCollections.BaseTileMap);
            }
        }
    }
}
