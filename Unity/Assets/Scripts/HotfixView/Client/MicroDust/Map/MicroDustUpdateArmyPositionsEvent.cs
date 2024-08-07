using Unity.Mathematics;

namespace ET.Client
{
    [Event(SceneType.MicroDustCurrent)]
    public class MicroDustUpdateArmyPositionsEvent : AEvent<Scene, MicroDustUpdateArmyPosition>
    {
        protected override async ETTask Run(Scene scene, MicroDustUpdateArmyPosition a)
        {
            var map = scene.GetComponent<MicroDustTileMapComponent>();
            var armyTile = MicroDustArmyTileHelper.GetArmyTile(scene, MicroDustArmyDisplayType.Fire);

            var worldPosCurrent = map.TileMapResources.CellToWorld(new UnityEngine.Vector3Int(a.currentX, a.currentY));
            var worldPosNext = map.TileMapResources.CellToWorld(new UnityEngine.Vector3Int(a.nextX, a.nextY));
            //map.Fire.transform.localPosition = new UnityEngine.Vector3(worldPos.x, worldPos.y, 0);

            Log.Debug($"move, current: {a.currentX} - {a.currentY}, next: {a.nextX} - {a.nextY}, time: {a.time}");

            var moveViewComponent = scene.GetComponent<MicroDustClientMoveViewComponent>();
            if (moveViewComponent == null)
            {
                moveViewComponent = scene.AddComponent<MicroDustClientMoveViewComponent>();
            }
            var detalX = worldPosNext.x - worldPosCurrent.x;
            var detalY = worldPosNext.y - worldPosCurrent.y;
            var distance = math.sqrt(detalX * detalX + detalY * detalY);
            var speed = distance / a.time;
            moveViewComponent.StartPosition = worldPosCurrent;
            moveViewComponent.EndPosition = worldPosNext;
            moveViewComponent.Position = worldPosCurrent;
            moveViewComponent.SpeedX = speed / distance * detalX;
            moveViewComponent.SpeedY = speed / distance * detalY;
            moveViewComponent.LastUpdateTime = TimeInfo.Instance.ClientNow();

            await ETTask.CompletedTask;
        }
    }
}
