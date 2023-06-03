using System.Collections;
using System.Collections.Generic;
using Cfg;
using UnityEngine;

namespace ET.Client
{
    [FSMHandler]
    [FriendOfAttribute(typeof (ET.Client.ProcedureComponent))]
    public class Procedure_Loding: AFSMHandler
    {
        public override void OnInit(FSMComponent fsmComponent)
        {
            base.OnInit(fsmComponent);
            ProcedureComponent procedureComponent = fsmComponent.GetParent<ProcedureComponent>();
            AddAction<Procedure_Map>(FSMAct.TryFinishLoading, () =>
            {
                if (procedureComponent.IsFinishCreateMyUnit && procedureComponent.IsFinishLoadMapScene)
                    fsmComponent.Change<Procedure_Map>();
            });
        }

        public override async ETTask OnEnter(FSMComponent fsmComponent)
        {
            ProcedureComponent procedureComponent = fsmComponent.GetParent<ProcedureComponent>();
            procedureComponent.IsFinishCreateMyUnit = false;
            procedureComponent.IsFinishLoadMapScene = false;
            
            Scene currentScene = fsmComponent.DomainScene().CurrentScene();
            currentScene.AddComponent<CameraManagerComponent>();
            
            FGUIComponent.Instance.OpenAysnc(FGUIType.Loading).Coroutine();
        }

        public override async ETTask OnExit(FSMComponent fsmComponent)
        {
            FGUIComponent.Instance.Close(FGUIType.Loading);
        }
    }
}