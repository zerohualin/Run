using UnityEngine;

namespace YooAssetEx
{
	internal class FsmPatchDone : IFsmNode
	{
		public string Name { private set; get; } = nameof(FsmPatchDone);

		void IFsmNode.OnEnter()
		{
			PatchEventDispatcher.SendPatchStepsChangeMsg(EPatchStates.PatchDone);
			Debug.Log("补丁流程更新完毕！");
		}

		void IFsmNode.OnUpdate()
		{
		}

		void IFsmNode.OnExit()
		{
		}
	}
}