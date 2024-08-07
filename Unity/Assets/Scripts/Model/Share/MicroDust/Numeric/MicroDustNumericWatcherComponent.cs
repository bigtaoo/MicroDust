using System.Collections.Generic;
using System;

namespace ET
{
    [Code]
    public class MicroDustNumericWatcherComponent : Singleton<MicroDustNumericWatcherComponent>, ISingletonAwake
    {
        private readonly Dictionary<MicroDustNumericTypes, List<MicroDustNumericWatcherInfo>> allWatchers = new();

        public void Awake()
        {
            HashSet<Type> types = CodeTypes.Instance.GetTypes(typeof(MicroDustNumericWatcherAttribute));
            foreach (var type in types)
            {
                object[] attrs = type.GetCustomAttributes(typeof(MicroDustNumericWatcherAttribute), false);

                foreach (var attr in attrs)
                {
                    var numericWatcherAttribute = (MicroDustNumericWatcherAttribute)attr;
                    var obj = (IMicroDustNumericWatcher)Activator.CreateInstance(type);
                    MicroDustNumericWatcherInfo numericWatcherInfo = new(numericWatcherAttribute.SceneType, obj);
                    if (!allWatchers.ContainsKey(numericWatcherAttribute.NumericType))
                    {
                        allWatchers.Add(numericWatcherAttribute.NumericType, new List<MicroDustNumericWatcherInfo>());
                    }
                    allWatchers[numericWatcherAttribute.NumericType].Add(numericWatcherInfo);
                }
            }
        }

        public void Run(Unit unit, MicroDustNumericChange args)
        {
            if (!allWatchers.TryGetValue(args.NumericType, out List<MicroDustNumericWatcherInfo> list))
            {
                return;
            }

            SceneType unitDomainSceneType = unit.IScene.SceneType;
            foreach (var numericWatcher in list)
            {
                if (!numericWatcher.SceneType.HasSameFlag(unitDomainSceneType))
                {
                    continue;
                }
                numericWatcher.INumericWatcher.Run(unit, args);
            }
        }
    }
}
