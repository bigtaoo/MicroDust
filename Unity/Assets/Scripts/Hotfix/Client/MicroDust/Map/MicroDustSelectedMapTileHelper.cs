namespace ET.Client
{
    public static class MicroDustSelectedMapTileHelper
    {
        public static void OnTileMapSelected(Scene root, string type, int posX, int posY)
        {
            var tileComponent = root.GetComponent<MicroDustSelectedMapTileComponent>();
            if (tileComponent == null)
            {
                tileComponent = root.AddComponent<MicroDustSelectedMapTileComponent>();
            }
            tileComponent.TileType = type;
            tileComponent.PosX = posX;
            tileComponent.PosY = posY;
        }
    }
}
