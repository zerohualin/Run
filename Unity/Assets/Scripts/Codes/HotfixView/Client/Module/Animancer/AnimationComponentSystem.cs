using Animancer;
using MongoDB.Bson;
using UnityEngine;

namespace ET.Client
{
    [ObjectSystem]
    [FriendOfAttribute(typeof (ET.Client.AvatarComponent))]
    public class AnimationComponentAwakeSystem: AwakeSystem<AnimationComponent>
    {
        protected override void Awake(AnimationComponent self)
        {
            GameObject gameObject = self.GetParent<AvatarComponent>().RoleObj;
            self.AnimancerComponent = gameObject.GetComponent<AnimancerComponent>();
            // self.StackFsmComponent = self.GetParent<AvatarComponent>().GetComponent<StackFsmComponent>();

            //如果是以Anim开头的key值，说明是动画文件，需要添加引用

            foreach (var referenceCollectorData in gameObject.GetComponent<ReferenceCollector>().data)
            {
                if (referenceCollectorData.key.StartsWith("Anim"))
                {
                    self.AnimationClips.Add(referenceCollectorData.key,
                        referenceCollectorData.gameObject as AnimationClip);
                }

                if (referenceCollectorData.key.StartsWith("AnimMask"))
                {
                    self.AvatarMasks.Add(referenceCollectorData.key, referenceCollectorData.gameObject as AvatarMask);
                }
            }

            // self.AnimancerComponent.Layers[(int)PlayAnimInfo.AvatarMaskType.AnimMask_UpNotAffect]
            //         .SetMask(self.AvatarMasks[PlayAnimInfo.AvatarMaskType.AnimMask_UpNotAffect.ToString()]);
            // self.AnimancerComponent.Layers[(int)PlayAnimInfo.AvatarMaskType.AnimMask_DownNotAffect]
            //         .SetMask(self.AvatarMasks[PlayAnimInfo.AvatarMaskType.AnimMask_DownNotAffect.ToString()]);

            self.PlayIdelFromStart();
        }
    }

    [ObjectSystem]
    public class AnimationComponentDestroySystem: DestroySystem<AnimationComponent>
    {
        protected override void Destroy(AnimationComponent self)
        {
            self.AnimancerComponent = null;
            self.StackFsmComponent = null;
            self.AnimationClips.Clear();
            self.RuntimeAnimationClips.Clear();

            self.Avatar_DownOnlyAnimState = null;
            self.Avatar_UpOnlyAnimState = null;
        }
    }

    [FriendOfAttribute(typeof (ET.Client.AnimationComponent))]
    public static class AnimationComponentSystem
    {
        /// <summary>
        /// 播放技能的特定接口
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <param name="avatarMaskType"></param>
        /// <param name="fadeDuration"></param>
        /// <param name="speed"></param>
        /// <param name="fadeMode"></param>
        /// <returns></returns>
        public static AnimancerState PlaySkillAnim(this AnimationComponent self, string stateTypes,
        PlayAnimInfo.AvatarMaskType avatarMaskType = PlayAnimInfo.AvatarMaskType.None, float fadeDuration = 0.25f, float speed = 1.0f,
        FadeMode fadeMode = FadeMode.FixedDuration)
        {
            AnimancerState animancerState = null;

            // 当目前的状态为Run时才会考虑Avatar混合
            if (avatarMaskType == PlayAnimInfo.AvatarMaskType.AnimMask_DownNotAffect &&
                self.StackFsmComponent.GetCurrentFsmState().StateTypes == StateTypes.Run)
            {
                animancerState = self.AnimancerComponent.Layers[(int)avatarMaskType]
                        .Play(self.AnimationClips[self.RuntimeAnimationClips[stateTypes]], fadeDuration, fadeMode);

                self.Avatar_UpOnlyAnimState = animancerState;
            }
            else // 否则直接按无AvatarMask播放
            {
                animancerState = self.PlayCommonAnim_Internal(stateTypes, PlayAnimInfo.AvatarMaskType.None, fadeDuration,
                    speed, fadeMode);

                self.Avatar_NoneAnimState = animancerState;
            }

            self.m_SkillAnimInfo.LayerIndex = (int)avatarMaskType;
            self.m_SkillAnimInfo.SkillAnimancerState = animancerState;
            self.m_SkillAnimInfo.SkillAnimancerState.Events.OnEnd = () => { self.m_SkillAnimInfo.SkillAnimancerState.StartFade(0, 0.1f); };
            return animancerState;
        }

        /// <summary>
        /// 播放一个动画(播放完成自动回到默认动画)
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <returns></returns>
        public static void PlayAnimAndReturnIdelFromStart(this AnimationComponent self, StateTypes stateTypes, float fadeDuration = 0.25f,
        float speed = 1.0f, FadeMode fadeMode = FadeMode.FixedDuration)
        {
            self.PlayCommonAnim(stateTypes, self.Avatar_UpOnlyAnimState is { IsPlaying: true }
                    ? PlayAnimInfo.AvatarMaskType.AnimMask_UpNotAffect
                    : PlayAnimInfo.AvatarMaskType.None, fadeDuration, speed, fadeMode).Events.OnEnd = self.PlayIdelFromStart;
        }

        /// <summary>
        /// 播放默认动画如果在此期间再次播放，则会从头开始
        /// </summary>
        public static void PlayIdelFromStart(this AnimationComponent self)
        {
            string IdleName = StateTypes.Idle.GetStateTypeMapedString();
            self.Avatar_DownOnlyAnimState =
                    self.AnimancerComponent.Play(self.AnimationClips[self.RuntimeAnimationClips[IdleName]], 0.25f, FadeMode.FromStart);
        }

        /// <summary>
        /// 播放默认动画如果在此期间再次播放，则会继续播放
        /// </summary>
        public static void PlayIdle(this AnimationComponent self)
        {
            string idleName = StateTypes.Idle.GetStateTypeMapedString();
            self.Avatar_DownOnlyAnimState = self.AnimancerComponent.Play(self.AnimationClips[self.RuntimeAnimationClips[idleName]], 0.25f);
        }

        /// <summary>
        /// 播放跑路动画（非正式版）
        /// </summary>
        public static void PlayRun(this AnimationComponent self)
        {
            if (self.AnimancerComponent.IsPlayingClip(self.AnimationClips[self.RuntimeAnimationClips[StateTypes.Idle.GetStateTypeMapedString()]]))
                self.AnimancerComponent.Play(self.AnimationClips[self.RuntimeAnimationClips[StateTypes.Run.GetStateTypeMapedString()]]);
        }

        /// <summary>
        /// 根据栈式状态机来自动播放动画
        /// 这里播放的动画都默认是常规动画，比如Idle，Run，Attack等，技能动画不在此范围内（因为技能动画不会附加状态）
        /// </summary>
        public static void PlayAnimByStackFsmCurrent(this AnimationComponent self, float fadeDuration = 0.25f, float speed = 1.0f)
        {
            StateTypes currentStateType = self.StackFsmComponent.GetCurrentFsmState().StateTypes;
            //先根据StateType进行动画播放
            if (self.RuntimeAnimationClips.ContainsKey(currentStateType.ToString()))
            {
                // 如果正在播放技能
                if (self.m_SkillAnimInfo.SkillAnimancerState is { IsPlaying: true })
                {
                    // 技能的LayerMask如果为只影响上半身，且要播放的为行走动画
                    if (self.m_SkillAnimInfo.LayerIndex == (int)PlayAnimInfo.AvatarMaskType.AnimMask_DownNotAffect &&
                        currentStateType == StateTypes.Run)
                    {
                        // 如果先释放技能再寻路，且技能尚未播放完成，就会保持上半身不变
                        self.Avatar_DownOnlyAnimState = self.PlayCommonAnim(currentStateType,
                            PlayAnimInfo.AvatarMaskType.AnimMask_UpNotAffect,
                            fadeDuration, speed);
                        self.Avatar_DownOnlyAnimState.Events.OnEnd = () => { self.Avatar_DownOnlyAnimState.StartFade(0, 0.1f); };
                    }
                }
                else
                {
                    // TODO 这里会有一个问题，如果一个技能动画不使用任何Avatar混合，并且在技能动画播放时想融合播放一个常规动画，那么这种情况下就播放不出动画
                    // 否则就直接在无AvatarMask的Layer播放
                    self.Avatar_NoneAnimState = self.PlayCommonAnim(currentStateType, PlayAnimInfo.AvatarMaskType.None,
                        fadeDuration, speed);
                }
            }
        }

        #region PRIVATE

        /// <summary>
        /// 播放一个动画,默认过渡时间为0.25s
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <param name="fadeDuration">动画过渡时间</param>
        /// <returns></returns>
        private static AnimancerState PlayCommonAnim_Internal(this AnimationComponent self, string stateTypes,
        PlayAnimInfo.AvatarMaskType avatarMaskType = PlayAnimInfo.AvatarMaskType.None,
        float fadeDuration = 0.25f, float speed = 1.0f, FadeMode fadeMode = FadeMode.FixedDuration)
        {
            AnimancerState animancerState = null;
            animancerState = self.AnimancerComponent.Layers[(int)avatarMaskType]
                    .Play(self.AnimationClips[self.RuntimeAnimationClips[stateTypes]], fadeDuration, fadeMode);
            animancerState.Speed = speed;
            return animancerState;
        }

        /// <summary>
        /// 播放一个动画,默认过渡时间为0.25s，如果在此期间再次播放，则会继续播放
        /// </summary>
        /// <param name="stateTypes"></param>
        /// <param name="fadeDuration">动画过渡时间</param>
        /// <returns></returns>
        private static AnimancerState PlayCommonAnim(this AnimationComponent self, StateTypes stateTypes,
        PlayAnimInfo.AvatarMaskType avatarMaskType = PlayAnimInfo.AvatarMaskType.None,
        float fadeDuration = 0.25f, float speed = 1.0f, FadeMode fadeMode = FadeMode.FixedDuration)
        {
            return self.PlayCommonAnim_Internal(stateTypes.GetStateTypeMapedString(), avatarMaskType, fadeDuration, speed,
                fadeMode);
        }

        #endregion
    }
}