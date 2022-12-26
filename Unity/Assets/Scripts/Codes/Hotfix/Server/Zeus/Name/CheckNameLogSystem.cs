namespace ET
{
    public class CheckNameLogDestroySystem : DestroySystem<CheckNameLog>
    {
        protected override void Destroy(CheckNameLog self)
        {
            self.Name = default;
            self.UnitId = default;
            self.CreateTime = default;
        }
    }

    public static class CheckNameLogSystem
    {
    
    }
}
