//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Cfg.Demo
{
public sealed partial class UnitMeta :  Bright.Config.BeanBase 
{
    public UnitMeta(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Name = _buf.ReadString();
        Desc = _buf.ReadString();
        Position = _buf.ReadInt();
        Height = _buf.ReadInt();
        Weight = _buf.ReadInt();
        PostInit();
    }

    public static UnitMeta DeserializeUnitMeta(ByteBuf _buf)
    {
        return new Demo.UnitMeta(_buf);
    }

    /// <summary>
    /// Id
    /// </summary>
    public int Id { get; private set; }
    /// <summary>
    /// 名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 描述
    /// </summary>
    public string Desc { get; private set; }
    /// <summary>
    /// 位置
    /// </summary>
    public int Position { get; private set; }
    /// <summary>
    /// 身高
    /// </summary>
    public int Height { get; private set; }
    /// <summary>
    /// 体重
    /// </summary>
    public int Weight { get; private set; }

    public const int __ID__ = 1271757140;
    public override int GetTypeId() => __ID__;

    public  void Resolve(Dictionary<string, object> _tables)
    {
        PostResolve();
    }

    public  void TranslateText(System.Func<string, string, string> translator)
    {
    }

    public override string ToString()
    {
        return "{ "
        + "Id:" + Id + ","
        + "Name:" + Name + ","
        + "Desc:" + Desc + ","
        + "Position:" + Position + ","
        + "Height:" + Height + ","
        + "Weight:" + Weight + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}