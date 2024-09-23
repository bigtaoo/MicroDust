using System;

namespace ET.Server
{
    [Invoke((long)SceneType.MicroDustMap)]
    public class MicroDustMapNetServerOnReadInvoke : AInvokeHandler<NetComponentOnRead>
    {
        public override void Handle(NetComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;
            // ???????????Actor??????????????,???????Chat Scene??????IChatMessage??
            switch (message)
            {
                case ISessionMessage:
                    {
                        MessageSessionDispatcher.Instance.Handle(session, message);
                        break;
                    }
                default:
                    {
                        throw new Exception($"not found handler: {message}");
                    }
            }
        }
    }
}