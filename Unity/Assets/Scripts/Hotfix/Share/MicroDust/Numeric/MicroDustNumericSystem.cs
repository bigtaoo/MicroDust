namespace ET
{
    [FriendOf(typeof(MicroDustNumericComponent))]
    public static class MicroDustNumericSystem
    {
        public static long GetByKey(this MicroDustNumericComponent self, MicroDustNumericTypes key)
        {
            self.NumericDic.TryGetValue(key, out var value);
            return value;
        }

        public static void Set(this MicroDustNumericComponent self, MicroDustNumericTypes numericType, long value, bool isPublicEvent = true)
        {
            var oldValue = self.GetByKey(numericType);
            if (oldValue == value)
            {
                return;
            }

            self.NumericDic[numericType] = value;

            if (isPublicEvent)
            {
                EventSystem.Instance.Publish(self.Scene(), 
                    new MicroDustNumericChange() 
                    {
                        Unit = self.GetParent<MicroDustUnitInfoComponent>(), 
                        New = value,
                        Old = oldValue,
                        NumericType = numericType 
                    });
            }
        }
    }
}
