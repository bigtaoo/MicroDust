using System;

namespace ET.Client
{
    public static class MicroDustInitializeMap
    {
        public static async ETTask SendMapTiles(Scene root, ListComponent<MicroDustTileInfo> tiles)
        {
            try
            {
                // Log.Debug($"tile: send request {tiles.ToJson()}");
                var request = new C2G_MicroDustInitializeMap_Request();
                foreach (var tile in tiles)
                {
                    var t = new MicroDustMapTile
                    {
                        PosX = tile.PosX,
                        PosY = tile.PosY,
                        TileType = tile.TileType,
                    };
                    request.MapTiles.Add(t);
                }

                await root.GetComponent<MicroDustClientSenderComponent>().Call(request);
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
    }
}
