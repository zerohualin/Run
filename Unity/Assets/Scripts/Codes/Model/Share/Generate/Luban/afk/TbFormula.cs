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
   
/// <summary>
/// 公式表
/// </summary>
public partial class TbFormula
{
    private readonly Dictionary<string, afk.Formula> _dataMap;
    private readonly List<afk.Formula> _dataList;
    
    public TbFormula(ByteBuf _buf)
    {
        _dataMap = new Dictionary<string, afk.Formula>();
        _dataList = new List<afk.Formula>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            afk.Formula _v;
            _v = afk.Formula.DeserializeFormula(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
        PostInit();
    }

    public Dictionary<string, afk.Formula> DataMap => _dataMap;
    public List<afk.Formula> DataList => _dataList;

    public afk.Formula GetOrDefault(string key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public afk.Formula Get(string key) => _dataMap[key];
    public afk.Formula this[string key] => _dataMap[key];

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