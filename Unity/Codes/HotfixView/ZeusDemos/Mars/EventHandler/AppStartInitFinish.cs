using System.Collections.Generic;
using Cfg;
using UnityEngine;

namespace ET
{
    public class AppStartInitFinish : AEventAsync<EventType.AppStartInitFinish>
    {
        protected override async ETTask Run(EventType.AppStartInitFinish args)
        {
            args.ZoneScene.AddComponent<FGUIComponent>();
            args.ZoneScene.AddComponent<FGUIEventComponent>();
            
            await FGUIComponent.Instance.OpenAysnc(FGUIType.ZesuDemoSelect);
            
            args.ZoneScene.AddComponent<CameraManagerComponent>();
            
            var unit = UnitHelper.GetMyUnitFromBattleRoom(args.ZoneScene);
            
            var list = new List<Vector3>();
            list.Add(new Vector3(1, 0, 1));
            list.Add(new Vector3(3, 0, 3));
            await unit.MoveToAsync(list);
        }
    }
}