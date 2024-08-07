namespace ET.Client
{
    public class MicroDustClientMoveData
    {
        public string UserId { get; set; }
        public int ArmyIndex { get; set; }
        public ListComponent<MicroDustPosition> Path { get; set; }
        public int MoveIndex { get; set; }
        public int Time { get; set; } 
        public long LastUpdatedTime { get; set; }
    }
}
