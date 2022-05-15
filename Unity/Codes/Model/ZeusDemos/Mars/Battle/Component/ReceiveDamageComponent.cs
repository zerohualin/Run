//此文件格式由工具自动生成


namespace ET
{
    public class ReceiveDamageComponent : Entity, IAwake, IUpdate, ILateUpdate, IDestroy
    {
        static string ReceivePhysicalType = $"{BuffDamageTypes.Physical}_Receive";
        static string ReceiveMagicType = $"{BuffDamageTypes.Magic}_Receive";
        static string ReceiveSingleType = $"{BuffDamageTypes.Single}_Receive";
        static string ReceiveRangeType = $"{BuffDamageTypes.Range}_Receive";
        static string ReceiveAllType = $"All_Receive";
        /// <summary>
        /// 伤害修正
        /// </summary>
        public float DamagePrefix = 1.0f;
        
        public override void Dispose()
        {
            if (IsDisposed)
                return;
            base.Dispose();
            //此处填写释放逻辑,但涉及Entity的操作，请放在Destroy中
        }
    }
}