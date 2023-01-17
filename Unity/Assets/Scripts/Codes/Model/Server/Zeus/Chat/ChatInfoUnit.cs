namespace ET.Server
{
    [ChildOf(typeof(ChatInfoUnitsComponent))]
    public class ChatInfoUnit : Entity, IAwake
    {
        public string Name { get; set; }
        public long GateSessionActorId { get; set; }
    }
}