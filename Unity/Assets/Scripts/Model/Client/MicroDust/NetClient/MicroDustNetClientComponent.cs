using System.Net;
using System.Net.Sockets;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustNetClientComponent : Entity, IAwake<IPEndPoint, NetworkProtocol>, IAwake<AddressFamily, NetworkProtocol>, IDestroy, IUpdate
    {
        public AService AService;
    }
}
