using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
// using
	[ResponseType(nameof(Monopoly2G_Enter))]
	[Message(InnerMonopoly.G2Monopoly_Enter)]
	[ProtoContract]
	public partial class G2Monopoly_Enter: ProtoObject, IActorRequest
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

	[Message(InnerMonopoly.Monopoly2G_Enter)]
	[ProtoContract]
	public partial class Monopoly2G_Enter: ProtoObject, IActorResponse
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

	[ResponseType(nameof(Monopoly2G_ResponseExit))]
	[Message(InnerMonopoly.G2Monopoly_RequestExit)]
	[ProtoContract]
	public partial class G2Monopoly_RequestExit: ProtoObject, IActorRequest
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

	}

	[Message(InnerMonopoly.Monopoly2G_ResponseExit)]
	[ProtoContract]
	public partial class Monopoly2G_ResponseExit: ProtoObject, IActorResponse
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

	}

	public static class InnerMonopoly
	{
		 public const ushort G2Monopoly_Enter = 22002;
		 public const ushort Monopoly2G_Enter = 22003;
		 public const ushort G2Monopoly_RequestExit = 22004;
		 public const ushort Monopoly2G_ResponseExit = 22005;
	}
}
