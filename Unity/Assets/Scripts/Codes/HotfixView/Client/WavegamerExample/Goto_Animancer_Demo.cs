namespace ET.Client
{
    public class Goto_Animancer_Demo
    {
        [Event(SceneType.Client)]
        public class Goto_Animancer_Demo_: AEvent<EventType.Goto_Animancer_Demo>
        {
            protected override async ETTask Run(Scene scene, EventType.Goto_Animancer_Demo args)
            {
                await Game.Scene.GetComponent<TimerComponent>().WaitAsync(100);
                Log.Debug(args.ToString());
            }
        }
    }
}