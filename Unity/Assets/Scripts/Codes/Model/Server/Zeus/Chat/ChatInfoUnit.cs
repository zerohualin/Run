namespace ET.Server
{
    public class ChatInfoUnit : Entity, IAwake
    {
        public string Name { get; set; }
        public long GateSessionActorId { get; set; }
    }
}