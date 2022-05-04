//------------------------------------------------------------
// Author: 烟雨迷离半世殇
// Mail: 1778139321@qq.com
// Data: 2020年1月21日 17:07:02
//------------------------------------------------------------

namespace ET
{
    public enum RoleCast
    {
        /// <summary>
        /// 友善的
        /// </summary>
        Friendly,

        /// <summary>
        /// 敌对的
        /// </summary>
        Adverse,

        /// <summary>
        /// 中立的
        /// </summary>
        Neutral
    }

    [System.Flags]
    public enum RoleCamp
    {
        TianZai = 0b0000001,
        HuiYue = 0b0000010,
        red = 0b0000100,
        bule = 0b0001000,
        yellow = 0b0010000,
        green = 0b0100000,
        JunHeng = 0b1000000
    }

    public enum RoleTag
    {
        Sprite,
        AttackRange,
        NoCollision,
        Hero,
        Map,
        Creeps,
        SkillCollision,
    }
    
    public class B2S_RoleCastComponent : Entity, IAwake<RoleCamp, RoleTag>
    {
        public RoleTag RoleTag;

        /// <summary>
        /// 归属阵营
        /// </summary>
        public RoleCamp RoleCamp;
    }
}