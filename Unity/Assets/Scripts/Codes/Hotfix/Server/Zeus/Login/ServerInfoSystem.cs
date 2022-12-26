// namespace ET
// {
//     [ObjectSystem]
//     public class ServerInfoAwakeSystem : AwakeSystem<ServerInfo>
//     {
//         public override void Awake(ServerInfo self)
//         {
//         }
//     }
//     [FriendClassAttribute(typeof(ET.ServerInfo))]
//     public static class ServerInfoSystem
//     {
//         public static void FromMessage(this ServerInfo self, ServerInfoProto serverInfoProto)
//         {
//             self.Id = serverInfoProto.Id;
//             self.Status = serverInfoProto.Status;
//             self.ServerName = serverInfoProto.ServerName;
//         }
//
//         public static ServerInfoProto ToMessage(this ServerInfo self)
//         {
//             return new ServerInfoProto() { Id = (int)self.Id, Status = self.Status, ServerName = self.ServerName };
//         }
//     }
// }