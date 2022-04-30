namespace ET
{
    public class AddressableComponent: Entity, IAwake
    {
        public static AddressableComponent Instance { get; set; }
        public bool initialize = false;
        public void Awake()
        {
            if (Instance != null)
            {
                Log.Error("错误！重复添加Addressable加载组件");
            }
            else
            {
                Instance = this;
                Log.Info("添加Addressable加载组件");
            }
        }
    }
}