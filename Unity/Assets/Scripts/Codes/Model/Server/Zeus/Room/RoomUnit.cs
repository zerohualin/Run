namespace ET.Server
{
    public class RoomUnit : Entity, IAwake
    {
        public string Name { get; set; }
        public long GateSessionActorId { get; set; }
        public long MyRoomId;
    }
}