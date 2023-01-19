using ET;
using ProtoBuf;
using System.Collections.Generic;
namespace ET
{
	[Message(OuterMonopoly.Monopoly2C_RollDiceResult)]
	[ProtoContract]
	public partial class Monopoly2C_RollDiceResult: ProtoObject, IActorMessage
	{
		[ProtoMember(90)]
		public int RpcId { get; set; }

		[ProtoMember(91)]
		public int Error { get; set; }

		[ProtoMember(92)]
		public string Message { get; set; }

		[ProtoMember(1)]
		public int Result { get; set; }

	}

	[Message(OuterMonopoly.C2Monopoly_RollDice)]
	[ProtoContract]
	public partial class C2Monopoly_RollDice: ProtoObject, IActorMonopolyMessage
	{
		[ProtoMember(1)]
		public int RpcId { get; set; }

		[ProtoMember(2)]
		public string ChatMessage { get; set; }

	}

	public static class OuterMonopoly
	{
		 public const ushort Monopoly2C_RollDiceResult = 12002;
		 public const ushort C2Monopoly_RollDice = 12003;
	}
}
