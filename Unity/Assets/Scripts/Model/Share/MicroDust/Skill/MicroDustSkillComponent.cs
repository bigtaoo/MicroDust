using System.Collections.Generic;

namespace ET
{
    public class MicroDustSkillComponent : Entity, IAwake
    {
        public string PlayerId { get; set; }
        public List<MicroDustSkill> Skills { get; set; } = new();
    }
}
