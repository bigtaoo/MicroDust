using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class MicroDustArmy : Entity
    {
        public ListComponent<string> HeroIds = new();
        [BsonIgnore]
        public const int MaxHeros = 3;
        public ListComponent<MicroDustPosition> Path = new();
        public MicroDustPosition CurrentPosition;
    }
}
