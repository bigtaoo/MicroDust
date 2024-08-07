using System.Collections.Generic;

namespace ET
{
    public class MicroDustHeroComponent : Entity, IAwake
    {
        public string PlayerId { get; set; }
        public List<MicroDustHero> Heros { get; set; } = new();
    }
}
