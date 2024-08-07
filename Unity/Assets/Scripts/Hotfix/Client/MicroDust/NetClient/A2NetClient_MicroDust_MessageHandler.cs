namespace ET.Client
{
    [MessageHandler(SceneType.MicroDustNetClient)]
    public class A2NetClient_MicroDust_MessageHandler : MessageHandler<Scene, MicroDust_A2NetClient_Message>
    {
        protected override async ETTask Run(Scene root, MicroDust_A2NetClient_Message message)
        {
            root.GetComponent<MicroDustSessionComponent>().Session.Send(message.MessageObject);
            await ETTask.CompletedTask;
        }
    }
}
