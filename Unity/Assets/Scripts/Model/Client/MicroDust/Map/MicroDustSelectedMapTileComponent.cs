namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustSelectedMapTileComponent : Entity, IAwake
    {
        public string TileType;
        public int PosX;
        public int PosY;
        public MicroDustArmyCommandType ArmyCommandType;
        public int ArmyIndex;
    }
}
