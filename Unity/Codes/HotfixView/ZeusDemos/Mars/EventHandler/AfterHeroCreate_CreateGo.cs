using ET.EventType;

namespace ET
{
    public class AfterHeroCreate_CreateGo: AEvent<EventType.AfterUnitCreate_CreateGo>
    {
        protected override void Run(AfterUnitCreate_CreateGo args)
        {
            GameObjectComponent gameObjectComponent = args.Unit.AddComponent<GameObjectComponent, string>("Rick");
            args.Unit.AddComponent<AnimationComponent>();
            args.Unit.AddComponent<B2S_DebuggerComponent>();
            args.Unit.GetComponent<B2S_DebuggerComponent>().AddBox2dCollider(args.ColliderUnit);
        }
    }
}