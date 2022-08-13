using System.Collections.Generic;
using Animancer;
using UnityEngine;

namespace ET.Client
{
    /// <summary>
    /// 基于Animancer插件做的动画机系统。配合可视化编辑使用效果更佳
    /// </summary>
    [ComponentOf(typeof(Unit))]
    public class AnimationComponent: Entity, IAwake, IDestroy
    {
        public class SkillAnimInfo
        {
            public AnimancerState SkillAnimancerState;
            public int LayerIndex;
        }

        /// <summary>
        /// Animacner的组件
        /// </summary>
        public AnimancerComponent AnimancerComponent;

        /// <summary>
        /// 栈式状态机组件，用于辅助切换动画
        /// </summary>
        public StackFsmComponent StackFsmComponent;

        public Dictionary<string, AvatarMask> AvatarMasks = new Dictionary<string, AvatarMask>();

        /// <summary>
        /// 管理所有的动画文件
        /// </summary>
        public Dictionary<string, AnimationClip> AnimationClips = new Dictionary<string, AnimationClip>();

        /// <summary>
        /// 全身播放动画
        /// </summary>
        public AnimancerState Avatar_NoneAnimState;

        /// <summary>
        /// 仅仅在下半身播放目标动画
        /// </summary>
        public AnimancerState Avatar_DownOnlyAnimState;

        /// <summary>
        /// 仅仅在上半身播放目标动画
        /// </summary>
        public AnimancerState Avatar_UpOnlyAnimState;

        /// <summary>
        /// 用于记录技能Anim的State
        /// </summary>
        public SkillAnimInfo m_SkillAnimInfo = new SkillAnimInfo();

        /// <summary>
        /// 运行时所播放的动画文件，会动态变化
        /// 例如移动速度快到一定程度将会播放另一种跑路动画，这时候就需要动态替换RuntimeAnimationClips的Run所对应的VALUE
        /// KEY:外部调用的名称
        /// VALEU：对应AnimationClips中的KEY，可以取得相应的动画文件
        /// </summary>
        public Dictionary<string, string> RuntimeAnimationClips = new Dictionary<string, string>
        {
            { StateTypes.Run.GetStateTypeMapedString(), "Anim_Run1" },
            { StateTypes.Idle.GetStateTypeMapedString(), "Anim_Idle1" },
            { StateTypes.CommonAttack.GetStateTypeMapedString(), "Anim_Attack1" }
        };
    }
}