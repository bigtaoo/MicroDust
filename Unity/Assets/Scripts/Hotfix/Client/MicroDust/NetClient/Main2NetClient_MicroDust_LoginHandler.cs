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
                root.AddComponent<MicroDustNetClientComponent, AddressFamily, int>(
                    routerAddressComponent.RouterManagerIPAddress.AddressFamily, request.OwnerFiberId);
            }
            IPEndPoint realmAddress = routerAddressComponent.GetRealmAddress(account);

            R2C_MicroDust_Login r2CLogin;
            using (Session session = await MicroDustRouterHelper.CreateRouterSession(root, realmAddress))
            {
                r2CLogin = (R2C_MicroDust_Login)await session.Call(new C2R_MicroDust_Login() { Account = account, Password = password });
            }

            if (r2CLogin.Error == 1)
            {
                Log.Error("Invalid password");
                return;
            }

            Session gateSession = await MicroDustRouterHelper.CreateRouterSession(root, NetworkHelper.ToIPEndPoint(r2CLogin.Address));
            gateSession.AddComponent<MicroDustClientSessionErrorComponent>();
            root.AddComponent<MicroDustSessionComponent>().Session = gateSession;
            G2C_MicroDust_LoginGate g2CLoginGate = (G2C_MicroDust_LoginGate)await gateSession.Call(
                new C2G_MicroDust_LoginGate() { Key = r2CLogin.Key, GateId = r2CLogin.GateId });

            Log.Debug($"Login to Gate success! playerId: {g2CLoginGate.PlayerId}, userId: {g2CLoginGate.UserId}");

            response.PlayerId = g2CLoginGate.PlayerId;
            response.UserId = g2CLoginGate.UserId;
        }
    }
}
