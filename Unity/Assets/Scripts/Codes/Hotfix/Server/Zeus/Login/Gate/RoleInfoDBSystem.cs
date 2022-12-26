using ET.Server;

namespace ET
{
    [FriendOfAttribute(typeof(ET.Server.RoleInfoDB))]
    public static class RoleInfoDBSystem
    {
        public static RoleInfoProto ToMessage(this RoleInfoDB roleInfoDB)
        {
            return new RoleInfoProto() { UnitId = roleInfoDB.Id, Name = roleInfoDB.Name, Level = roleInfoDB.Level };
        }
    }
}