using System;
using System.Linq;

namespace ET.Server
{
    [MessageSessionHandler(SceneType.MicroDustRealm)]
    public class C2R_MicroDust_LoginHandler : MessageSessionHandler<C2R_MicroDust_Login, R2C_MicroDust_Login>
    {
        protected override async ETTask Run(Session session, C2R_MicroDust_Login request, R2C_MicroDust_Login response)
        {
            var isLoginValid = await IsLoginValid(session, request);
            if (!isLoginValid)
            {
                response.Error = 1;
                return;
            }
            var config = RealmGateAddressHelper.GetGate(session.Zone(), request.Account);
            session.Fiber().Debug($"gate address: {config}");

            var g2RGetLoginKey = (G2R_MicroDust_LoginKey)await session.Fiber().Root.GetComponent<MessageSender>().Call(
                config.ActorId, new R2G_MicroDust_LoginKey() { Account = request.Account });

            response.Address = config.InnerIPPort.ToString();
            response.Key = g2RGetLoginKey.Key;
            response.GateId = g2RGetLoginKey.GateId;
        }

        private async ETTask<bool> IsLoginValid(Session session, C2R_MicroDust_Login request)
        {
            var dbComponent = DBFactory.GetDBComponent(session, session.Zone());
            var accountInfo = (await dbComponent.Query<MicroDustAccount>(
                a => a.Account == request.Account,
                MicroDustCollections.Accounts)).FirstOrDefault();
            if (accountInfo == null)
            {
                var salt = MicroDustAccountHelper.GenerateSalt();
                var password = MicroDustAccountHelper.HashPassword(request.Password, salt);
                accountInfo = new MicroDustAccount
                { 
                    Account = request.Account,
                    Salt = salt,
                    Password = password,
                    UserId = Guid.NewGuid().ToString(),
                };
                accountInfo.ForceIdInit();
                await dbComponent.Save(accountInfo, MicroDustCollections.Accounts);
                return true;
            }

            var hashPassword = MicroDustAccountHelper.HashPassword(request.Password, accountInfo.Salt);
            return hashPassword == accountInfo.Password;
        }
    }
}
