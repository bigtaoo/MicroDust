using System.Net;

namespace ET.Server
{
    [Invoke((long)SceneType.MicroDustGate)]
    public class MicroDustFiberInit_Gate : AInvokeHandler<FiberInit, ETTask>
    {
        public override async ETTask Handle(FiberInit fiberInit)
        {
            Scene root = fiberInit.Fiber.Root;
            root.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
            root.AddComponent<TimerComponent>();
            root.AddComponent<CoroutineLockComponent>();
            root.AddComponent<ProcessInnerSender>();
            root.AddComponent<MessageSender>();
            root.AddComponent<LocationProxyComponent>();
            root.AddComponent<MessageLocationSenderComponent>();

            root.AddComponent<MicroDustGateSessionKeyComponent>();
            root.AddComponent<MicroDustAllGatePlayersComponent>();
            Log.Debug("FiberInit  Gate");

            StartSceneConfig startSceneConfig = StartSceneConfigCategory.Instance.Get((int)root.Id);
            root.AddComponent<NetComponent, IPEndPoint, NetworkProtocol>(startSceneConfig.InnerIPPort, NetworkProtocol.UDP);
            await ETTask.CompletedTask;
        }
    }
}
