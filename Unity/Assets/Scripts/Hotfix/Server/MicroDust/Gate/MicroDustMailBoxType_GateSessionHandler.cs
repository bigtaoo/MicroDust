namespace ET.Server
{
    [Invoke((long)MailBoxType.MicroDustGateSession)]
    public class MicroDustMailBoxType_GateSessionHandler : AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            var mailBoxComponent = args.MailBoxComponent;
            IMessage messageObject = args.MessageObject;

            if (mailBoxComponent.Parent is MicroDustPlayerSessionComponent playerSessionComponent)
            {
                playerSessionComponent.Session?.Send(messageObject);
            }
        }
    }
}
