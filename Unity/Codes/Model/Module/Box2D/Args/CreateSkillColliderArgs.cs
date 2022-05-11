using UnityEngine;

namespace ET
{
    public class CreateSkillColliderArgs
    {
        public Unit belontToUnit;
        public int collisionRelationDataConfigId;
        public bool FollowUnitPos;
        public bool FollowUnitRot;
        public Vector3 offset;
        public Vector3 targetPos;
        public float angle;
    }
}