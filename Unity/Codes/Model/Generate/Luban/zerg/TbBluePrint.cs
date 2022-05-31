
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace Cfg.zerg
{
   
/// <summary>
/// 蓝图表
/// </summary>
public sealed class TbBluePrint
{
    private readonly Dictionary<string, zerg.BluePrintConfig> _dataMap;
    private readonly List<zerg.BluePrintConfig> _dataList;
    
    public TbBluePrint(ByteBuf _buf)
    {
        _dataMap = new Dictionary<string, zerg.BluePrintConfig>();
        _dataList = new List<zerg.BluePrintConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            zerg.BluePrintConfig _v;
            _v = zerg.BluePrintConfig.DeserializeBluePrintConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public Dictionary<string, zerg.BluePrintConfig> DataMap => _dataMap;
    public List<zerg.BluePrintConfig> DataList => _dataList;

    public zerg.BluePrintConfig GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public zerg.BluePrintConfig Get(string key) => _dataMap[key];
    public zerg.BluePrintConfig this[string key] => _dataMap[key];

    public void Resolve(Dictionary<string, object> _tables)
    {
        foreach(var v in _dataList)
        {
            v.Resolve(_tables);
        }
    }

    public void TranslateText(System.Func<string, string, string> translator)
    {
        foreach(var v in _dataList)
        {
            v.TranslateText(translator);
        }
    }
}

}