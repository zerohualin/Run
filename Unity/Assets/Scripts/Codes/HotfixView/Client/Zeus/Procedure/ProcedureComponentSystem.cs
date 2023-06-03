namespace ET.Client
{
    [ObjectSystem]
    public class ProcedureComponentAwakeSystem: AwakeSystem<ProcedureComponent>
    {
        protected override void Awake(ProcedureComponent self)
        {
            FSMComponent fsmComponent = self.AddComponent<FSMComponent>();
            fsmComponent.AddState<Procedure_Login>();
            fsmComponent.AddState<Procedure_Loding>();
            fsmComponent.AddState<Procedure_Map>();
            fsmComponent.Init<Procedure_Login>();
        }
    }
    [FriendOfAttribute(typeof(ET.Client.ProcedureComponent))]
    public static class ProcedureComponentSystem
    {
        public static async ETTask StartLoadMapScene(this ProcedureComponent self, string targetMap)
        {
            self.TargetMap = targetMap;
            self.GetComponent<FSMComponent>().Post(FSMAct.ToLoading);
            
            string path = $"Assets/Scenes/{self.TargetMap}.unity";
            await TimerComponent.Instance.WaitAsync(1000);
            await YooAssetProxy.LoadSceneAsync(path);
            
            self.IsFinishLoadMapScene = true;
            self.GetComponent<FSMComponent>().Post(FSMAct.TryFinishLoading);
        }
        
        public static void FinishCreateUnits(this ProcedureComponent self)
        {
            self.IsFinishCreateMyUnit = true;
            self.GetComponent<FSMComponent>().Post(FSMAct.TryFinishLoading);
        }
    }
}
