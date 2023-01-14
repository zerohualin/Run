//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;


namespace Cfg.zeus
{
   
/// <summary>
/// 单位表
/// </summary>
public partial class TbZeusUnitConfig
{
    private readonly Dictionary<int, zeus.UnitConfig> _dataMap;
    private readonly List<zeus.UnitConfig> _dataList;
    
    public TbZeusUnitConfig(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, zeus.UnitConfig>();
        _dataList = new List<zeus.UnitConfig>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            zeus.UnitConfig _v;
            _v = zeus.UnitConfig.DeserializeUnitConfig(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<int, zeus.UnitConfig> DataMap => _dataMap;
    public List<zeus.UnitConfig> DataList => _dataList;

    public zeus.UnitConfig GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public zeus.UnitConfig Get(int key) => _dataMap[key];
    public zeus.UnitConfig this[int key] => _dataMap[key];

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