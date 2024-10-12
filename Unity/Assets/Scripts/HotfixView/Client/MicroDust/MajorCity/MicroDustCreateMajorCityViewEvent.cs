using UnityEngine.Tilemaps;

namespace ET.Client
{
    [Event(SceneType.MicroDustCurrent)]
    [FriendOfAttribute(typeof(ET.Client.MicroDustTileMapComponent))]
    public class MicroDustCreateMajorCityViewEvent : AEvent<Scene, MicroDustMajorCityView>
    {
        protected override async ETTask Run(Scene scene, MicroDustMajorCityView a)
        {
            var map = scene.GetComponent<MicroDustTileMapComponent>();
            var rc = map.TileMapBuildings.GetComponent<ReferenceCollector>();
            var city1 = rc.Get<ResourceTile>("city1");
            var city2 = rc.Get<ResourceTile>("city2");
            var city3 = rc.Get<ResourceTile>("city3");
            var majorCity = scene.GetComponent<MicroDustPlayerComponent>().GetComponent<MicroDustMajorCityComponent>();
            DrawMajorCity(majorCity.MajorCityInfo, map.TileMapBuildings, city1, city2, city3);
            UpdateCameraPosition(scene, majorCity.MajorCityInfo, map.TileMapResources);
            await ETTask.CompletedTask;
        }

        private void DrawMajorCity(MicroDustCityInfo info, Tilemap buildingTile, ResourceTile city1, ResourceTile city2, ResourceTile city3)
        {
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X, info.Y), city3);

            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 1, info.Y - 1), city1);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 1, info.Y), city1);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 1, info.Y + 1), city1);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 1, info.Y), city1);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X, info.Y + 1), city1);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X, info.Y - 1), city1);

            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X, info.Y + 2), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 1, info.Y + 2), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 2, info.Y + 1), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 2, info.Y), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 2, info.Y - 1), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X - 1, info.Y - 2), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X, info.Y - 2), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 1, info.Y - 2), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 1, info.Y - 1), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 2, info.Y), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 1, info.Y + 1), city2);
            buildingTile.SetTile(new UnityEngine.Vector3Int(info.X + 1, info.Y + 2), city2);
        }

        private void UpdateCameraPosition(Scene scene, MicroDustCityInfo info, Tilemap resource)
        {
            var camera = scene.GetComponent<MicroDustCameraComponent>();
            if (camera == null)
            {
                Log.Warning("Can not find camera component");
            }
            var world = resource.CellToWorld(new UnityEngine.Vector3Int(info.X, info.Y));
            camera.SetPosition(world.x, world.y);
        }
    }
}
