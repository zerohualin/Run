//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Cfg.afk
{
public sealed partial class Formula :  Bright.Config.BeanBase 
{
    public Formula(ByteBuf _buf) 
    {
        Id = _buf.ReadString();
        Name = _buf.ReadString();
        ForEach = (ForEachType)_buf.ReadInt();
        Text = _buf.ReadString();
        Params = _buf.ReadString();
        Param = _buf.ReadString();
        Description = _buf.ReadString();
        PostInit();
    }

    public static Formula DeserializeFormula(ByteBuf _buf)
    {
        return new afk.Formula(_buf);
    }

    public string Id { get; private set; }
    public string Name { get; private set; }
    public ForEachType ForEach { get; private set; }
    public string Text { get; private set; }
    public string Params { get; private set; }
    public string Param { get; private set; }
    public string Description { get; private set; }

    public const int __ID__ = -1647104962;
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
        + "ForEach:" + ForEach + ","
        + "Text:" + Text + ","
        + "Params:" + Params + ","
        + "Param:" + Param + ","
        + "Description:" + Description + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}