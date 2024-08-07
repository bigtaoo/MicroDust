namespace ET.Client
{
    public class MicroDustClientMoveViewComponent : Entity, IAwake, IUpdate
    {
        public string ArmyId;
        public UnityEngine.Vector3 StartPosition;
        public UnityEngine.Vector3 EndPosition;
        public UnityEngine.Vector3 Position;
        public float SpeedX;
        public float SpeedY;
        public long LastUpdateTime;
    }
}
