namespace ET
{
    public static class MicroDustResource
    {
        public static void UpdateResource(MicroDustNumericComponent numericComponent, long times)
        {
            if (numericComponent == null)
            {
                return;
            }

            Update(MicroDustNumericTypes.FoodCurrent, MicroDustNumericTypes.FoodProduce, MicroDustNumericTypes.FoodMax, numericComponent, times);
            Update(MicroDustNumericTypes.WoodCurrent, MicroDustNumericTypes.WoodProduce, MicroDustNumericTypes.WoodMax, numericComponent, times);
            Update(MicroDustNumericTypes.IronCurrent, MicroDustNumericTypes.IronProduce, MicroDustNumericTypes.IronMax, numericComponent, times);
            Update(MicroDustNumericTypes.StoneCurrent, MicroDustNumericTypes.StoneProduce, MicroDustNumericTypes.StoneMax, numericComponent, times);
        }

        private static void Update(MicroDustNumericTypes current, MicroDustNumericTypes produce, MicroDustNumericTypes max,
            MicroDustNumericComponent numericComponent, long times)
        {
            var temp = numericComponent.NumericDic[current] + numericComponent.NumericDic[produce] * times;
            if (temp < numericComponent.NumericDic[max])
            {
                numericComponent.NumericDic[current] = temp;
            }
            else if (temp > numericComponent.NumericDic[max] && numericComponent.NumericDic[current] < numericComponent.NumericDic[max])
            {
                numericComponent.NumericDic[current] = numericComponent.NumericDic[max];
            }
        }
    }
}
