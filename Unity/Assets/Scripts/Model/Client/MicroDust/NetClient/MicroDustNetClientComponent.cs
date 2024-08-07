using System.Net.Sockets;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustNetClientComponent : Entity, IAwake<AddressFamily, int>, IDestroy, IUpdate
    {
        public AService AService;

        public int OwnerFiberId;
    }
}
