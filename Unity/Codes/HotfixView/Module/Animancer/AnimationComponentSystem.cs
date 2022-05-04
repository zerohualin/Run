using Animancer;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class AnimationComponentAwakeSystem: AwakeSystem<AnimationComponent>
    {
        public override void Awake(AnimationComponent self)
        {
            GameObject gameObject = self.GetParent<Unit>().GetComponent<GameObjectComponent>().GameObject;
            self.AnimancerComponent = gameObject.GetComponent<AnimancerComponent>();
            self.StackFsmComponent = self.GetParent<Unit>().GetComponent<StackFsmComponent>();
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
        public override void Destroy(AnimationComponent self)
        {
            self.AnimancerComponent = null;
            self.StackFsmComponent = null;
            self.AnimationClips.Clear();
            self.RuntimeAnimationClips.Clear();

            self.Avatar_DownOnlyAnimState = null;
            self.Avatar_UpOnlyAnimState = null;
        }
    }
}