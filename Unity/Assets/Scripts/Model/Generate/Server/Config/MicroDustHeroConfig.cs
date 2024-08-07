using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustHeroConfigCategory : Singleton<MicroDustHeroConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustHeroConfig> dict = new();
		
        public void Merge(object o)
        {
            MicroDustHeroConfigCategory s = o as MicroDustHeroConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustHeroConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustHeroConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustHeroConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustHeroConfig> GetAll()
        {
            return this.dict;
        }

        public MicroDustHeroConfig GetOne()
        {
            if (this.dict == null || this.dict.Count <= 0)
            {
                return null;
            }
            return this.dict.Values.GetEnumerator().Current;
        }
    }

	public partial class MicroDustHeroConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>Type</summary>
		public int Type { get; set; }
		/// <summary>Name</summary>
		public string Name { get; set; }
		/// <summary>Ruler</summary>
		public string Ruler { get; set; }
		/// <summary>StrengthBase</summary>
		public int StrengthBase { get; set; }
		/// <summary>StrengthAdd</summary>
		public int StrengthAdd { get; set; }
		/// <summary>IntelligenceBase</summary>
		public int IntelligenceBase { get; set; }
		/// <summary>IntelligenceAdd</summary>
		public int IntelligenceAdd { get; set; }
		/// <summary>AgilityBase</summary>
		public int AgilityBase { get; set; }
		/// <summary>AgilityAdd</summary>
		public int AgilityAdd { get; set; }
		/// <summary>PoliticBase</summary>
		public int PoliticBase { get; set; }
		/// <summary>PoliticAdd</summary>
		public int PoliticAdd { get; set; }
		/// <summary>Camp</summary>
		public string Camp { get; set; }
		/// <summary>Fire</summary>
		public string Fire { get; set; }
		/// <summary>Water</summary>
		public string Water { get; set; }
		/// <summary>Wood</summary>
		public string Wood { get; set; }
		/// <summary>Earth</summary>
		public string Earth { get; set; }
		/// <summary>Metal</summary>
		public string Metal { get; set; }
		/// <summary>SelfSkillId</summary>
		public int SelfSkillId { get; set; }
		/// <summary>GenerateSkillId</summary>
		public int GenerateSkillId { get; set; }

	}
}
