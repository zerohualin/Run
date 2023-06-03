using Cfg;

namespace ET.Client
{
    [FSMHandler]
    public class Procedure_Login: AFSMHandler
    {
        public override void OnInit(FSMComponent fsmComponent)
        {
            base.OnInit(fsmComponent);
            AddAction<Procedure_Loding>(FSMAct.ToLoading);
        }

        public override async ETTask OnEnter(FSMComponent fsmComponent)
        {
            string path = $"Assets/Scenes/Login.unity";
            await YooAssetProxy.LoadSceneAsync(path);
            await FGUIComponent.Instance.OpenAysnc(FGUIType.SelectServer);
        }
        
        public override async ETTask OnExit(FSMComponent fsmComponent)
        {
            FGUIComponent.Instance.Close(FGUIType.SelectServer);
        }
    }
}