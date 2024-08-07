using Unity.Mathematics;
using UnityEngine;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustCameraComponent))]
    [FriendOf(typeof(MicroDustCameraComponent))]
    public static partial class MicroDustCameraSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustCameraComponent self)
        {
            self.Camera = Camera.main;
            self.Camera.transform.SetPositionAndRotation(new Vector3(0, 0, -6), Quaternion.Euler(new Vector3(0, 0, 0)));
        }

        [EntitySystem]
        private static void LateUpdate(this MicroDustCameraComponent self)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
                {
                    return;
                }
                UIHelper.RemoveRelatedUIs(self.Root()).Coroutine();
                self.IsMouseLeftButtonDown = true;
                self.LastMousePosition = Input.mousePosition;
                self.MouseDownPosition = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (self.IsMouseLeftButtonDown)
                {
                    const int ClickDelta = 10;
                    if (math.abs(Input.mousePosition.x - self.MouseDownPosition.x) < ClickDelta &&
                        math.abs(Input.mousePosition.y - self.MouseDownPosition.y) < ClickDelta)
                    {
                        self.ClickMap().Coroutine();
                    }
                }

                self.IsMouseLeftButtonDown = false;
            }

            if (self.IsMouseLeftButtonDown)
            {
                self.DragMap();
            }
        }

        private static void DragMap(this MicroDustCameraComponent self)
        {
            const float scale = -0.01f;
            var mousePosition = Input.mousePosition;
            var deltaX = mousePosition.x - self.LastMousePosition.x;
            var deltaY = mousePosition.y - self.LastMousePosition.y;

            self.Transform.position += new Vector3(deltaX * scale, deltaY * scale, 0);
            self.LastMousePosition = mousePosition;
        }

        private static async ETTask ClickMap(this MicroDustCameraComponent self)
        {
            if (!self.IsClickOnBuilding())
            {
                var tileMapResources = self.Parent.GetComponent<MicroDustTileMapComponent>().TileMapResources;
                var worldPoint = self.Camera.ScreenToWorldPoint(Input.mousePosition);
                var tpos = tileMapResources.WorldToCell(worldPoint);
                tpos.z = 0;
                var tile = tileMapResources.GetTile(tpos) as ResourceTile;
                //Debug.Log($"TileMap, name:{tile.name}, type:{tile.type}, x:{tpos.x}, y:{tpos.y}");

                MicroDustSelectedMapTileHelper.OnTileMapSelected(self.Root(), tile.type.ToString(), tpos.x, tpos.y);
                await UIHelper.Create(self.Root(), UIType.MicroDustTileCommand, UILayer.Mid);
                //Log.Debug($"TileMap, mouse position: {Input.mousePosition.ToString()}");
                //tileCommandUI.GameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            }
        }

        private static bool IsClickOnBuilding(this MicroDustCameraComponent self)
        {
            var tileMapResources = self.Parent.GetComponent<MicroDustTileMapComponent>().TileMapBuildings;
            var worldPoint = self.Camera.ScreenToWorldPoint(Input.mousePosition);
            var tpos = tileMapResources.WorldToCell(worldPoint);
            tpos.z = 0;
            var tile = tileMapResources.GetTile(tpos) as ResourceTile;
            if (tile != null)
            {
                Debug.Log($"TileMap, name:{tile.name}, type:{tile.type}, x:{tpos.x}, y:{tpos.y}");
                if (tile.type == TileType.MajorCity)
                {
                    if (self.Root().GetComponent<MicroDustHeroComponent>() == null)
                    {
                        MicroDustHerosHelper.GetHerosInfo(self.Root(), UIType.MicroDustMajorCity).Coroutine();
                    }
                    else
                    {
                        UIHelper.Remove(self.Root(), UIType.MicroDustMajorCity).Coroutine();
                        UIHelper.Create(self.Root(), UIType.MicroDustMajorCity, UILayer.Mid).Coroutine();
                    }
                }
                return true;
            }
            return false;
        }
    }
}
