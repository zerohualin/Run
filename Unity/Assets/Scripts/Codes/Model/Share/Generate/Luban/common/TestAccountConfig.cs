//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Cfg.common
{
public sealed partial class TestAccountConfig :  Bright.Config.BeanBase 
{
    public TestAccountConfig(ByteBuf _buf) 
    {
        Id = _buf.ReadInt();
        Account = _buf.ReadString();
        PostInit();
    }

    public static TestAccountConfig DeserializeTestAccountConfig(ByteBuf _buf)
    {
        return new common.TestAccountConfig(_buf);
    }

    public int Id { get; private set; }
    public string Account { get; private set; }

    public const int __ID__ = 1902039802;
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
        + "Account:" + Account + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}