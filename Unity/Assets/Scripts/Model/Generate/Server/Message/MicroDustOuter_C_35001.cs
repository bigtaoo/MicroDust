using MemoryPack;
using System.Collections.Generic;

namespace ET
{
    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDust_Ping)]
    [ResponseType(nameof(G2C_MicroDust_Ping))]
    public partial class C2G_MicroDust_Ping : MessageObject, ISessionRequest
    {
        public static C2G_MicroDust_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_Ping), isFromPool) as C2G_MicroDust_Ping;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDust_Ping)]
    public partial class G2C_MicroDust_Ping : MessageObject, ISessionResponse
    {
        public static G2C_MicroDust_Ping Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_Ping), isFromPool) as G2C_MicroDust_Ping;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2R_MicroDust_Login)]
    [ResponseType(nameof(R2C_MicroDust_Login))]
    public partial class C2R_MicroDust_Login : MessageObject, ISessionRequest
    {
        public static C2R_MicroDust_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2R_MicroDust_Login), isFromPool) as C2R_MicroDust_Login;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string Account { get; set; }

        [MemoryPackOrder(2)]
        public string Password { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Account = default;
            this.Password = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.R2C_MicroDust_Login)]
    public partial class R2C_MicroDust_Login : MessageObject, ISessionResponse
    {
        public static R2C_MicroDust_Login Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(R2C_MicroDust_Login), isFromPool) as R2C_MicroDust_Login;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Address = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDust_LoginGate)]
    [ResponseType(nameof(G2C_MicroDust_LoginGate))]
    public partial class C2G_MicroDust_LoginGate : MessageObject, ISessionRequest
    {
        public static C2G_MicroDust_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_LoginGate), isFromPool) as C2G_MicroDust_LoginGate;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public long Key { get; set; }

        [MemoryPackOrder(2)]
        public long GateId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Key = default;
            this.GateId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDust_LoginGate)]
    public partial class G2C_MicroDust_LoginGate : MessageObject, ISessionResponse
    {
        public static G2C_MicroDust_LoginGate Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_LoginGate), isFromPool) as G2C_MicroDust_LoginGate;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.PlayerId = default;
            this.UserId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDust_EnterMap)]
    [ResponseType(nameof(G2C_MicroDust_EnterMap))]
    public partial class C2G_MicroDust_EnterMap : MessageObject, ISessionRequest
    {
        public static C2G_MicroDust_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDust_EnterMap), isFromPool) as C2G_MicroDust_EnterMap;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDust_EnterMap)]
    public partial class G2C_MicroDust_EnterMap : MessageObject, ISessionResponse
    {
        public static G2C_MicroDust_EnterMap Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDust_EnterMap), isFromPool) as G2C_MicroDust_EnterMap;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.SelfId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_StartSceneChange)]
    public partial class M2C_MicroDust_StartSceneChange : MessageObject, IMessage
    {
        public static M2C_MicroDust_StartSceneChange Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_StartSceneChange), isFromPool) as M2C_MicroDust_StartSceneChange;
        }

        [MemoryPackOrder(0)]
        public long SceneInstanceId { get; set; }

        [MemoryPackOrder(1)]
        public string SceneName { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SceneInstanceId = default;
            this.SceneName = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustNumericData)]
    public partial class MicroDustNumericData : MessageObject
    {
        public static MicroDustNumericData Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustNumericData), isFromPool) as MicroDustNumericData;
        }

        [MemoryPackOrder(0)]
        public int Type { get; set; }

        [MemoryPackOrder(1)]
        public long Value { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Type = default;
            this.Value = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_PlayerGameInfo)]
    public partial class M2C_MicroDust_PlayerGameInfo : MessageObject, IMessage
    {
        public static M2C_MicroDust_PlayerGameInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_PlayerGameInfo), isFromPool) as M2C_MicroDust_PlayerGameInfo;
        }

        [MemoryPackOrder(0)]
        public List<MicroDustNumericData> NumericDatas { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.NumericDatas.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustPosition)]
    public partial class MicroDustPosition : MessageObject
    {
        public static MicroDustPosition Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustPosition), isFromPool) as MicroDustPosition;
        }

        [MemoryPackOrder(0)]
        public int X { get; set; }

        [MemoryPackOrder(1)]
        public int Y { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.X = default;
            this.Y = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_MajorCity)]
    public partial class M2C_MicroDust_MajorCity : MessageObject
    {
        public static M2C_MicroDust_MajorCity Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_MajorCity), isFromPool) as M2C_MicroDust_MajorCity;
        }

        [MemoryPackOrder(0)]
        public MicroDustPosition Position { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Position = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_RecruitOnce)]
    [ResponseType(nameof(M2C_MicroDust_RecruitOnce))]
    public partial class C2M_MicroDust_RecruitOnce : MessageObject, ISessionRequest
    {
        public static C2M_MicroDust_RecruitOnce Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitOnce), isFromPool) as C2M_MicroDust_RecruitOnce;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int PackId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PackId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_RecruitOnce)]
    public partial class M2C_MicroDust_RecruitOnce : MessageObject, ISessionResponse
    {
        public static M2C_MicroDust_RecruitOnce Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitOnce), isFromPool) as M2C_MicroDust_RecruitOnce;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.HeroConfigId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_RecruitFive)]
    [ResponseType(nameof(M2C_MicroDust_RecruitFive))]
    public partial class C2M_MicroDust_RecruitFive : MessageObject, ISessionRequest
    {
        public static C2M_MicroDust_RecruitFive Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitFive), isFromPool) as C2M_MicroDust_RecruitFive;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int PackId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.PackId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_RecruitFive)]
    public partial class M2C_MicroDust_RecruitFive : MessageObject, ISessionResponse
    {
        public static M2C_MicroDust_RecruitFive Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitFive), isFromPool) as M2C_MicroDust_RecruitFive;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.HeroConfigIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_RecruitCustomTimes)]
    [ResponseType(nameof(M2C_MicroDust_RecruitCustomTimes))]
    public partial class C2M_MicroDust_RecruitCustomTimes : MessageObject, ISessionRequest
    {
        public static C2M_MicroDust_RecruitCustomTimes Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_RecruitCustomTimes), isFromPool) as C2M_MicroDust_RecruitCustomTimes;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_RecruitCustomTimes)]
    public partial class M2C_MicroDust_RecruitCustomTimes : MessageObject, ISessionResponse
    {
        public static M2C_MicroDust_RecruitCustomTimes Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_RecruitCustomTimes), isFromPool) as M2C_MicroDust_RecruitCustomTimes;
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
            if (!this.IsFromPool)
            {
                return;
            }

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

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustHeroInfo)]
    public partial class MicroDustHeroInfo : MessageObject
    {
        public static MicroDustHeroInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustHeroInfo), isFromPool) as MicroDustHeroInfo;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.ConfigId = default;
            this.Level = default;
            this.Star = default;
            this.Id = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_Heros)]
    [ResponseType(nameof(M2C_MicroDust_Heros))]
    public partial class C2M_MicroDust_Heros : MessageObject, ISessionRequest
    {
        public static C2M_MicroDust_Heros Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_Heros), isFromPool) as C2M_MicroDust_Heros;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_Heros)]
    public partial class M2C_MicroDust_Heros : MessageObject, ISessionResponse
    {
        public static M2C_MicroDust_Heros Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_Heros), isFromPool) as M2C_MicroDust_Heros;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.heros.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_ConfigureArmy)]
    [ResponseType(nameof(M2C_MicroDust_ConfigureArmy))]
    public partial class C2M_MicroDust_ConfigureArmy : MessageObject, ILocationRequest
    {
        public static C2M_MicroDust_ConfigureArmy Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_ConfigureArmy), isFromPool) as C2M_MicroDust_ConfigureArmy;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Army = default;
            this.Position = default;
            this.HeroId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_ConfigureArmy)]
    public partial class M2C_MicroDust_ConfigureArmy : MessageObject, ILocationResponse
    {
        public static M2C_MicroDust_ConfigureArmy Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_ConfigureArmy), isFromPool) as M2C_MicroDust_ConfigureArmy;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustArmyMessage)]
    public partial class MicroDustArmyMessage : MessageObject
    {
        public static MicroDustArmyMessage Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustArmyMessage), isFromPool) as MicroDustArmyMessage;
        }

        [MemoryPackOrder(0)]
        public List<string> HeroIds { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.HeroIds.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDustArmies)]
    public partial class M2C_MicroDustArmies : MessageObject, IMessage
    {
        public static M2C_MicroDustArmies Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDustArmies), isFromPool) as M2C_MicroDustArmies;
        }

        [MemoryPackOrder(0)]
        public List<MicroDustArmyMessage> Arimes { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.Arimes.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustMapTile)]
    public partial class MicroDustMapTile : MessageObject
    {
        public static MicroDustMapTile Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustMapTile), isFromPool) as MicroDustMapTile;
        }

        [MemoryPackOrder(0)]
        public int PosX { get; set; }

        [MemoryPackOrder(1)]
        public int PosY { get; set; }

        [MemoryPackOrder(2)]
        public string TileType { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.PosX = default;
            this.PosY = default;
            this.TileType = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDustInitializeMap_Request)]
    [ResponseType(nameof(G2C_MicroDustInitializeMap_Response))]
    public partial class C2G_MicroDustInitializeMap_Request : MessageObject, ISessionRequest
    {
        public static C2G_MicroDustInitializeMap_Request Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDustInitializeMap_Request), isFromPool) as C2G_MicroDustInitializeMap_Request;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public List<MicroDustMapTile> MapTiles { get; set; } = new();

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.MapTiles.Clear();

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDustInitializeMap_Response)]
    public partial class G2C_MicroDustInitializeMap_Response : MessageObject, ISessionResponse
    {
        public static G2C_MicroDustInitializeMap_Response Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDustInitializeMap_Response), isFromPool) as G2C_MicroDustInitializeMap_Response;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Error { get; set; }

        [MemoryPackOrder(2)]
        public string Message { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2M_MicroDust_ArmyCommand)]
    [ResponseType(nameof(M2C_MicroDust_ArmyCommand))]
    public partial class C2M_MicroDust_ArmyCommand : MessageObject, ILocationRequest
    {
        public static C2M_MicroDust_ArmyCommand Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2M_MicroDust_ArmyCommand), isFromPool) as C2M_MicroDust_ArmyCommand;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public int Army { get; set; }

        [MemoryPackOrder(2)]
        public MicroDustPosition Target { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Army = default;
            this.Target = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.M2C_MicroDust_ArmyCommand)]
    public partial class M2C_MicroDust_ArmyCommand : MessageObject, ILocationResponse
    {
        public static M2C_MicroDust_ArmyCommand Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(M2C_MicroDust_ArmyCommand), isFromPool) as M2C_MicroDust_ArmyCommand;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.Path.Clear();
            this.Time = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.MicroDustSkillInfo)]
    public partial class MicroDustSkillInfo : MessageObject
    {
        public static MicroDustSkillInfo Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(MicroDustSkillInfo), isFromPool) as MicroDustSkillInfo;
        }

        [MemoryPackOrder(0)]
        public string SkillId { get; set; }

        [MemoryPackOrder(1)]
        public int SkillConfigId { get; set; }

        [MemoryPackOrder(2)]
        public string UsedByHeroId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.SkillId = default;
            this.SkillConfigId = default;
            this.UsedByHeroId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDustGenerateSkill_Request)]
    [ResponseType(nameof(G2C_MicroDustGenerateSkill_Response))]
    public partial class C2G_MicroDustGenerateSkill_Request : MessageObject, ISessionRequest
    {
        public static C2G_MicroDustGenerateSkill_Request Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDustGenerateSkill_Request), isFromPool) as C2G_MicroDustGenerateSkill_Request;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        [MemoryPackOrder(1)]
        public string HeroId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.HeroId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDustGenerateSkill_Response)]
    public partial class G2C_MicroDustGenerateSkill_Response : MessageObject, ISessionResponse
    {
        public static G2C_MicroDustGenerateSkill_Response Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDustGenerateSkill_Response), isFromPool) as G2C_MicroDustGenerateSkill_Response;
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
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;
            this.Error = default;
            this.Message = default;
            this.GeneratedSkill = default;
            this.HeroId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.C2G_MicroDustSkills_Request)]
    [ResponseType(nameof(G2C_MicroDustSkills_Response))]
    public partial class C2G_MicroDustSkills_Request : MessageObject, ISessionRequest
    {
        public static C2G_MicroDustSkills_Request Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(C2G_MicroDustSkills_Request), isFromPool) as C2G_MicroDustSkills_Request;
        }

        [MemoryPackOrder(0)]
        public int RpcId { get; set; }

        public override void Dispose()
        {
            if (!this.IsFromPool)
            {
                return;
            }

            this.RpcId = default;

            ObjectPool.Instance.Recycle(this);
        }
    }

    [MemoryPackable]
    [Message(MicroDustOuter.G2C_MicroDustSkills_Response)]
    public partial class G2C_MicroDustSkills_Response : MessageObject, ISessionResponse
    {
        public static G2C_MicroDustSkills_Response Create(bool isFromPool = false)
        {
            return ObjectPool.Instance.Fetch(typeof(G2C_MicroDustSkills_Response), isFromPool) as G2C_MicroDustSkills_Response;
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
            if (!this.IsFromPool)
            {
                return;
            }

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