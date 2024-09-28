using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(Scene))]
    public class MicroDustHeroComponent : Entity, IAwake
    {
        public string PlayerId { get; set; }
        public List<MicroDustHero> Heros { get; set; } = new();
    }
}
