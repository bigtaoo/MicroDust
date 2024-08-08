using MongoDB.Bson;
using System;

namespace ET.Server
{
    [Event(SceneType.MicroDustGate | SceneType.MicroDustRealm)]
    public class MicroDustNetServerOnReadEvent : AInvokeHandler<NetComponentOnRead>
    {
        public override void Handle(NetComponentOnRead args)
        {
            HandleAsync(args).Coroutine();
        }

        private async ETTask HandleAsync(NetComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;
            Scene root = args.Session.Root();
            // 根据消息接口判断是不是Actor消息，不同的接口做不同的处理,比如需要转发给Chat Scene，可以做一个IChatMessage接口
            switch (message)
            {
                case ISessionMessage:
                    {
                        MessageSessionDispatcher.Instance.Handle(session, message);
                        break;
                    }
                case FrameMessage frameMessage:
                    {
                        Player player = session.GetComponent<SessionPlayerComponent>().Player;
                        ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                        frameMessage.PlayerId = player.Id;
                        root.GetComponent<MessageSender>().Send(roomActorId, frameMessage);
                        break;
                    }
                case IRoomMessage actorRoom:
                    {
                        Player player = session.GetComponent<SessionPlayerComponent>().Player;
                        ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
                        actorRoom.PlayerId = player.Id;
                        root.GetComponent<MessageSender>().Send(roomActorId, actorRoom);
                        break;
                    }
                case ILocationMessage actorLocationMessage:
                    {
                        long unitId = session.GetComponent<SessionPlayerComponent>().Player.Id;
                        root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, actorLocationMessage);
                        break;
                    }
                case ILocationRequest actorLocationRequest: // gate session收到actor rpc消息，先向actor 发送rpc请求，再将请求结果返回客户端
                    {
                        long unitId = session.GetComponent<SessionPlayerComponent>().Player.Id;
                        int rpcId = actorLocationRequest.RpcId; // 这里要保存客户端的rpcId
                        long instanceId = session.InstanceId;
                        IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Call(unitId, actorLocationRequest);
                        iResponse.RpcId = rpcId;
                        // session可能已经断开了，所以这里需要判断
                        if (session.InstanceId == instanceId)
                        {
                            session.Send(iResponse);
                        }
                        break;
                    }
                case IRequest actorRequest:  // 分发IActorRequest消息，目前没有用到，需要的自己添加
                    {
                        break;
                    }
                case IMessage actorMessage:  // 分发IActorMessage消息，目前没有用到，需要的自己添加
                    {
                        break;
                    }

                default:
                    {
                        throw new Exception($"not found handler: {message}");
                    }
            }
        }

        //protected override async ETTask Run(Scene scene, NetServerComponentOnRead args)
        //{
        //    Session session = args.Session;
        //    object message = args.Message;
        //    Scene root = scene.Root();

        //    if (message is IResponse response)
        //    {
        //        session.OnResponse(response);
        //        return;
        //    }

        //    switch (message)
        //    {
        //        case ISessionMessage:
        //            {
        //                MessageSessionDispatcher.Instance.Handle(session, message);
        //                break;
        //            }
        //        case FrameMessage frameMessage:
        //            {
        //                Player player = session.GetComponent<SessionPlayerComponent>().Player;
        //                ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
        //                frameMessage.PlayerId = player.Id;
        //                root.GetComponent<MessageSender>().Send(roomActorId, frameMessage);
        //                break;
        //            }
        //        case IRoomMessage actorRoom:
        //            {
        //                Player player = session.GetComponent<SessionPlayerComponent>().Player;
        //                ActorId roomActorId = player.GetComponent<PlayerRoomComponent>().RoomActorId;
        //                actorRoom.PlayerId = player.Id;
        //                root.GetComponent<MessageSender>().Send(roomActorId, actorRoom);
        //                break;
        //            }
        //        case ILocationMessage actorLocationMessage:
        //            {
        //                long unitId = session.GetComponent<SessionPlayerComponent>().Player.Id;
        //                root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.Unit).Send(unitId, actorLocationMessage);
        //                break;
        //            }
        //        case ILocationRequest actorLocationRequest:
        //            {
        //                long unitId = session.GetComponent<MicroDustSessionPlayerComponent>().Player.Id;
        //                //Log.Debug($"Actor: unit id: {unitId}");
        //                int rpcId = actorLocationRequest.RpcId;
        //                long instanceId = session.InstanceId;
        //                var a = root.GetComponent<MessageLocationSenderComponent>();
        //                var y = a.Get(LocationType.Player);
        //                //Log.Debug($"Actor: player: {y.ToJson()}, child: {y.ChildrenCount()}");
        //                IResponse iResponse = await y.Call(unitId, actorLocationRequest);
        //                //IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Call(unitId, actorLocationRequest);
        //                iResponse.RpcId = rpcId;
        //                if (session.InstanceId == instanceId)
        //                {
        //                    session.Send(iResponse);
        //                }
        //                break;
        //            }
        //        case IRequest actorRequest:
        //            {
        //                break;
        //            }
        //        case IMessage actorMessage:
        //            {
        //                break;
        //            }

        //        default:
        //            {
        //                throw new Exception($"not found handler: {message}");
        //            }
        //    }
        //}
    }
}
