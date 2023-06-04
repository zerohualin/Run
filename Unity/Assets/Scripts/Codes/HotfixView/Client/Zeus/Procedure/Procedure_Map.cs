using Cfg;

namespace ET.Client
{
    [FSMHandler]
    public class Procedure_Map : AFSMHandler
    {
        public override void OnInit(FSMComponent fsmComponent)
        {
            base.OnInit(fsmComponent);
            AddAction<Procedure_Login>(FSMAct.ToLogin);
            AddAction<Procedure_Loding>(FSMAct.ToLoading);
        }
        
        public override async ETTask OnEnter(FSMComponent fsmComponent)
        {
            FGUIComponent.Instance.OpenAysnc(FGUIType.Play).Coroutine();
            fsmComponent.ClientScene().AddComponent<OperaComponent>();
        }
        
        public override async ETTask OnExit(FSMComponent fsmComponent)
        {
            FGUIComponent.Instance.Close(FGUIType.Play);
            fsmComponent.ClientScene().RemoveComponent<OperaComponent>();
        }
    }
}