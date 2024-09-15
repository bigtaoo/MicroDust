namespace ET
{
    [Invoke((long)SceneType.MicroDustMain)]
    public class MicroDustFiberInit_Main : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;

            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventShare());
            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventServer());
            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventClient());
        }
    }
}
