using MongoDB.Bson;
using System;

namespace ET.Server
{
    [Event(SceneType.MicroDustGate | SceneType.MicroDustRealm)]
    public class MicroDustNetServerOnReadEvent : AEvent<Scene, NetServerComponentOnRead>
    {
        protected override async ETTask Run(Scene scene, NetServerComponentOnRead args)
        {
            Session session = args.Session;
            object message = args.Message;
            Scene root = scene.Root();

            if (message is IResponse response)
            {
                session.OnResponse(response);
                return;
            }

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
                case ILocationRequest actorLocationRequest:
                    {
                        long unitId = session.GetComponent<MicroDustSessionPlayerComponent>().Player.Id;
                        //Log.Debug($"Actor: unit id: {unitId}");
                        int rpcId = actorLocationRequest.RpcId;
                        long instanceId = session.InstanceId;
                        var a = root.GetComponent<MessageLocationSenderComponent>();
                        var y = a.Get(LocationType.Player);
                        //Log.Debug($"Actor: player: {y.ToJson()}, child: {y.ChildrenCount()}");
                        IResponse iResponse = await y.Call(unitId, actorLocationRequest);
                        //IResponse iResponse = await root.GetComponent<MessageLocationSenderComponent>().Get(LocationType.GateSession).Call(unitId, actorLocationRequest);
                        iResponse.RpcId = rpcId;
                        if (session.InstanceId == instanceId)
                        {
                            session.Send(iResponse);
                        }
                        break;
                    }
                case IRequest actorRequest:
                    {
                        break;
                    }
                case IMessage actorMessage:
                    {
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
