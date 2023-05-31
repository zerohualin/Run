namespace ET.Server
{
    [ObjectSystem]
    public class ServerInfosComponentAwakeSystem : AwakeSystem<ServerInfosComponent>
    {
        protected override void Awake(ServerInfosComponent self)
        {
            foreach (StartZoneConfig zoneConfig in StartZoneConfigCategory.Instance.GetAll().Values)
            {
                if (zoneConfig.ZoneType == (int)ZoneType.Game)
                {
                    self.Add(new ServerInfoProto()
                    {
                        Name = zoneConfig.Name, Zone = zoneConfig.Id, Status = RandomGenerator.RandomNumber(0, 1)
                    });
                }
            }
        }
    }
}