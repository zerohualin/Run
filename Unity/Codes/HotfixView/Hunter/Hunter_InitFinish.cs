using Cfg;
using UnityEngine;

namespace ET
{
    public class Hunter_InitFinishHandler: AEventAsync<EventType.HunterInitFinish>
    {
        protected override async ETTask Run(EventType.HunterInitFinish args)
        {
            args.ZoneScene.AddComponent<FGUIComponent>();
            args.ZoneScene.AddComponent<FGUIEventComponent>();

            await FGUIComponent.Instance.OpenAysnc(FGUIType.HunterBattle);

            args.ZoneScene.AddComponent<CameraManagerComponent>();
            args.ZoneScene.GetComponent<CameraManagerComponent>().FTra.transform.position = new Vector3(50, 0, 50);

            args.ZoneScene.GetComponent<GridGroundComponent>().AddComponent<GridGroundViewComponent>();
            args.ZoneScene.GetComponent<GridGroundComponent>().AddComponent<BuildingPreviewComponent>();

            args.ZoneScene.AddComponent<CameraRayCastViewComponent>();

            args.ZoneScene.GetComponent<CameraManagerComponent>().JumpTo(35, 35);
        }
    }
}