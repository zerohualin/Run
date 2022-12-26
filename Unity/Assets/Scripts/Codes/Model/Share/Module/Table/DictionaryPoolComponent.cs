using System;
using System.Collections.Generic;

namespace ET
{
    public class DictionaryPoolComponent<T, K>: Dictionary<T, K>, IDisposable
    {
        public static DictionaryPoolComponent<T, K> Create()
        {
            return ObjectPool.Instance.Fetch(typeof (DictionaryPoolComponent<T, K>)) as DictionaryPoolComponent<T, K>;
        }

        public void Dispose()
        {
            this.Clear();
            ObjectPool.Instance.Recycle(this);
        }
    }
}