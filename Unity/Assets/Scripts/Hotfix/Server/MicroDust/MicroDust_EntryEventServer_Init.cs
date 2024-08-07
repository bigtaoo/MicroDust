namespace ET.Server
{
    [Event(SceneType.MicroDustMain)]
    public class MicroDust_EntryEventServer_Init : AEvent<Scene, MicroDustEntryEventServer>
    {
        protected override async ETTask Run(Scene root, MicroDustEntryEventServer a)
        {
            switch (Options.Instance.AppType)
            {
                case AppType.Server:
                    {
                        var processScenes = StartSceneConfigCategory.Instance.GetByProcess(root.Fiber().Process);
                        foreach (StartSceneConfig startConfig in processScenes)
                        {
                            await FiberManager.Instance.Create(SchedulerType.ThreadPool, startConfig.Id, startConfig.Zone, startConfig.Type, startConfig.Name);
                        }
                        break;
                    }
                case AppType.Watcher:
                    {
                        root.AddComponent<WatcherComponent>();
                        break;
                    }
                case AppType.GameTool:
                    {
                        break;
                    }
            }

            if (Options.Instance.Console == 1)
            {
                root.AddComponent<ConsoleComponent>();
            }
        }
    }
}
