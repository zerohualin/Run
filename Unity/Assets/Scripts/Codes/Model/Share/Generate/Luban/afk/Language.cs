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
public sealed partial class Language :  Bright.Config.BeanBase 
{
    public Language(ByteBuf _buf) 
    {
        Id = _buf.ReadString();
        Key = _buf.ReadString();
        Name = _buf.ReadString();
        UseArea = _buf.ReadString();
        ZhName = _buf.ReadString();
        ZhText1 = _buf.ReadString();
        ZhText2 = _buf.ReadString();
        PostInit();
    }

    public static Language DeserializeLanguage(ByteBuf _buf)
    {
        return new afk.Language(_buf);
    }

    public string Id { get; private set; }
    public string Key { get; private set; }
    public string Name { get; private set; }
    public string UseArea { get; private set; }
    public string ZhName { get; private set; }
    public string ZhText1 { get; private set; }
    public string ZhText2 { get; private set; }

    public const int __ID__ = -1608903808;
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
        + "Key:" + Key + ","
        + "Name:" + Name + ","
        + "UseArea:" + UseArea + ","
        + "ZhName:" + ZhName + ","
        + "ZhText1:" + ZhText1 + ","
        + "ZhText2:" + ZhText2 + ","
        + "}";
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}