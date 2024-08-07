using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustSkillConfigCategory : Singleton<MicroDustSkillConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustSkillConfig> dict = new();
		
        public void Merge(object o)
        {
            MicroDustSkillConfigCategory s = o as MicroDustSkillConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustSkillConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustSkillConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustSkillConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustSkillConfig> GetAll()
        {
            return this.dict;
        }

        public MicroDustSkillConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class MicroDustSkillConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }
		/// <summary>Description</summary>
		public string Description { get; set; }
		/// <summary>Quality</summary>
		public string Quality { get; set; }
		/// <summary>SkillType</summary>
		public int SkillType { get; set; }
		/// <summary>Rate</summary>
		public int Rate { get; set; }
		/// <summary>Count</summary>
		public int Count { get; set; }

	}
}
