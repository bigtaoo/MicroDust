using System.Net;
using System;
using System.Net.Sockets;

namespace ET.Client
{
    [EntitySystemOf(typeof(MicroDustNetClientComponent))]
    [FriendOf(typeof(MicroDustNetClientComponent))]
    public static partial class MicroDustNetClientSystem
    {
        [EntitySystem]
        private static void Awake(this MicroDustNetClientComponent self, AddressFamily addressFamily, int ownerFiberId)
        {
            self.AService = new KService(addressFamily, ServiceType.Outer, self.Fiber().Log)
            {
                ReadCallback = self.OnRead,
                ErrorCallback = self.OnError
            };
            self.OwnerFiberId = ownerFiberId;
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

        private static void OnRead(this MicroDustNetClientComponent self, long channelId, ActorId actorId, object message)
        {
            Session session = self.GetChild<Session>(channelId);
            if (session == null)
            {
                return;
            }

            session.LastRecvTime = TimeInfo.Instance.ClientNow();

            switch (message)
            {
                case IResponse response:
                    {
                        session.OnResponse(response);
                        break;
                    }
                case ISessionMessage:
                    {
                        MessageSessionDispatcher.Instance.Handle(session, message);
                        break;
                    }
                case IMessage iActorMessage:
                    {
                        // 扔到Main纤程队列中
                        self.Root().GetComponent<MessageInnerSender>().Send(new ActorId(self.Fiber().Process, self.OwnerFiberId), iActorMessage);
                        break;
                    }
                default:
                    {
                        throw new Exception($"not found handler: {message}");
                    }
            }
        }

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
