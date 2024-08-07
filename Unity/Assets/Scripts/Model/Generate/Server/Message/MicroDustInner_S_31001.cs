using ET;
using MemoryPack;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(G2G_MicroDust_LockResponse))]
	[Message(MicroDustInner.G2G_MicroDust_LockRequest)]
	[MemoryPackable]
	public partial class G2G_MicroDust_LockRequest: MessageObject, IRequest
	{
		public static G2G_MicroDust_LockRequest Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2G_MicroDust_LockRequest() : ObjectPool.Instance.Fetch(typeof(G2G_MicroDust_LockRequest)) as G2G_MicroDust_LockRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public long Id { get; set; }

		[MemoryPackOrder(2)]
		public string Address { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Id = default;
			this.Address = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustInner.G2G_MicroDust_LockResponse)]
	[MemoryPackable]
	public partial class G2G_MicroDust_LockResponse: MessageObject, IResponse
	{
		public static G2G_MicroDust_LockResponse Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2G_MicroDust_LockResponse() : ObjectPool.Instance.Fetch(typeof(G2G_MicroDust_LockResponse)) as G2G_MicroDust_LockResponse; 
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

	[Message(MicroDustInner.G2M_MicroDust_SessionDisconnect)]
	[MemoryPackable]
	public partial class G2M_MicroDust_SessionDisconnect: MessageObject, ILocationMessage
	{
		public static G2M_MicroDust_SessionDisconnect Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2M_MicroDust_SessionDisconnect() : ObjectPool.Instance.Fetch(typeof(G2M_MicroDust_SessionDisconnect)) as G2M_MicroDust_SessionDisconnect; 
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

	[ResponseType(nameof(M2M_MicroDust_UnitTransferResponse))]
	[Message(MicroDustInner.M2M_MicroDust_UnitTransferRequest)]
	[MemoryPackable]
	public partial class M2M_MicroDust_UnitTransferRequest: MessageObject, IRequest
	{
		public static M2M_MicroDust_UnitTransferRequest Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2M_MicroDust_UnitTransferRequest() : ObjectPool.Instance.Fetch(typeof(M2M_MicroDust_UnitTransferRequest)) as M2M_MicroDust_UnitTransferRequest; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public ActorId OldActorId { get; set; }

		[MemoryPackOrder(2)]
		public byte[] Unit { get; set; }

		[MemoryPackOrder(3)]
		public List<byte[]> Entitys { get; set; } = new();

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.OldActorId = default;
			this.Unit = default;
			this.Entitys.Clear();
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustInner.M2M_MicroDust_UnitTransferResponse)]
	[MemoryPackable]
	public partial class M2M_MicroDust_UnitTransferResponse: MessageObject, IResponse
	{
		public static M2M_MicroDust_UnitTransferResponse Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new M2M_MicroDust_UnitTransferResponse() : ObjectPool.Instance.Fetch(typeof(M2M_MicroDust_UnitTransferResponse)) as M2M_MicroDust_UnitTransferResponse; 
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

	[ResponseType(nameof(G2R_MicroDust_LoginKey))]
	[Message(MicroDustInner.R2G_MicroDust_LoginKey)]
	[MemoryPackable]
	public partial class R2G_MicroDust_LoginKey: MessageObject, IRequest
	{
		public static R2G_MicroDust_LoginKey Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new R2G_MicroDust_LoginKey() : ObjectPool.Instance.Fetch(typeof(R2G_MicroDust_LoginKey)) as R2G_MicroDust_LoginKey; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public string Account { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Account = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	[Message(MicroDustInner.G2R_MicroDust_LoginKey)]
	[MemoryPackable]
	public partial class G2R_MicroDust_LoginKey: MessageObject, IResponse
	{
		public static G2R_MicroDust_LoginKey Create(bool isFromPool = true) 
		{ 
			return !isFromPool? new G2R_MicroDust_LoginKey() : ObjectPool.Instance.Fetch(typeof(G2R_MicroDust_LoginKey)) as G2R_MicroDust_LoginKey; 
		}

		[MemoryPackOrder(0)]
		public int RpcId { get; set; }

		[MemoryPackOrder(1)]
		public int Error { get; set; }

		[MemoryPackOrder(2)]
		public string Message { get; set; }

		[MemoryPackOrder(3)]
		public long Key { get; set; }

		[MemoryPackOrder(4)]
		public long GateId { get; set; }

		public override void Dispose() 
		{
			if (!this.IsFromPool) return;
			this.RpcId = default;
			this.Error = default;
			this.Message = default;
			this.Key = default;
			this.GateId = default;
			
			ObjectPool.Instance.Recycle(this); 
		}

	}

	public static class MicroDustInner
	{
		 public const ushort G2G_MicroDust_LockRequest = 31002;
		 public const ushort G2G_MicroDust_LockResponse = 31003;
		 public const ushort G2M_MicroDust_SessionDisconnect = 31004;
		 public const ushort M2M_MicroDust_UnitTransferRequest = 31005;
		 public const ushort M2M_MicroDust_UnitTransferResponse = 31006;
		 public const ushort R2G_MicroDust_LoginKey = 31007;
		 public const ushort G2R_MicroDust_LoginKey = 31008;
	}
}
