using MongoDB.Driver;

namespace ET.Server
{
    /// <summary>
    /// 用来缓存数据
    /// </summary>
    [ChildOf(typeof(MicroDustDatabaseManagerComponent))]
    public class MicroDustDatabaseComponent : Entity, IAwake<string, string>
    {
        public const int TaskCount = 32;

        public MongoClient mongoClient;
        public IMongoDatabase database;
    }
}