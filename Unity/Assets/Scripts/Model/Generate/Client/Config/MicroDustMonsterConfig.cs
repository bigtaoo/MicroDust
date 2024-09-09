using System;
using System.Collections.Generic;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Options;
using System.ComponentModel;

namespace ET
{
    [Config]
    public partial class MicroDustMonsterConfigCategory : Singleton<MicroDustMonsterConfigCategory>, IMerge
    {
        [BsonElement]
        [BsonDictionaryOptions(DictionaryRepresentation.ArrayOfArrays)]
        private Dictionary<int, MicroDustMonsterConfig> dict = new();
		
        public void Merge(object o)
        {
            MicroDustMonsterConfigCategory s = o as MicroDustMonsterConfigCategory;
            foreach (var kv in s.dict)
            {
                this.dict.Add(kv.Key, kv.Value);
            }
        }
		
        public MicroDustMonsterConfig Get(int id)
        {
            this.dict.TryGetValue(id, out MicroDustMonsterConfig item);

            if (item == null)
            {
                throw new Exception($"配置找不到，配置表名: {nameof (MicroDustMonsterConfig)}，配置id: {id}");
            }

            return item;
        }
		
        public bool Contain(int id)
        {
            return this.dict.ContainsKey(id);
        }

        public Dictionary<int, MicroDustMonsterConfig> GetAll()
        {
            return this.dict;
        }

        public MicroDustMonsterConfig GetOne()
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

	public partial class MicroDustMonsterConfig: ProtoObject, IConfig
	{
		/// <summary>Id</summary>
		public int Id { get; set; }
		/// <summary>MapId</summary>
		public int MapId { get; set; }
		/// <summary>TileLevel</summary>
		public int TileLevel { get; set; }
		/// <summary>MonsterLevel</summary>
		public int MonsterLevel { get; set; }
		/// <summary>Monster1Id</summary>
		public int Monster1Id { get; set; }
		/// <summary>Monster1Skill1</summary>
		public int Monster1Skill1 { get; set; }
		/// <summary>Monster1Skill2</summary>
		public int Monster1Skill2 { get; set; }
		/// <summary>Monster1Skill3</summary>
		public int Monster1Skill3 { get; set; }
		/// <summary>Monster2Id</summary>
		public int Monster2Id { get; set; }
		/// <summary>Monster2Skill1</summary>
		public int Monster2Skill1 { get; set; }
		/// <summary>Monster2Skill2</summary>
		public int Monster2Skill2 { get; set; }
		/// <summary>Monster2Skill3</summary>
		public int Monster2Skill3 { get; set; }
		/// <summary>Monster3Id</summary>
		public int Monster3Id { get; set; }
		/// <summary>Monster3Skill1</summary>
		public int Monster3Skill1 { get; set; }
		/// <summary>Monster3Skill2</summary>
		public int Monster3Skill2 { get; set; }
		/// <summary>Monster3Skill3</summary>
		public int Monster3Skill3 { get; set; }

	}
}
