using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.Collections.Generic;

namespace ET
{
    [ComponentOf(typeof(MicroDustUnitInfoComponent))]
    public class MicroDustNumericComponent : Entity, IAwake, ITransfer
    {
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        public Dictionary<MicroDustNumericTypes, long> NumericDic = new();
        public long ResourceUpdateTime;
    }
}
