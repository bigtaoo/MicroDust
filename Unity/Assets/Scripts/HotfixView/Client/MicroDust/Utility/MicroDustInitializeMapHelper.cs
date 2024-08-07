using UnityEngine;

namespace ET.Client
{
    public static class MicroDustInitializeMapHelper
    {
        private static ListComponent<MicroDustTileInfo> _tiles = new();

        public static async ETTask ReportMapInfo(Scene root)
        {
            _tiles.Clear();
            var tilemap = root.MicroDustCurrentScene().GetComponent<MicroDustTileMapComponent>().TileMapResources;
            var count = 0;
            for (var x = tilemap.cellBounds.min.x; x < tilemap.cellBounds.max.x; x++)
            {
                for (var y = tilemap.cellBounds.min.y; y < tilemap.cellBounds.max.y; y++)
                {
                    for (var z = tilemap.cellBounds.min.z; z < tilemap.cellBounds.max.z; z++)
                    {
                        var tile = tilemap.GetTile(new Vector3Int(x, y, z)) as ResourceTile;
                        if (tile == null)
                        {
                            continue;
                        }
                        _tiles.Add(new MicroDustTileInfo
                        {
                            PosX = x,
                            PosY = y,
                            TileType = tile.type.ToString(),
                        });
                        ++count;
                        if (count > 100)
                        {
                            await MicroDustInitializeMap.SendMapTiles(root, _tiles);
                            count = 0;
                            _tiles.Clear();
                        }
                        //Log.Debug($"Tile: x={x}, y={y}, type={tile.type}");
                    }
                }
            }
        }
    }
}
