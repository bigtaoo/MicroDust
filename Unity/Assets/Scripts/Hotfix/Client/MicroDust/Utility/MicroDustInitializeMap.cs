using System;

namespace ET.Client
{
    [FriendOfAttribute(typeof(ET.MicroDustTileInfo))]
    public static class MicroDustInitializeMap
    {
        public static async ETTask SendMapTiles(Scene root, ListComponent<MicroDustTileInfo> tiles)
        {
            try
            {
                // Log.Debug($"tile: send request {tiles.ToJson()}");
                var request = C2G_MicroDustInitializeMap_Request.Create();
                foreach (var tile in tiles)
                {
                    var t = MicroDustMapTile.Create();

                    t.PosX = tile.PosX;
                    t.PosY = tile.PosY;
                    t.TileType = tile.TileType;

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
