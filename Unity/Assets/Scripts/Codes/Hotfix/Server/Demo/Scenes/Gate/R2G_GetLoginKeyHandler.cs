using System;

namespace ET.Server
{
	[ActorMessageHandler(SceneType.Gate)]
	public class R2G_GetLoginKeyHandler : AMActorRpcHandler<Scene, R2G_GetLoginKey, G2R_GetLoginKey>
	{
		protected override async ETTask Run(Scene scene, R2G_GetLoginKey request, G2R_GetLoginKey response)
		{
			long key = RandomGenerator.RandInt64();
			var loginGateInfo = new LoginGateInfo() { Account = request.Account, LogicZone = scene.Zone };
			scene.GetComponent<GateSessionKeyComponent>().Add(key, loginGateInfo);
			response.Key = key;
			response.GateId = scene.Id;
			await ETTask.CompletedTask;
		}
	}
}