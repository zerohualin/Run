
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using Bright.Serialization;
using System.Collections.Generic;

namespace Cfg.StartServer
{
   
public sealed class TbStartMachine
{
    private readonly Dictionary<int, StartServer.StartMachine> _dataMap;
    private readonly List<StartServer.StartMachine> _dataList;
    
    public TbStartMachine(ByteBuf _buf)
    {
        _dataMap = new Dictionary<int, StartServer.StartMachine>();
        _dataList = new List<StartServer.StartMachine>();
        
        for(int n = _buf.ReadSize() ; n > 0 ; --n)
        {
            StartServer.StartMachine _v;
            _v = StartServer.StartMachine.DeserializeStartMachine(_buf);
            _dataList.Add(_v);
            _dataMap.Add(_v.Id, _v);
        }
    }

    public Dictionary<int, StartServer.StartMachine> DataMap => _dataMap;
    public List<StartServer.StartMachine> DataList => _dataList;

    public StartServer.StartMachine GetOrDefault(int key) => _dataMap.TryGetValue(key, out var v) ? v : null;
    public StartServer.StartMachine Get(int key) => _dataMap[key];
    public StartServer.StartMachine this[int key] => _dataMap[key];

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