using System.Collections.Concurrent;
using System.Diagnostics;

namespace ET
{
    [ChildOf(typeof(MicroDustPlayerComponent))]
    [DebuggerDisplay("ViewName,md-unit")]
    public class MicroDustUnitInfoComponent : Entity, IAwake, ITransfer
    {
        public string UserName { get; set; }
    }
}
