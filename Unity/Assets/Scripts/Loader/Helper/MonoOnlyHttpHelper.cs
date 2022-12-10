using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace ET
{
    public class MonoOnlyHttpHelper
    {
        static TaskCompletionSource<string> tcs = null;
        public static async ETTask<string> Request(string url)
        {
            Log.Info("MonoOnlyHttp Request " + url);
            await tcs.Task;
            return tcs.Task.Result;
        }
    }
}
