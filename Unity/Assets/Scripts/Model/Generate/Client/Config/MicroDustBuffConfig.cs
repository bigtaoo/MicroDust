using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustBuffConfigCategory : Singleton<MicroDustBuffConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustBuffConfig> dict = new();
		
        public void Merge(object o)
        {
            MicroDustBuffConfigCategory s = o as MicroDustBuffConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustBuffConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustBuffConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustBuffConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustBuffConfig> GetAll()
        {
            return this.dict;
        }

        public MicroDustBuffConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            
            var enumerator = this.dict.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current; 
        }
    }

	public partial class MicroDustBuffConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }

	}
}
