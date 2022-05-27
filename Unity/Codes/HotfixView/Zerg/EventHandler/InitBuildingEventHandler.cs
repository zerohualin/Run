namespace ET
{
    public class InitBuildingEventHandler: AEvent<EventType.InitBuilding>
    {
        protected override void Run(EventType.InitBuilding args)
        {
            args.Building.AddComponent<BuildingViewComponent>();
        }
    }
}