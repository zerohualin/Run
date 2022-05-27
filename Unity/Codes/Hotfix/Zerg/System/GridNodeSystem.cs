namespace ET
{
    public class GridNodeAwakeSystem: AwakeSystem<GridNode, int, int>
    {
        public override void Awake(GridNode self, int x, int y)
        {
            self.x = x;
            self.y = y;
        }
    }
}