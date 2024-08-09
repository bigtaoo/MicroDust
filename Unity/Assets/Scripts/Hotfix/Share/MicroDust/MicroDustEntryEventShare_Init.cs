namespace ET
{
    [Event(SceneType.MicroDustMain)]
    public class MicroDustEntryEventShare_Init : AEvent<Scene, MicroDustEntryEventShare>
    {
        protected override async ETTask Run(Scene root, MicroDustEntryEventShare a)
        {
            await World.Instance.AddSingleton<ConfigLoader>().LoadAsync();
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ObjectWait>();
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<ProcessInnerSender>();

            await ETTask.CompletedTask;
        }
    }
}
