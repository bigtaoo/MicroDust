using System;

namespace ET
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MicroDustNumericWatcherAttribute : Attribute
    {
        public SceneType SceneType { get; }

        public MicroDustNumericTypes NumericType { get; }

        public MicroDustNumericWatcherAttribute(SceneType sceneType, MicroDustNumericTypes type)
        {
            this.SceneType = sceneType;
            this.NumericType = type;
        }
    }
}
