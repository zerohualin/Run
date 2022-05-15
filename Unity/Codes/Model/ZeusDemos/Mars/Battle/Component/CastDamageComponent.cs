//此文件格式由工具自动生成

using ET;

namespace ET
{
    public class CastDamageComponent: Entity, ILateUpdate, IUpdate, IAwake, IDestroy
    {
        public string CastPhysicalType = $"{BuffDamageTypes.Physical}_Cast";
        public string CastMagicType = $"{BuffDamageTypes.Magic}_Cast";
        public string CastSingleType = $"{BuffDamageTypes.Single}_Cast";
        public string CastRangeType = $"{BuffDamageTypes.Range}_Cast";
        public string CastAllType = $"All_Cast";
        
        public override void Dispose()
        {
            if (IsDisposed)
                return;
            base.Dispose();
            //此处填写释放逻辑,但涉及Entity的操作，请放在Destroy中
        }
    }
}