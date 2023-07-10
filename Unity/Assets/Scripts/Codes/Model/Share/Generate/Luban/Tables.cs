//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;



namespace Cfg
{ 
public partial class Tables
{
    /// <summary>
    /// 测试用的账号
    /// </summary>
    public common.TbTestAccountConfig TbTestAccountConfig {get; }
    /// <summary>
    /// 单位表
    /// </summary>
    public zeus.TbZeusUnitConfig TbZeusUnitConfig {get; }
    public Global.TbGlobal TbGlobal {get; }
    public Demo.TbAIMetas TbAIMetas {get; }
    public Demo.TbUnitMeta TbUnitMeta {get; }
    public Fgui.TbFguiConfig TbFguiConfig {get; }

    public Tables(System.Func<string, ByteBuf> loader)
    {
        var tables = new System.Collections.Generic.Dictionary<string, object>();
        TbTestAccountConfig = new common.TbTestAccountConfig(loader("common_tbtestaccountconfig")); 
        tables.Add("common.TbTestAccountConfig", TbTestAccountConfig);
        TbZeusUnitConfig = new zeus.TbZeusUnitConfig(loader("zeus_tbzeusunitconfig")); 
        tables.Add("zeus.TbZeusUnitConfig", TbZeusUnitConfig);
        TbGlobal = new Global.TbGlobal(loader("global_tbglobal")); 
        tables.Add("Global.TbGlobal", TbGlobal);
        TbAIMetas = new Demo.TbAIMetas(loader("demo_tbaimetas")); 
        tables.Add("Demo.TbAIMetas", TbAIMetas);
        TbUnitMeta = new Demo.TbUnitMeta(loader("demo_tbunitmeta")); 
        tables.Add("Demo.TbUnitMeta", TbUnitMeta);
        TbFguiConfig = new Fgui.TbFguiConfig(loader("fgui_tbfguiconfig")); 
        tables.Add("Fgui.TbFguiConfig", TbFguiConfig);

        PostInit();
        TbTestAccountConfig.Resolve(tables); 
        TbZeusUnitConfig.Resolve(tables); 
        TbGlobal.Resolve(tables); 
        TbAIMetas.Resolve(tables); 
        TbUnitMeta.Resolve(tables); 
        TbFguiConfig.Resolve(tables); 
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        TbTestAccountConfig.TranslateText(translator); 
        TbZeusUnitConfig.TranslateText(translator); 
        TbGlobal.TranslateText(translator); 
        TbAIMetas.TranslateText(translator); 
        TbUnitMeta.TranslateText(translator); 
        TbFguiConfig.TranslateText(translator); 
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}