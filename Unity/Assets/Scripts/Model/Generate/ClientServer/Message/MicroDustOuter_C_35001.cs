using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(G2C_MicroDust_Ping))]
	[Message(MicroDustOuter.C2G_MicroDust_Ping)]
	[MemoryPackable]
	public partial class C2G_MicroDust_Ping: MessageObject, ISessionRequest
	{
		public static C2G_MicroDust_Ping Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDust_Ping() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_Ping)) as C2G_MicroDust_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDust_Ping)]
	[MemoryPackable]
	public partial class G2C_MicroDust_Ping: MessageObject, ISessionResponse
	{
		public static G2C_MicroDust_Ping Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDust_Ping() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_Ping)) as G2C_MicroDust_Ping; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(R2C_MicroDust_Login))]
	[Message(MicroDustOuter.C2R_MicroDust_Login)]
	[MemoryPackable]
	public partial class C2R_MicroDust_Login: MessageObject, ISessionRequest
	{
		public static C2R_MicroDust_Login Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2R_MicroDust_Login() : ObjectPool.Instance.Fetch(typeof(C2R_MicroDust_Login)) as C2R_MicroDust_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		[MemoryPackOrder(2)]
		public string Password { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			this.Password = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.R2C_MicroDust_Login)]
	[MemoryPackable]
	public partial class R2C_MicroDust_Login: MessageObject, ISessionResponse
	{
		public static R2C_MicroDust_Login Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new R2C_MicroDust_Login() : ObjectPool.Instance.Fetch(typeof(R2C_MicroDust_Login)) as R2C_MicroDust_Login; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string Address { get; set; }

		[MemoryPackOrder(4)]
		public long Key { get; set; }

		[MemoryPackOrder(5)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Address = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_MicroDust_LoginGate))]
	[Message(MicroDustOuter.C2G_MicroDust_LoginGate)]
	[MemoryPackable]
	public partial class C2G_MicroDust_LoginGate: MessageObject, ISessionRequest
	{
		public static C2G_MicroDust_LoginGate Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDust_LoginGate() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_LoginGate)) as C2G_MicroDust_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Key { get; set; }

		[MemoryPackOrder(2)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDust_LoginGate)]
	[MemoryPackable]
	public partial class G2C_MicroDust_LoginGate: MessageObject, ISessionResponse
	{
		public static G2C_MicroDust_LoginGate Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDust_LoginGate() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_LoginGate)) as G2C_MicroDust_LoginGate; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long PlayerId { get; set; }

		[MemoryPackOrder(4)]
		public string UserId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.PlayerId = default;
			this.UserId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_MicroDust_EnterMap))]
	[Message(MicroDustOuter.C2G_MicroDust_EnterMap)]
	[MemoryPackable]
	public partial class C2G_MicroDust_EnterMap: MessageObject, ISessionRequest
	{
		public static C2G_MicroDust_EnterMap Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDust_EnterMap() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_EnterMap)) as C2G_MicroDust_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDust_EnterMap)]
	[MemoryPackable]
	public partial class G2C_MicroDust_EnterMap: MessageObject, ISessionResponse
	{
		public static G2C_MicroDust_EnterMap Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDust_EnterMap() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_EnterMap)) as G2C_MicroDust_EnterMap; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public string SelfId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.SelfId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_StartSceneChange)]
	[MemoryPackable]
	public partial class M2C_MicroDust_StartSceneChange: MessageObject, IMessage
	{
		public static M2C_MicroDust_StartSceneChange Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_StartSceneChange() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_StartSceneChange)) as M2C_MicroDust_StartSceneChange; 
		}

		[MemoryPackOrder(0)]
		public long SceneInstanceId { get; set; }

		[MemoryPackOrder(1)]
		public string SceneName { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SceneInstanceId = default;
			this.SceneName = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustNumericData)]
	[MemoryPackable]
	public partial class MicroDustNumericData: MessageObject
	{
		public static MicroDustNumericData Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustNumericData() : ObjectPool.Instance.Fetch(typeof(MicroDustNumericData)) as MicroDustNumericData; 
		}

		[MemoryPackOrder(0)]
		public int Type { get; set; }

		[MemoryPackOrder(1)]
		public long Value { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Type = default;
			this.Value = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_PlayerGameInfo)]
	[MemoryPackable]
	public partial class M2C_MicroDust_PlayerGameInfo: MessageObject, IMessage
	{
		public static M2C_MicroDust_PlayerGameInfo Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_PlayerGameInfo() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_PlayerGameInfo)) as M2C_MicroDust_PlayerGameInfo; 
		}

		[MemoryPackOrder(0)]
		public List<MicroDustNumericData> NumericDatas { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.NumericDatas.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustPosition)]
	[MemoryPackable]
	public partial class MicroDustPosition: MessageObject
	{
		public static MicroDustPosition Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustPosition() : ObjectPool.Instance.Fetch(typeof(MicroDustPosition)) as MicroDustPosition; 
		}

		[MemoryPackOrder(0)]
		public int X { get; set; }

		[MemoryPackOrder(1)]
		public int Y { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.X = default;
			this.Y = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_MajorCity)]
	[MemoryPackable]
	public partial class M2C_MicroDust_MajorCity: MessageObject
	{
		public static M2C_MicroDust_MajorCity Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_MajorCity() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_MajorCity)) as M2C_MicroDust_MajorCity; 
		}

		[MemoryPackOrder(0)]
		public MicroDustPosition Position { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Position = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_RecruitOnce))]
	[Message(MicroDustOuter.C2M_MicroDust_RecruitOnce)]
	[MemoryPackable]
	public partial class C2M_MicroDust_RecruitOnce: MessageObject, ISessionRequest
	{
		public static C2M_MicroDust_RecruitOnce Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_RecruitOnce() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitOnce)) as C2M_MicroDust_RecruitOnce; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int PackId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PackId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_RecruitOnce)]
	[MemoryPackable]
	public partial class M2C_MicroDust_RecruitOnce: MessageObject, ISessionResponse
	{
		public static M2C_MicroDust_RecruitOnce Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_RecruitOnce() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitOnce)) as M2C_MicroDust_RecruitOnce; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int HeroConfigId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.HeroConfigId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_RecruitFive))]
	[Message(MicroDustOuter.C2M_MicroDust_RecruitFive)]
	[MemoryPackable]
	public partial class C2M_MicroDust_RecruitFive: MessageObject, ISessionRequest
	{
		public static C2M_MicroDust_RecruitFive Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_RecruitFive() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitFive)) as C2M_MicroDust_RecruitFive; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int PackId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.PackId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_RecruitFive)]
	[MemoryPackable]
	public partial class M2C_MicroDust_RecruitFive: MessageObject, ISessionResponse
	{
		public static M2C_MicroDust_RecruitFive Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_RecruitFive() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitFive)) as M2C_MicroDust_RecruitFive; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public List<int> HeroConfigIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.HeroConfigIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_RecruitCustomTimes))]
	[Message(MicroDustOuter.C2M_MicroDust_RecruitCustomTimes)]
	[MemoryPackable]
	public partial class C2M_MicroDust_RecruitCustomTimes: MessageObject, ISessionRequest
	{
		public static C2M_MicroDust_RecruitCustomTimes Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_RecruitCustomTimes() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitCustomTimes)) as C2M_MicroDust_RecruitCustomTimes; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_RecruitCustomTimes)]
	[MemoryPackable]
	public partial class M2C_MicroDust_RecruitCustomTimes: MessageObject, ISessionResponse
	{
		public static M2C_MicroDust_RecruitCustomTimes Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_RecruitCustomTimes() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitCustomTimes)) as M2C_MicroDust_RecruitCustomTimes; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public int Spirit { get; set; }

		[MemoryPackOrder(4)]
		public List<int> Level4 { get; set; } = new();

		[MemoryPackOrder(5)]
		public int Level3Count { get; set; }

		[MemoryPackOrder(6)]
		public int Level2Count { get; set; }

		[MemoryPackOrder(7)]
		public int Level1Count { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Spirit = default;
			this.Level4.Clear();
			this.Level3Count = default;
			this.Level2Count = default;
			this.Level1Count = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustHeroInfo)]
	[MemoryPackable]
	public partial class MicroDustHeroInfo: MessageObject
	{
		public static MicroDustHeroInfo Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustHeroInfo() : ObjectPool.Instance.Fetch(typeof(MicroDustHeroInfo)) as MicroDustHeroInfo; 
		}

		[MemoryPackOrder(0)]
		public int ConfigId { get; set; }

		[MemoryPackOrder(1)]
		public int Level { get; set; }

		[MemoryPackOrder(2)]
		public int Star { get; set; }

		[MemoryPackOrder(3)]
		public string Id { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.ConfigId = default;
			this.Level = default;
			this.Star = default;
			this.Id = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_Heros))]
	[Message(MicroDustOuter.C2M_MicroDust_Heros)]
	[MemoryPackable]
	public partial class C2M_MicroDust_Heros: MessageObject, ISessionRequest
	{
		public static C2M_MicroDust_Heros Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_Heros() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_Heros)) as C2M_MicroDust_Heros; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_Heros)]
	[MemoryPackable]
	public partial class M2C_MicroDust_Heros: MessageObject, ISessionResponse
	{
		public static M2C_MicroDust_Heros Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_Heros() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_Heros)) as M2C_MicroDust_Heros; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public List<MicroDustHeroInfo> heros { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.heros.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_ConfigureArmy))]
	[Message(MicroDustOuter.C2M_MicroDust_ConfigureArmy)]
	[MemoryPackable]
	public partial class C2M_MicroDust_ConfigureArmy: MessageObject, ILocationRequest
	{
		public static C2M_MicroDust_ConfigureArmy Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_ConfigureArmy() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_ConfigureArmy)) as C2M_MicroDust_ConfigureArmy; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Army { get; set; }

		[MemoryPackOrder(2)]
		public int Position { get; set; }

		[MemoryPackOrder(3)]
		public string HeroId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Army = default;
			this.Position = default;
			this.HeroId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_ConfigureArmy)]
	[MemoryPackable]
	public partial class M2C_MicroDust_ConfigureArmy: MessageObject, ILocationResponse
	{
		public static M2C_MicroDust_ConfigureArmy Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_ConfigureArmy() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_ConfigureArmy)) as M2C_MicroDust_ConfigureArmy; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustArmyMessage)]
	[MemoryPackable]
	public partial class MicroDustArmyMessage: MessageObject
	{
		public static MicroDustArmyMessage Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustArmyMessage() : ObjectPool.Instance.Fetch(typeof(MicroDustArmyMessage)) as MicroDustArmyMessage; 
		}

		[MemoryPackOrder(0)]
		public List<string> HeroIds { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.HeroIds.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDustArmies)]
	[MemoryPackable]
	public partial class M2C_MicroDustArmies: MessageObject, IMessage
	{
		public static M2C_MicroDustArmies Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDustArmies() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDustArmies)) as M2C_MicroDustArmies; 
		}

		[MemoryPackOrder(0)]
		public List<MicroDustArmyMessage> Arimes { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.Arimes.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustMapTile)]
	[MemoryPackable]
	public partial class MicroDustMapTile: MessageObject
	{
		public static MicroDustMapTile Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustMapTile() : ObjectPool.Instance.Fetch(typeof(MicroDustMapTile)) as MicroDustMapTile; 
		}

		[MemoryPackOrder(0)]
		public int PosX { get; set; }

		[MemoryPackOrder(1)]
		public int PosY { get; set; }

		[MemoryPackOrder(2)]
		public string TileType { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.PosX = default;
			this.PosY = default;
			this.TileType = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_MicroDustInitializeMap_Response))]
	[Message(MicroDustOuter.C2G_MicroDustInitializeMap_Request)]
	[MemoryPackable]
	public partial class C2G_MicroDustInitializeMap_Request: MessageObject, ISessionRequest
	{
		public static C2G_MicroDustInitializeMap_Request Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDustInitializeMap_Request() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDustInitializeMap_Request)) as C2G_MicroDustInitializeMap_Request; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public List<MicroDustMapTile> MapTiles { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.MapTiles.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDustInitializeMap_Response)]
	[MemoryPackable]
	public partial class G2C_MicroDustInitializeMap_Response: MessageObject, ISessionResponse
	{
		public static G2C_MicroDustInitializeMap_Response Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDustInitializeMap_Response() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDustInitializeMap_Response)) as G2C_MicroDustInitializeMap_Response; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(M2C_MicroDust_ArmyCommand))]
	[Message(MicroDustOuter.C2M_MicroDust_ArmyCommand)]
	[MemoryPackable]
	public partial class C2M_MicroDust_ArmyCommand: MessageObject, ILocationRequest
	{
		public static C2M_MicroDust_ArmyCommand Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2M_MicroDust_ArmyCommand() : ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_ArmyCommand)) as C2M_MicroDust_ArmyCommand; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Army { get; set; }

		[MemoryPackOrder(2)]
		public MicroDustPosition Target { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Army = default;
			this.Target = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.M2C_MicroDust_ArmyCommand)]
	[MemoryPackable]
	public partial class M2C_MicroDust_ArmyCommand: MessageObject, ILocationResponse
	{
		public static M2C_MicroDust_ArmyCommand Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2C_MicroDust_ArmyCommand() : ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_ArmyCommand)) as M2C_MicroDust_ArmyCommand; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public List<MicroDustPosition> Path { get; set; } = new();

		[MemoryPackOrder(3)]
		public int Time { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Path.Clear();
			this.Time = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.MicroDustSkillInfo)]
	[MemoryPackable]
	public partial class MicroDustSkillInfo: MessageObject
	{
		public static MicroDustSkillInfo Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new MicroDustSkillInfo() : ObjectPool.Instance.Fetch(typeof(MicroDustSkillInfo)) as MicroDustSkillInfo; 
		}

		[MemoryPackOrder(0)]
		public string SkillId { get; set; }

		[MemoryPackOrder(1)]
		public int SkillConfigId { get; set; }

		[MemoryPackOrder(2)]
		public string UsedByHeroId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.SkillId = default;
			this.SkillConfigId = default;
			this.UsedByHeroId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_MicroDustGenerateSkill_Response))]
	[Message(MicroDustOuter.C2G_MicroDustGenerateSkill_Request)]
	[MemoryPackable]
	public partial class C2G_MicroDustGenerateSkill_Request: MessageObject, ISessionRequest
	{
		public static C2G_MicroDustGenerateSkill_Request Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDustGenerateSkill_Request() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDustGenerateSkill_Request)) as C2G_MicroDustGenerateSkill_Request; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string HeroId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.HeroId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDustGenerateSkill_Response)]
	[MemoryPackable]
	public partial class G2C_MicroDustGenerateSkill_Response: MessageObject, ISessionResponse
	{
		public static G2C_MicroDustGenerateSkill_Response Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDustGenerateSkill_Response() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDustGenerateSkill_Response)) as G2C_MicroDustGenerateSkill_Response; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public MicroDustSkillInfo GeneratedSkill { get; set; }

		[MemoryPackOrder(4)]
		public string HeroId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.GeneratedSkill = default;
			this.HeroId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[ResponseType(nameof(G2C_MicroDustSkills_Response))]
	[Message(MicroDustOuter.C2G_MicroDustSkills_Request)]
	[MemoryPackable]
	public partial class C2G_MicroDustSkills_Request: MessageObject, ISessionRequest
	{
		public static C2G_MicroDustSkills_Request Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new C2G_MicroDustSkills_Request() : ObjectPool.Instance.Fetch(typeof(C2G_MicroDustSkills_Request)) as C2G_MicroDustSkills_Request; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustOuter.G2C_MicroDustSkills_Response)]
	[MemoryPackable]
	public partial class G2C_MicroDustSkills_Response: MessageObject, ISessionResponse
	{
		public static G2C_MicroDustSkills_Response Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2C_MicroDustSkills_Response() : ObjectPool.Instance.Fetch(typeof(G2C_MicroDustSkills_Response)) as G2C_MicroDustSkills_Response; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public List<MicroDustSkillInfo> Skills { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Skills.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class MicroDustOuter
	{
		 public const ushort C2G_MicroDust_Ping = 35002;
		 public const ushort G2C_MicroDust_Ping = 35003;
		 public const ushort C2R_MicroDust_Login = 35004;
		 public const ushort R2C_MicroDust_Login = 35005;
		 public const ushort C2G_MicroDust_LoginGate = 35006;
		 public const ushort G2C_MicroDust_LoginGate = 35007;
		 public const ushort C2G_MicroDust_EnterMap = 35008;
		 public const ushort G2C_MicroDust_EnterMap = 35009;
		 public const ushort M2C_MicroDust_StartSceneChange = 35010;
		 public const ushort MicroDustNumericData = 35011;
		 public const ushort M2C_MicroDust_PlayerGameInfo = 35012;
		 public const ushort MicroDustPosition = 35013;
		 public const ushort M2C_MicroDust_MajorCity = 35014;
		 public const ushort C2M_MicroDust_RecruitOnce = 35015;
		 public const ushort M2C_MicroDust_RecruitOnce = 35016;
		 public const ushort C2M_MicroDust_RecruitFive = 35017;
		 public const ushort M2C_MicroDust_RecruitFive = 35018;
		 public const ushort C2M_MicroDust_RecruitCustomTimes = 35019;
		 public const ushort M2C_MicroDust_RecruitCustomTimes = 35020;
		 public const ushort MicroDustHeroInfo = 35021;
		 public const ushort C2M_MicroDust_Heros = 35022;
		 public const ushort M2C_MicroDust_Heros = 35023;
		 public const ushort C2M_MicroDust_ConfigureArmy = 35024;
		 public const ushort M2C_MicroDust_ConfigureArmy = 35025;
		 public const ushort MicroDustArmyMessage = 35026;
		 public const ushort M2C_MicroDustArmies = 35027;
		 public const ushort MicroDustMapTile = 35028;
		 public const ushort C2G_MicroDustInitializeMap_Request = 35029;
		 public const ushort G2C_MicroDustInitializeMap_Response = 35030;
		 public const ushort C2M_MicroDust_ArmyCommand = 35031;
		 public const ushort M2C_MicroDust_ArmyCommand = 35032;
		 public const ushort MicroDustSkillInfo = 35033;
		 public const ushort C2G_MicroDustGenerateSkill_Request = 35034;
		 public const ushort G2C_MicroDustGenerateSkill_Response = 35035;
		 public const ushort C2G_MicroDustSkills_Request = 35036;
		 public const ushort G2C_MicroDustSkills_Response = 35037;
	}
}
