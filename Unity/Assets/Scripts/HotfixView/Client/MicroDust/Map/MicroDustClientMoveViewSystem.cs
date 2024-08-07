using Unity.Mathematics;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustClientMoveViewComponent))]
    [FriendOf(typeof(MicroDustClientMoveViewComponent))]
    public static partial class MicroDustClientMoveViewSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustClientMoveViewComponent self)
        {

        }

        [EntitySystem]
        private static void Update(this MicroDustClientMoveViewComponent self)
        {
            if (math.abs(self.EndPosition.x - self.Position.x) < 0.01f && (self.EndPosition.y - self.Position.y) < 0.01f)
            {
                return;
            }
            var map = self.Root().MicroDustCurrentScene().GetComponent<MicroDustTileMapComponent>();
            var time = TimeInfo.Instance.ClientNow();
            var deltaTime = time - self.LastUpdateTime;
            self.LastUpdateTime = time;
            self.Position.x += self.SpeedX * deltaTime;
            self.Position.y += self.SpeedY * deltaTime;

            map.Fire.transform.localPosition = new UnityEngine.Vector3(self.Position.x, self.Position.y - 0.5f);
        }
    }
}
