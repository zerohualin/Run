//此文件格式由工具自动生成

using System.Collections.Generic;

namespace ET
{
    public class DataModifierComponent: Entity, ILateUpdate, IDestroy, IUpdate, IAwake
    {
        /// <summary>
        /// 所有的数据修改器
        /// Key为分组名称，其中如果和NumericComponent有联系，则必须使用NumericType对应String作为Key，例如NumericType.HP对应String就是HP
        /// Value为此装饰器分组中所有的装饰器
        /// </summary>
        public Dictionary<string, List<ADataModifier>> AllModifiers = new Dictionary<string, List<ADataModifier>>();
        
        public override void Dispose()
        {
            if (IsDisposed)
                return;
            base.Dispose();
            //此处填写释放逻辑,但涉及Entity的操作，请放在Destroy中
            this.AllModifiers.Clear();
        }
    }
}