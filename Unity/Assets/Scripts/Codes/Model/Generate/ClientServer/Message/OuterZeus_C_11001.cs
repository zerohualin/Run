using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[ResponseType(nameof(R2C_LoginAccount))]
	[Message(OuterZeus.C2R_LoginAccount)]
	[ProtoContract]
	public partial class C2R_LoginAccount: ProtoObject, IRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string Account { get; set; }

		[ProtoMember(3)]
		public string Password { get; set; }

		[ProtoMember(4)]
		public int LoginWay { get; set; }

	}

	[Message(OuterZeus.R2C_LoginAccount)]
	[ProtoContract]
	public partial class R2C_LoginAccount: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Token { get; set; }

		[ProtoMember(2)]
		public long AccountId { get; set; }

	}

	[Message(OuterZeus.A2C_Disconnect)]
	[ProtoContract]
	public partial class A2C_Disconnect: ProtoObject, IMessage
	{
		[ProtoMember(1)]
		public int Error { get; set; }

	}

	[Message(OuterZeus.ServerInfoProto)]
	[ProtoContract]
	public partial class ServerInfoProto: ProtoObject
	{
		[ProtoMember(1)]
		public int Zone { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int Status { get; set; }

	}

	[ResponseType(nameof(R2C_GetServerList))]
	[Message(OuterZeus.C2R_GetServerList)]
	[ProtoContract]
	public partial class C2R_GetServerList: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterZeus.R2C_GetServerList)]
	[ProtoContract]
	public partial class R2C_GetServerList: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<ServerInfoProto> ServerInfos { get; set; }

	}

	[ResponseType(nameof(R2C_LoginZone))]
	[Message(OuterZeus.C2R_LoginZone)]
	[ProtoContract]
	public partial class C2R_LoginZone: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int ZoneId { get; set; }

	}

	[Message(OuterZeus.R2C_LoginZone)]
	[ProtoContract]
	public partial class R2C_LoginZone: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string GateAddress { get; set; }

		[ProtoMember(2)]
		public long GateKey { get; set; }

	}

	[ResponseType(nameof(G2C_Login2Gate))]
	[Message(OuterZeus.C2G_Login2Gate)]
	[ProtoContract]
	public partial class C2G_Login2Gate: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long GateKey { get; set; }

	}

	[Message(OuterZeus.G2C_Login2Gate)]
	[ProtoContract]
	public partial class G2C_Login2Gate: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

	}

	[Message(OuterZeus.RoleInfoProto)]
	[ProtoContract]
	public partial class RoleInfoProto: ProtoObject
	{
		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public int Level { get; set; }

	}

	[ResponseType(nameof(G2C_GetRoles))]
	[Message(OuterZeus.C2G_GetRoles)]
	[ProtoContract]
	public partial class C2G_GetRoles: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(OuterZeus.G2C_GetRoles)]
	[ProtoContract]
	public partial class G2C_GetRoles: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public List<RoleInfoProto> Roles { get; set; }

	}

	[ResponseType(nameof(G2C_CreateRole))]
	[Message(OuterZeus.C2G_CreateRole)]
	[ProtoContract]
	public partial class C2G_CreateRole: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public string Name { get; set; }

	}

	[Message(OuterZeus.G2C_CreateRole)]
	[ProtoContract]
	public partial class G2C_CreateRole: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public RoleInfoProto Role { get; set; }

	}

	[ResponseType(nameof(G2C_DeleteRole))]
	[Message(OuterZeus.C2G_DeleteRole)]
	[ProtoContract]
	public partial class C2G_DeleteRole: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

	}

	[Message(OuterZeus.G2C_DeleteRole)]
	[ProtoContract]
	public partial class G2C_DeleteRole: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

	}

	[ResponseType(nameof(G2C_Enter2Map))]
	[Message(OuterZeus.C2G_Enter2Map)]
	[ProtoContract]
	public partial class C2G_Enter2Map: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

	}

	[Message(OuterZeus.G2C_Enter2Map)]
	[ProtoContract]
	public partial class G2C_Enter2Map: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public bool InQueue { get; set; }

		[ProtoMember(2)]
		public int Count { get; set; }

		[ProtoMember(3)]
		public int Index { get; set; }

	}

	[Message(OuterZeus.G2C_UpdateInfo)]
	[ProtoContract]
	public partial class G2C_UpdateInfo: ProtoObject, IMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public int Index { get; set; }

		[ProtoMember(2)]
		public int Count { get; set; }

	}

	[ResponseType(nameof(G2C_CancelQueue))]
	[Message(OuterZeus.C2G_CancelQueue)]
	[ProtoContract]
	public partial class C2G_CancelQueue: ProtoObject, IRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

	}

	[Message(OuterZeus.G2C_CancelQueue)]
	[ProtoContract]
	public partial class G2C_CancelQueue: ProtoObject, IResponse
	{
		[ProtoMember(90)]
		public int Error { get; set; }

		[ProtoMember(91)]
		public string Message { get; set; }

		[ProtoMember(92)]
		public int RpcId { get; set; }

	}

	[Message(OuterZeus.Chat2C_NoticeChatInfo)]
	[ProtoContract]
	public partial class Chat2C_NoticeChatInfo: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public long UnitId { get; set; }

		[ProtoMember(2)]
		public string Name { get; set; }

		[ProtoMember(3)]
		public string ChatMessage { get; set; }

	}

	[ResponseType(nameof(Chat2C_SendChatInfo))]
	[Message(OuterZeus.C2Chat_SendChatInfo)]
	[ProtoContract]
	public partial class C2Chat_SendChatInfo: ProtoObject, IActorChatInfoRequest
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string ChatMessage { get; set; }

	}

	[Message(OuterZeus.Chat2C_SendChatInfo)]
	[ProtoContract]
	public partial class Chat2C_SendChatInfo: ProtoObject, IActorChatInfoResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	public static class OuterZeus
	{
		 public const ushort C2R_LoginAccount = 11002;
		 public const ushort R2C_LoginAccount = 11003;
		 public const ushort A2C_Disconnect = 11004;
		 public const ushort ServerInfoProto = 11005;
		 public const ushort C2R_GetServerList = 11006;
		 public const ushort R2C_GetServerList = 11007;
		 public const ushort C2R_LoginZone = 11008;
		 public const ushort R2C_LoginZone = 11009;
		 public const ushort C2G_Login2Gate = 11010;
		 public const ushort G2C_Login2Gate = 11011;
		 public const ushort RoleInfoProto = 11012;
		 public const ushort C2G_GetRoles = 11013;
		 public const ushort G2C_GetRoles = 11014;
		 public const ushort C2G_CreateRole = 11015;
		 public const ushort G2C_CreateRole = 11016;
		 public const ushort C2G_DeleteRole = 11017;
		 public const ushort G2C_DeleteRole = 11018;
		 public const ushort C2G_Enter2Map = 11019;
		 public const ushort G2C_Enter2Map = 11020;
		 public const ushort G2C_UpdateInfo = 11021;
		 public const ushort C2G_CancelQueue = 11022;
		 public const ushort G2C_CancelQueue = 11023;
		 public const ushort Chat2C_NoticeChatInfo = 11024;
		 public const ushort C2Chat_SendChatInfo = 11025;
		 public const ushort Chat2C_SendChatInfo = 11026;
	}
}
