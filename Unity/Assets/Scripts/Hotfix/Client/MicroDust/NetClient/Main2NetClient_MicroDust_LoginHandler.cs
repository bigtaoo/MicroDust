using System.Net.Sockets;
using System.Net;

namespace ET.Client
{
    [MessageHandler(SceneType.MicroDustNetClient)]
    public class Main2NetClient_MicroDust_LoginHandler : MessageHandler<Scene, Main2NetClient_MicroDust_Login, NetClient2Main_MicroDust_Login>
    {
        protected override async ETTask Run(Scene root, Main2NetClient_MicroDust_Login request, NetClient2Main_MicroDust_Login response)
        {
            string account = request.Account;
            string password = request.Password;

            root.RemoveComponent<MicroDustRouterAddressComponent>();
            var routerAddressComponent = root.GetComponent<MicroDustRouterAddressComponent>();
            if (routerAddressComponent == null)
            {
                routerAddressComponent =
                        root.AddComponent<MicroDustRouterAddressComponent, string, int>(ConstValue.RouterHttpHost, ConstValue.RouterHttpPort);
                await routerAddressComponent.Init();
                root.AddComponent<NetComponent, AddressFamily, NetworkProtocol>(routerAddressComponent.RouterManagerIPAddress.AddressFamily, NetworkProtocol.UDP);
            }
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);
            NetComponent netComponent = root.GetComponent<NetComponent>();

            R2C_MicroDust_Login r2CLogin;
            var loginRequest = C2R_MicroDust_Login.Create();
            loginRequest.Account = account;
            loginRequest.Password = password;
            using (Session session = await netComponent.CreateMicroDustRouterSession(realmAddress, account, password))
            {
                r2CLogin = (R2C_MicroDust_Login)await session.Call(loginRequest);
            }

            if (r2CLogin.Error == 1)
            {
                Log.Error("Invalid password");
                return;
            }

            Session gateSession = await netComponent.CreateMicroDustRouterSession(NetworkHelper.ToIPEndPoint(r2CLogin.Address), account, password);
            gateSession.AddComponent<MicroDustClientSessionErrorComponent>();
            root.AddComponent<MicroDustSessionComponent>().Session = gateSession;
            var loginGateRequest = C2G_MicroDust_LoginGate.Create();
            loginGateRequest.Key = r2CLogin.Key;
            loginGateRequest.GateId = r2CLogin.GateId;
            G2C_MicroDust_LoginGate g2CLoginGate = (G2C_MicroDust_LoginGate)await gateSession.Call(loginGateRequest);

            Log.Debug($"Login to Gate success! playerId: {g2CLoginGate.PlayerId}, userId: {g2CLoginGate.UserId}");

            response.PlayerId = g2CLoginGate.PlayerId;
            response.UserId = g2CLoginGate.UserId;
        }
    }
}
