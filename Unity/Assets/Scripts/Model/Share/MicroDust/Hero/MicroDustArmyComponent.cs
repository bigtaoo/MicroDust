using MongoDB.Bson.Serialization.Attributes;

namespace ET
{
    public class MicroDustArmyComponent : Entity, IAwake
    {
        public string userId;
        public ListComponent<MicroDustArmy> Armies = new();
        public int AvailableArmies;
        [BsonIgnore]
        public const int MaxAvailableArmies = 10;
    }
}
