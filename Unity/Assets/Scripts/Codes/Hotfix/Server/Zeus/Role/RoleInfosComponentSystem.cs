using System.Data;

namespace ET
{
    [ObjectSystem]
    public class RoleInfosComponentAwakeSystem: DestroySystem<RoleInfosComponent>
    {
        protected override void Destroy(RoleInfosComponent self)
        {
            self.RoleInfos.Clear();
        }
    }

    [FriendOf(typeof (RoleInfosComponent))]
    [FriendOfAttribute(typeof (ET.RoleInfo))]
    public static class RoleInfosComponentSystem
    {
        public static void Clear(this RoleInfosComponent self)
        {
            foreach (RoleInfo roleInfo in self.RoleInfos)
            {
                roleInfo?.Dispose();
            }

            self.RoleInfos.Clear();
        }

        public static void Add(this RoleInfosComponent self, RoleInfoProto roleInfoProto)
        {
            RoleInfo roleInfo = self.AddChildWithId<RoleInfo>(roleInfoProto.UnitId);
            roleInfo.Name = roleInfoProto.Name;
            roleInfo.Level = roleInfoProto.Level;
            self.RoleInfos.Add(roleInfo);
        }

        public static RoleInfo GetById(this RoleInfosComponent self, long roleInfoId)
        {
            return self.RoleInfos.Find((info) => { return info.Id == roleInfoId; });
        }

        public static void RemoveById(this RoleInfosComponent self, long roleInfoId)
        {
            var index = self.RoleInfos.FindIndex((info) => { return info.Id == roleInfoId; });
            self.RoleInfos.RemoveAt(index);
        }

        public static bool IsCurrentRoleExist(this RoleInfosComponent self)
        {
            if (self.CurrentRoleId == 0)
            {
                return false;
            }

            RoleInfo roleInfo = self.RoleInfos.Find(d => d.Id == self.CurrentRoleId);
            if (roleInfo == null)
            {
                return false;
            }

            return true;
        }
    }
}