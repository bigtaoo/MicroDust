using System;

namespace ET.Server
{
    public static partial class MicroDustUnitFactory
    {
        public static MicroDustPlayerComponent Create(Scene scene, UnitType unitType)
        {
            var unitComponent = scene.GetComponent<MicroDustPlayerComponent>();
            switch (unitType)
            {
                case UnitType.Player:
                    {
                        var unit = unitComponent.AddComponent<MicroDustUnitInfoComponent>();
                        unit.UserName = "Tao";
                        var numericComponent = unitComponent.AddComponent<MicroDustNumericComponent>();
                        numericComponent.Set(MicroDustNumericTypes.FoodCurrent, 89898);
                        numericComponent.Set(MicroDustNumericTypes.FoodMax, 1000000);
                        numericComponent.Set(MicroDustNumericTypes.FoodProduce, 100);
                        numericComponent.Set(MicroDustNumericTypes.WoodCurrent, 78787);
                        numericComponent.Set(MicroDustNumericTypes.WoodMax, 1000000);
                        numericComponent.Set(MicroDustNumericTypes.WoodProduce, 100);
                        numericComponent.Set(MicroDustNumericTypes.IronCurrent, 100000);
                        numericComponent.Set(MicroDustNumericTypes.IronMax, 1000000);
                        numericComponent.Set(MicroDustNumericTypes.IronProduce, 100);
                        numericComponent.Set(MicroDustNumericTypes.StoneCurrent, 100000);
                        numericComponent.Set(MicroDustNumericTypes.StoneMax, 1000000);
                        numericComponent.Set(MicroDustNumericTypes.StoneProduce, 100);
                        numericComponent.Set(MicroDustNumericTypes.GoldCurrent, 10000);
                        numericComponent.Set(MicroDustNumericTypes.GoldProduce, 100);
                        numericComponent.Set(MicroDustNumericTypes.Diamond, 123);
                        numericComponent.Set(MicroDustNumericTypes.Spirit, 2000);
                        numericComponent.Set(MicroDustNumericTypes.Territory, 11);
                        numericComponent.Set(MicroDustNumericTypes.TerritoryMax, 50);
                        numericComponent.Set(MicroDustNumericTypes.Power, 30);
                        numericComponent.Set(MicroDustNumericTypes.PowerMax, 30);
                        numericComponent.Set(MicroDustNumericTypes.Reputation, 10);
                        numericComponent.Set(MicroDustNumericTypes.ReputationMax, 90);
                        numericComponent.ResourceUpdateTime = TimeInfo.Instance.ServerNow();

                        //unitComponent.Add(unit);
                        // 加入aoi
                        //unit.AddComponent<AOIEntity, int, float3>(9 * 1000, unit.Position);
                        return unitComponent;
                    }
                default:
                    throw new Exception($"not such unit type: {unitType}");
            }
        }
    }
}
