using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class MicroDustArmy
    {
        public ListComponent<string> HeroIds { get; set; } = new();
        public ListComponent<MicroDustPosition> Path { get; set; } = new();
        public MicroDustPosition CurrentPosition { get; set; } = MicroDustPosition.Create();
        [BsonIgnore]
        public const int MaxHeros = 3;
    }
}
