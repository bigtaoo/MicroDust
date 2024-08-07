using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustTileMapComponent))]
    [FriendOf(typeof(MicroDustTileMapComponent))]
    public static partial class MicroDustTileMapSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustTileMapComponent self)
        {
            var scene = SceneManager.GetActiveScene().GetRootGameObjects();
            var grid = scene.First(s => s.name == "Grid");
            var tileMaps = grid.GetComponentsInChildren(typeof(Tilemap));

            foreach ( var tilemap in tileMaps )
            {
                Log.Debug($"TileMap, tile map name: {tilemap.name}");
                if (tilemap.name == "ground")
                {
                    self.TileMapResources = tilemap as Tilemap;
                }
                else if (tilemap.name == "building")
                {
                    self.TileMapBuildings = tilemap as Tilemap;
                }
            }

            self.Fire = grid.GetComponentInChildren<Animator>().gameObject;

            EventSystem.Instance.Publish(self.Root().MicroDustCurrentScene(), new MicroDustMajorCityView());
        }
    }
}
