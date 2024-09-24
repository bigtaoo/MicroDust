namespace ET.Server
{
    [Invoke((long)MailBoxType.MicroDustGateSession)]
    public class MicroDustMailBoxType_MicroDustGateSessionHandler : AInvokeHandler<MailBoxInvoker>
    {
        public override void Handle(MailBoxInvoker args)
        {
            var mailBoxComponent = args.MailBoxComponent;
            IMessage messageObject = args.MessageObject;

            //Log.Warning($"Microdust gate session handle, parent type: {mailBoxComponent.Parent.GetType()}");
            if (mailBoxComponent.Parent is MicroDustPlayerSessionComponent playerSessionComponent)
            {
                //Log.Warning($"Microdust gate session is null: {playerSessionComponent.Session == null}");
                playerSessionComponent.Session?.Send(messageObject);
            }
        }
    }
}
