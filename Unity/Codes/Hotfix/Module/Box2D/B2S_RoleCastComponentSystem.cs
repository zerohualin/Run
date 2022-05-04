namespace ET
{
    public class B2S_RoleCastComponentAwakeSystem: AwakeSystem<B2S_RoleCastComponent, RoleCamp, RoleTag>
    {
        public override void Awake(B2S_RoleCastComponent self, RoleCamp a, RoleTag b)
        {
            self.RoleCamp = a;
            self.RoleTag = b;
        }
    }

    [FriendClass(typeof(B2S_RoleCastComponent))]
    public static class B2S_RoleCastComponentSystem
    {
        /// <summary>
        /// 获取与目标的关系
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public static RoleCast GetRoleCastToTarget(this B2S_RoleCastComponent self, Unit unit)
        {
            if (unit.GetComponent<B2S_RoleCastComponent>() == null)
            {
                return RoleCast.Friendly;
            }

            RoleCamp roleCamp = unit.GetComponent<B2S_RoleCastComponent>().RoleCamp;

            if (roleCamp == self.RoleCamp)
            {
                return RoleCast.Friendly;
            }

            if (roleCamp != self.RoleCamp)
            {
                if (roleCamp == RoleCamp.JunHeng || self.RoleCamp == RoleCamp.JunHeng)
                {
                    return RoleCast.Neutral;
                }
                else
                {
                    return RoleCast.Adverse;
                }
            }

            return RoleCast.Friendly;
        }
    }
}