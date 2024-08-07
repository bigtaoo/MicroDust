using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustBuffCategory : Singleton<MicroDustBuffCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustBuff> dict = new();
		
        public void Merge(object o)
        {
            MicroDustBuffCategory s = o as MicroDustBuffCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustBuff Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustBuff item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustBuff)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustBuff> GetAll()
        {
            return this.dict;
        }

        public MicroDustBuff GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class MicroDustBuff: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }

	}
}
