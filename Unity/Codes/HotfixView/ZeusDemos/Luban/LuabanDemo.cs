using Cfg;

namespace ET
{
    public class LubanDemo: AEvent<EventType.LubanDemoStart>
    {
        protected override void Run(EventType.LubanDemoStart args)
        {
            var item = ConfigUtil.Tables.TbItem.Get(1);
            Log.Debug(item.ToString());
        }
    }
}