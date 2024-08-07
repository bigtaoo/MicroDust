namespace ET.Server
{
    public class MicroDustServerMonsterComponent : Entity, IAwake
    {
        public int TilePositionX { get; set; }
        public int TilePositionY { get; set; }
        public int MonsterConfigId { get; set; }
        public string CreatedTime { get; set; }
    }
}
