namespace ET
{
    [Message]
    public class MicroDust_A2NetClient_Message : MessageObject, IMessage
    {
        public static MicroDust_A2NetClient_Message Create()
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDust_A2NetClient_Message)) as MicroDust_A2NetClient_Message;
        }

        public override void Dispose()
        {
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }

        public IMessage MessageObject;
    }

    [Message]
    [ResponseType(nameof(A2NetClient_MicroDust_Response))]
    public class A2NetClient_MicroDust_Request : MessageObject, IRequest
    {
        public static A2NetClient_MicroDust_Request Create()
        {
            return ObjectPool.Instance.Fetch(typeof(A2NetClient_MicroDust_Request)) as A2NetClient_MicroDust_Request;
        }

        public override void Dispose()
        {
            this.RpcId = default;
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }

        public int RpcId { get; set; }
        public IRequest MessageObject;
    }

    [Message]
    public class A2NetClient_MicroDust_Response : MessageObject, IResponse
    {
        public static A2NetClient_MicroDust_Response Create()
        {
            return ObjectPool.Instance.Fetch(typeof(A2NetClient_MicroDust_Response)) as A2NetClient_MicroDust_Response;
        }

        public override void Dispose()
        {
            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.MessageObject = default;
            ObjectPool.Instance.Recycle(this);
        }

        public int RpcId { get; set; }
        public int Error { get; set; }
        public string Message { get; set; }

        public IResponse MessageObject;
    }

    [Message]
    public class NetClient2Main_MicroDust_SessionDispose : MessageObject, IMessage
    {
        public static NetClient2Main_MicroDust_SessionDispose Create()
        {
            return ObjectPool.Instance.Fetch(typeof(NetClient2Main_MicroDust_SessionDispose)) as NetClient2Main_MicroDust_SessionDispose;
        }

        public override void Dispose()
        {
            ObjectPool.Instance.Recycle(this);
        }

        public int Error { get; set; }
    }
}
