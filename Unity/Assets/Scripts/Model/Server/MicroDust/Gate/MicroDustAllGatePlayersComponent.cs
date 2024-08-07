using System.Collections.Generic;

namespace ET.Server
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustAllGatePlayersComponent : Entity, IAwake, IDestroy
    {
        public Dictionary<string, MicroDustGatePlayerComponent> dictionary = new();
    }
}
