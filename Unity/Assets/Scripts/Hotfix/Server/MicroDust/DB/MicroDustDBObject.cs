using System.Collections.Generic;

namespace ET.Server
{
    public class MicroDustDBObject : Entity
    {
        public string PlayerId { get; set; }
        public Entity Self { get; set; }
        public List<Entity> Entities { get; set; } = new List<Entity>();
    }
}
