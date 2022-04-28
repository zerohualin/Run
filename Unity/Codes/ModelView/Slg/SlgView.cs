namespace ET
{
    public class SlgView : Entity, IAwake<SlgComponent>, IDestroy
    {
        public SlgComponent SlgComponent;
        public SlgNode SelectedNode = null;
    }
}
