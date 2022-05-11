using ET.EventType;
using UnityEngine;

namespace ET
{
    [FriendClass(typeof (Unit))]
    public static class MarsUnitFactory
    {
        public static Unit CreateUnit(Room room, long id, int configId)
        {
            UnitComponent unitComponent = room.GetComponent<UnitComponent>();

            Unit unit = unitComponent.AddChildWithId<Unit, int>(id, configId);
            unit.BelongToRoom = room;
            unitComponent.Add(unit);

            unit.AddComponent<B2S_RoleCastComponent, RoleCamp, RoleTag>(RoleCamp.red, RoleTag.Hero);
            
            AfterUnitCreate_CreateGo createGo = new AfterUnitCreate_CreateGo()
            {
                Unit = unit, HeroConfigId = configId,
            };
            Game.EventSystem.Publish(createGo);
            
            return unit;
        }
        
        
                /// <summary>
        /// 创建碰撞体
        /// </summary>
        /// <param name="room">归属的房间</param>
        /// <param name="belongToUnit">归属的Unit</param>
        /// <param name="colliderDataConfigId">碰撞体数据表Id</param>
        /// <param name="collisionRelationDataConfigId">碰撞关系数据表Id</param>
        /// <param name="colliderNPBehaveTreeIdInExcel">碰撞体的行为树Id</param>
        /// <returns></returns>
        public static Unit CreateSpecialColliderUnit(Room room, long belongToUnitId, long selfId, int collisionRelationDataConfigId, 
                int colliderNPBehaveTreeIdInExcel, bool followUnitPos, bool followUnitRot, Vector3 offset, Vector3 targetPos, float angle)
        {
            //为碰撞体新建一个Unit
            Unit b2sColliderEntity = UnitFactory.CreateUnit(room, selfId, 0);
            Unit belongToUnit = room.GetComponent<UnitComponent>().Get(belongToUnitId);
            b2sColliderEntity.AddComponent<B2S_ColliderComponent, CreateSkillColliderArgs>(
                new CreateSkillColliderArgs()
                {
                    belontToUnit = belongToUnit, collisionRelationDataConfigId = collisionRelationDataConfigId,
                    FollowUnitPos = followUnitPos, FollowUnitRot = followUnitRot, offset = offset,
                    targetPos = targetPos, angle = angle
                });
            return b2sColliderEntity;
        }
        
    }
}