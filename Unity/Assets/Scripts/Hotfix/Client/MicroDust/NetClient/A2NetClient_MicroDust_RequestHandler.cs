namespace ET.Client
{
    [MessageHandler(SceneType.MicroDustNetClient)]
    public class A2NetClient_MicroDust_RequestHandler : MessageHandler<Scene, A2NetClient_MicroDust_Request, A2NetClient_MicroDust_Response>
    {
        protected override async ETTask Run(Scene root, A2NetClient_MicroDust_Request request, A2NetClient_MicroDust_Response response)
        {
            //response.MessageObject = await root.GetComponent<MicroDustSessionComponent>().Session.Call(request.MessageObject);

            int rpcId = request.RpcId;
            IResponse res = await root.GetComponent<MicroDustSessionComponent>().Session.Call(request.MessageObject);
            res.RpcId = rpcId;
            response.MessageObject = res;
        }
    }
}
