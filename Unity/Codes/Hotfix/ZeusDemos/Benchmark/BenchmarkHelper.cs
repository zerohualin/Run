﻿//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年4月24日 18:17:11
//------------------------------------------------------------

using System;
using System.Diagnostics;

namespace ET
{
    [FriendClass(typeof(BenchmarkComponent))]
    /// <summary>
    /// 压测辅助类
    /// </summary>
    public static class BenchmarkComponentSystem
    {
        /// <summary>
        /// 开始压测
        /// </summary>
        /// <param name="description">描述</param>
        /// <param name="action">要压测的函数</param>
        /// <param name="iterations">迭代次数</param>
        /// <returns></returns>
        public static double Profile(this BenchmarkComponent self, string description, Action action, int iterations = 100)
        {
            // clean up
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            // from: http://stackoverflow.com/questions/1047218/benchmarking-small-code-samples-in-c-can-this-implementation-be-improved
            //Process.GetCurrentProcess().PriorityClass = ProcessPriorityClass.High;
            //Thread.CurrentThread.Priority = ThreadPriority.Highest;
            // warm up 
            action();

            var watch = new Stopwatch();

            watch.Start();
            for (int i = 0; i < iterations; i++)
            {
                action();
            }

            watch.Stop();

            Log.Info(string.Format("[Profile] {0} took {1}ms (iters: {2} ; avg: {3}ms).", description, watch.Elapsed.TotalMilliseconds, iterations, watch.Elapsed.TotalMilliseconds / iterations));
            return watch.Elapsed.TotalMilliseconds;
        }
    }
}