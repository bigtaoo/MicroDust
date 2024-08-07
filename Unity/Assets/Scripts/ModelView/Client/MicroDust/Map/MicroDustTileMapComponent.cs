using UnityEngine;
using UnityEngine.Tilemaps;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustTileMapComponent : Entity, IAwake
    {
        public Tilemap TileMapResources;
        public Tilemap TileMapBuildings;

        public GameObject Fire;
    }
}
