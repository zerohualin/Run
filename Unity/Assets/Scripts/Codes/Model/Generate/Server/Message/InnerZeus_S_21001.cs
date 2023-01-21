using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
// using
	[Message(InnerZeus.LoginGateInfo)]
	[ProtoContract]
	public partial class LoginGateInfo: ProtoObject
	{
		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public int LogicZone { get; set; }

	}

	[ResponseType(nameof(G2R_GetGateKey))]
	[Message(InnerZeus.R2G_GetGateKey)]
	[ProtoContract]
	public partial class R2G_GetGateKey: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public LoginGateInfo Info { get; set; }

	}

	[Message(InnerZeus.G2R_GetGateKey)]
	[ProtoContract]
	public partial class G2R_GetGateKey: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long GateKey { get; set; }

	}

	[ResponseType(nameof(Name2G_CheckName))]
	[Message(InnerZeus.G2Name_CheckName)]
	[ProtoContract]
	public partial class G2Name_CheckName: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

	}

	[Message(InnerZeus.Name2G_CheckName)]
	[ProtoContract]
	public partial class Name2G_CheckName: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

	}

	[ResponseType(nameof(Queue2G_Enqueue))]
	[Message(InnerZeus.G2Queue_Enqueue)]
	[ProtoContract]
	public partial class G2Queue_Enqueue: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public long GateActorId { get; set; }

	}

	[Message(InnerZeus.Queue2G_Enqueue)]
	[ProtoContract]
	public partial class Queue2G_Enqueue: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool NeedQueue { get; set; }

		[ProtoMember(2)]
		public int Count { get; set; }

		[ProtoMember(3)]
		public int Index { get; set; }

	}

	[ResponseType(nameof(G2Queue_EnterMap))]
	[Message(InnerZeus.Queue2G_EnterMap)]
	[ProtoContract]
	public partial class Queue2G_EnterMap: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Account { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

	}

	[Message(InnerZeus.G2Queue_EnterMap)]
	[ProtoContract]
	public partial class G2Queue_EnterMap: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool NeedRemove { get; set; }

	}

	[Message(InnerZeus.Queue2G_UpdateInfo)]
	[ProtoContract]
	public partial class Queue2G_UpdateInfo: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<string> Account { get; set; }

		[ProtoMember(2)]
		public List<int> Index { get; set; }

		[ProtoMember(3)]
		public int Count { get; set; }

	}

	[Message(InnerZeus.G2Queue_Disconnect)]
	[ProtoContract]
	public partial class G2Queue_Disconnect: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public bool IsProtect { get; set; }

	}

	[Message(InnerZeus.G2M_ReLogin)]
	[ProtoContract]
	public partial class G2M_ReLogin: ProtoObject, IActorLocationMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

	}

	[ResponseType(nameof(Chat2G_EnterChat))]
	[Message(InnerZeus.G2Chat_EnterChat)]
	[ProtoContract]
	public partial class G2Chat_EnterChat: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

		[ProtoMember(2)]
		public long UnitId { get; set; }

		[ProtoMember(3)]
		public long GateSessionActorId { get; set; }

	}

	[Message(InnerZeus.Chat2G_EnterChat)]
	[ProtoContract]
	public partial class Chat2G_EnterChat: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long ChatInfoUnitInstanceId { get; set; }

	}

	[ResponseType(nameof(Chat2G_ResponseExitChat))]
	[Message(InnerZeus.G2Chat_RequestExitChat)]
	[ProtoContract]
	public partial class G2Chat_RequestExitChat: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(InnerZeus.Chat2G_ResponseExitChat)]
	[ProtoContract]
	public partial class Chat2G_ResponseExitChat: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	public static class InnerZeus
	{
		 public const ushort LoginGateInfo = 21002;
		 public const ushort R2G_GetGateKey = 21003;
		 public const ushort G2R_GetGateKey = 21004;
		 public const ushort G2Name_CheckName = 21005;
		 public const ushort Name2G_CheckName = 21006;
		 public const ushort G2Queue_Enqueue = 21007;
		 public const ushort Queue2G_Enqueue = 21008;
		 public const ushort Queue2G_EnterMap = 21009;
		 public const ushort G2Queue_EnterMap = 21010;
		 public const ushort Queue2G_UpdateInfo = 21011;
		 public const ushort G2Queue_Disconnect = 21012;
		 public const ushort G2M_ReLogin = 21013;
		 public const ushort G2Chat_EnterChat = 21014;
		 public const ushort Chat2G_EnterChat = 21015;
		 public const ushort G2Chat_RequestExitChat = 21016;
		 public const ushort Chat2G_ResponseExitChat = 21017;
	}
}
