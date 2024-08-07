using System.Collections.Generic;

namespace ET.Client
{
    public class MicroDustRecruitHistoryComponent : Entity, IAwake
    {
        public List<int> Recruits { get; set; } = new();
    }
}
