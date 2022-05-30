
using UnityEngine;

namespace ET
{
    public class EnemyMoveComponent : Entity, IUpdate, IAwake
    {
        public float Speed;
        public Vector3 Dir;
        public Vector3 MoveVector;
        public Vector3 Target;
    }
}