//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace Cfg.Global
{
   
public partial class TbGlobal
{
    private readonly Dictionary<int, Global.GlobalConfig> _dataMap;
    private readonly List<Global.GlobalConfig> _dataList;
    
    public TbGlobal(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, Global.GlobalConfig>();
        _dataList = new List<Global.GlobalConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            Global.GlobalConfig _v;
            _v = Global.GlobalConfig.DeserializeGlobalConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Self, _v);
        }
        PostInit();
    }

    public Dictionary<int, Global.GlobalConfig> DataMap => _dataMap;
    public List<Global.GlobalConfig> DataList => _dataList;

    public Global.GlobalConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public Global.GlobalConfig Get(int key) => _dataMap[key];
    public Global.GlobalConfig this[int key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
        PostResolve();
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
    
    partial void PostInit();
    partial void PostResolve();
}

}