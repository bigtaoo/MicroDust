using ET.Server;
using System;
using System.Linq;
using System.Numerics;

namespace ET.Assets.Scripts.Hotfix.Server.MicroDust.Gate
{
    [MessageSessionHandler(SceneType.MicroDustGate)]
    public class C2G_MicroDust_LoginGateHandler : MessageSessionHandler<C2G_MicroDust_LoginGate, G2C_MicroDust_LoginGate>
    {
        protected override async ETTask Run(Session session, C2G_MicroDust_LoginGate request, G2C_MicroDust_LoginGate response)
        {
            var root = session.Root();
            var account = root.GetComponent<MicroDustGateSessionKeyComponent>().Get(request.Key);
            if (account == null)
            {
                response.Error = ErrorCore.ERR_ConnectGateKeyError;
                response.Message = "Invalid Gate Key!";
                return;
            }

            session.RemoveComponent<SessionAcceptTimeoutComponent>();

            var playerComponent = root.GetComponent<MicroDustAllGatePlayersComponent>();
            var player = playerComponent.GetByAccount(account);
            Log.Debug($"Net, C2G_MicroDust_LoginGateHandler player: {player == null}");
            if (player == null)
            {
                player = playerComponent.AddChild<MicroDustGatePlayerComponent, string>(account);
                player.PlayerId = await GetPlayerId(session, account);
                Log.Debug($"Net, C2G_MicroDust_LoginGateHandler player: {player == null} and account is {player.Account}");
                playerComponent.Add(player);
                var playerSessionComponent = player.AddComponent<MicroDustPlayerSessionComponent>();
                playerSessionComponent.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.MicroDustGateSession);
                await playerSessionComponent.AddLocation(LocationType.GateSession);

                player.AddComponent<MailBoxComponent, MailBoxType>(MailBoxType.UnOrderedMessage);
                await player.AddLocation(LocationType.Player);

                session.AddComponent<MicroDustSessionPlayerComponent>().Player = player;
                playerSessionComponent.Session = session;
            }

            response.PlayerId = player.Id;
            response.UserId = player.PlayerId;
            await ETTask.CompletedTask;
        }

        private async ETTask<string> GetPlayerId(Session session, string account)
        {
            var dbComponent = session.Root().GetComponent<MicroDustDatabaseManagerComponent>().GetZoneDB(session.Zone());
            var accountInfo = await dbComponent.Query<MicroDustAccount>(a => a.Account == account, MicroDustCollections.Accounts);
            if (accountInfo.Any())
            {
                return accountInfo.First().UserId;
            }
            return Guid.Empty.ToString();
        }
    }
}
