using System.Collections.Generic;

namespace ET.Client
{
    public static class MicroDustArmyTileHelper
    {
        private static Dictionary<MicroDustArmyDisplayType, ResourceTile> ArmyTiles = new();

        public static ResourceTile GetArmyTile(Scene scene, MicroDustArmyDisplayType armyType)
        {
            if (ArmyTiles.ContainsKey(armyType))
            {
                return ArmyTiles[armyType];
            }

            var map = scene.GetComponent<MicroDustTileMapComponent>();
            var rc = map.TileMapBuildings.GetComponent<ReferenceCollector>();
            var fire = rc.Get<ResourceTile>("army_fire");
            ArmyTiles[armyType] = fire;
            return fire;
        }
    }
}
