using ET.EventType;

namespace ET.Client
{
    [Event(SceneType.Client)]
    public class UpdateQueueInfo_EventHandler: AEvent<UpdateQueueInfo>
    {
        protected override async ETTask Run(Scene scene, UpdateQueueInfo info)
        {
            Log.Info($"当前有{info.Count}人在排队，您排在第{info.Index}位。");
            await ETTask.CompletedTask;
        }
    }
}