//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年1月13日 17:25:39
//------------------------------------------------------------

using System;
using System.Collections.Generic;
using ET;

namespace ET
{
    /// <summary>
    /// 适用于动画切换的栈式状态机
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class StackFsmComponent: Entity, IAwake
    {
        /// <summary>
        /// 当前持有的状态，用于外部获取对比，减少遍历次数
        /// Key为状态类型，V为具体状态类
        /// </summary>
        public Dictionary<StateTypes, List<AFsmStateBase>> m_States = new Dictionary<StateTypes, List<AFsmStateBase>>();

        /// <summary>
        /// 用于内部轮询，切换的状态类
        /// </summary>
        public LinkedList<AFsmStateBase> m_FsmStateBases = new LinkedList<AFsmStateBase>();
    }
}