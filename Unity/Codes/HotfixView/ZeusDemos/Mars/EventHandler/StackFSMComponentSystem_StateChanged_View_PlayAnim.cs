namespace ET
{
    public class StackFSMComponentSystem_StateChanged_View_PlayAnim: AEventAsync<EventType.FSMStateChanged_PlayAnim>
    {
        protected override async ETTask Run(EventType.FSMStateChanged_PlayAnim a)
        {
            a.Unit.GetComponent<AnimationComponent>().PlayAnimByStackFsmCurrent();
            await ETTask.CompletedTask;
        }
    }
}