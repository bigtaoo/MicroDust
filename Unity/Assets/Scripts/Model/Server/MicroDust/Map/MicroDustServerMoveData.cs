namespace ET.Server
{
    public class MicroDustServerMoveData
    {
        public string UserId;
        public int ArmyIndex;
        public MicroDustPosition TargetPosition;
        public MicroDustPosition CurrentPosition;
        public ListComponent<MicroDustPosition> Paths = new();
        public long LastUpdateTime;
        public int UpdateDeltaTime;
        public MicroDustArmyDisplayType ArmyType;
    }
}
