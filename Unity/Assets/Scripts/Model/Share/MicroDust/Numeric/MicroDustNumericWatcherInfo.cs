namespace ET
{
    public class MicroDustNumericWatcherInfo
    {
        public SceneType SceneType { get; }
        public IMicroDustNumericWatcher INumericWatcher { get; }

        public MicroDustNumericWatcherInfo(SceneType sceneType, IMicroDustNumericWatcher numericWatcher)
        {
            this.SceneType = sceneType;
            this.INumericWatcher = numericWatcher;
        }
    }
}
