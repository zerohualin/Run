using UnityEngine;

namespace ET
{

    /// <summary>
    /// 用于鼠标选择目标的组件，功能类似于UserInputComponent，需要指定目标的其余组件可以从这个组件来获取目标对象
    /// </summary>
    public class MouseTargetSelectorComponent : Entity, ILateUpdate, IUpdate, IAwake, IDestroy
    {
        public Camera MainCamera;

        public int TargetLayerInfo;

        /// <summary>
        /// 射线击中Gameobject
        /// </summary>
        public GameObject TargetGameObject;

        /// <summary>
        /// 射线击中Unit
        /// </summary>
        public Unit TargetUnit;

        /// <summary>
        /// 射线击中的点
        /// </summary>
        public Vector3 TargetHitPoint;
        
        /// <summary>
        /// 重置目标对象数据
        /// </summary>
        public void ResetTargetInfo()
        {
            this.TargetGameObject = null;
            this.TargetUnit = null;
            this.TargetHitPoint = Vector3.zero;
        }

        public override void Dispose()
        {
            if (IsDisposed)
                return;
            base.Dispose();
            //此处填写释放逻辑,但涉及Entity的操作，请放在Destroy中
            MainCamera = null;
            this.ResetTargetInfo();
        }
    }
}