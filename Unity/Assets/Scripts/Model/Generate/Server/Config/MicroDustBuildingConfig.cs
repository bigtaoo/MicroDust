using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustBuildingConfigCategory : Singleton<MicroDustBuildingConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustBuildingConfig> dict = new();
		
        public void Merge(object o)
        {
            MicroDustBuildingConfigCategory s = o as MicroDustBuildingConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustBuildingConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustBuildingConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustBuildingConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustBuildingConfig> GetAll()
        {
            return this.dict;
        }

        public MicroDustBuildingConfig GetOne()
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

	public partial class MicroDustBuildingConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Resource</summary>
		public int Resource { get; set; }
		/// <summary>MajiorCityLevel</summary>
		public int MajiorCityLevel { get; set; }
		/// <summary>Index</summary>
		public int Index { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }
		/// <summary>StartLevel</summary>
		public int StartLevel { get; set; }
		/// <summary>MaxLevel</summary>
		public int MaxLevel { get; set; }

	}
}
