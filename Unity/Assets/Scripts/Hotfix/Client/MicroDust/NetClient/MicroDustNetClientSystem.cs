using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustNetClientComponent))]
    [FriendOf(typeof(MicroDustNetClientComponent))]
    public static partial class MicroDustNetClientSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustNetClientComponent self, IPEndPoint address, NetworkProtocol protocol)
        {
            self.AService = new KService(address, protocol, ServiceType.Outer);
            self.AService.AcceptCallback = self.OnAccept;
            self.AService.ReadCallback = self.OnRead;
            self.AService.ErrorCallback = self.OnError;
        }

        [EntitySystem]
        private static void Awake(this MicroDustNetClientComponent self, AddressFamily addressFamily, NetworkProtocol protocol)
        {
            self.AService = new KService(addressFamily, protocol, ServiceType.Outer);
            self.AService.ReadCallback = self.OnRead;
            self.AService.ErrorCallback = self.OnError;
        }

        [EntitySystem]
        private static void Destroy(this MicroDustNetClientComponent self)
        {
            self.AService.Dispose();
        }

        [EntitySystem]
        private static void Update(this MicroDustNetClientComponent self)
        {
            self.AService.Update();
        }

        // 这个channelId是由CreateAcceptChannelId生成的
        private static void OnAccept(this MicroDustNetClientComponent self, long channelId, IPEndPoint ipEndPoint)
        {
            Session session = self.AddChildWithId<Session, AService>(channelId, self.AService);
            session.RemoteAddress = ipEndPoint;

            if (self.IScene.SceneType != SceneType.BenchmarkServer)
            {
                // 挂上这个组件，5秒就会删除session，所以客户端验证完成要删除这个组件。该组件的作用就是防止外挂一直连接不发消息也不进行权限验证
                session.AddComponent<SessionAcceptTimeoutComponent>();
                // 客户端连接，2秒检查一次recv消息，10秒没有消息则断开
                session.AddComponent<SessionIdleCheckerComponent>();
            }
        }

        private static void OnRead(this MicroDustNetClientComponent self, long channelId, MemoryBuffer memoryBuffer)
        {
            Session session = self.GetChild<Session>(channelId);
            if (session == null)
            {
                return;
            }
            session.LastRecvTime = TimeInfo.Instance.ClientNow();

            (ActorId _, object message) = MessageSerializeHelper.ToMessage(self.AService, memoryBuffer);

            LogMsg.Instance.Debug(self.Fiber(), message);

            EventSystem.Instance.Invoke((long)self.IScene.SceneType, new NetComponentOnRead() { Session = session, Message = message });
        }

        //private static void OnRead(this MicroDustNetClientComponent self, long channelId, ActorId actorId, object message)
        //{
        //    Session session = self.GetChild<Session>(channelId);
        //    if (session == null)
        //    {
        //        return;
        //    }

        //    session.LastRecvTime = TimeInfo.Instance.ClientNow();

        //    switch (message)
        //    {
        //        case IResponse response:
        //            {
        //                session.OnResponse(response);
        //                break;
        //            }
        //        case ISessionMessage:
        //            {
        //                MessageSessionDispatcher.Instance.Handle(session, message);
        //                break;
        //            }
        //        case IMessage iActorMessage:
        //            {
        //                // 扔到Main纤程队列中
        //                self.Root().GetComponent<MessageInnerSender>().Send(new ActorId(self.Fiber().Process, self.OwnerFiberId), iActorMessage);
        //                break;
        //            }
        //        default:
        //            {
        //                throw new Exception($"not found handler: {message}");
        //            }
        //    }
        //}

        private static void OnError(this MicroDustNetClientComponent self, long channelId, int error)
        {
            Session session = self.GetChild<Session>(channelId);
            if (session == null)
            {
                return;
            }

            session.Error = error;
            session.Dispose();
        }

        public static Session Create(this MicroDustNetClientComponent self, IPEndPoint realIPEndPoint)
        {
            long channelId = NetServices.Instance.CreateConnectChannelId();
            Session session = self.AddChildWithId<Session, AService>(channelId, self.AService);
            session.RemoteAddress = realIPEndPoint;
            if (self.IScene.SceneType != SceneType.BenchmarkClient)
            {
                session.AddComponent<SessionIdleCheckerComponent>();
            }
            self.AService.Create(session.Id, realIPEndPoint);

            return session;
        }

        public static Session Create(
            this MicroDustNetClientComponent self,
            IPEndPoint routerIPEndPoint,
            IPEndPoint realIPEndPoint,
            uint localConn)
        {
            long channelId = localConn;
            Session session = self.AddChildWithId<Session, AService>(channelId, self.AService);
            session.RemoteAddress = realIPEndPoint;
            if (self.IScene.SceneType != SceneType.BenchmarkClient)
            {
                session.AddComponent<SessionIdleCheckerComponent>();
            }
            self.AService.Create(session.Id, routerIPEndPoint);
            return session;
        }
    }
}
