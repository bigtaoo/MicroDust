﻿namespace ET
{
    [Invoke((long)SceneType.Main)]
    public class FiberInit_Main: AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
           
            //await EventSystem.Instance.PublishAsync(root, new EntryEvent1());
            //await EventSystem.Instance.PublishAsync(root, new EntryEvent2());
            //await EventSystem.Instance.PublishAsync(root, new EntryEvent3());

            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventShare());
            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventServer());
            await EventSystem.Instance.PublishAsync(root, new MicroDustEntryEventClient());
        }
    }
}