using System.Collections.Generic;

namespace ET.Client
{
    [ComponentOf(typeof(Scene))]
    public class LocalDataComponent : Singleton<LocalDataComponent>, IAwake, IDestroy
    {
        public string FilePath;
        public string FileName;
        public Dictionary<string, int> IntDic = new Dictionary<string, int>();
        public Dictionary<string, string> StringDic = new Dictionary<string, string>();
        public LocalDataComponent()
        {
        }
    }
}