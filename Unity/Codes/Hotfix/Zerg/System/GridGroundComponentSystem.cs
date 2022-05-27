namespace ET
{
    [ObjectSystem]
    public class GridGroundComponentAwakeSystem: AwakeSystem<GridGroundComponent, int, int>
    {
        public override void Awake(GridGroundComponent self, int w, int h)
        {
            self.Width = w;
            self.Height = h;
            self.GridData = new GridNode[self.Width][];
            for (int i = 0; i < self.GridData.Length; i++)
            {
                self.GridData[i] = new GridNode[self.Height];
            }

            for (int x = 0; x < self.GridData.Length; x++)
            {
                for (int y = 0; y < self.GridData[x].Length; y++)
                {
                    self.GridData[x][y] = self.AddChild<GridNode, int, int>(x, y);
                    if (x > 40 && x < 60)
                    {
                        self.GridData[x][y].CanView = true;
                    }

                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = self.GridData[x][y] });
                }
            }
        }
    }

    public static class GridGroundComponentSystem
    {
        public static void AddBuild(this GridGroundComponent self, int x, int y)
        {
            var node = self.GridData[x][y];
            if (!node.CanView)
                return;
            node.Builded = true;
            int range = 3;
            for (int _x = x - range; _x <= x + range; _x++)
            {
                for (int _y = y - range; _y <= y + range; _y++)
                {
                    if (_x < 0 || _x > self.Width - 1 || _y < 0 || _y > self.Height)
                    {
                    }
                    else
                    {
                        if (!self.GridData[_x][_y].CanView)
                        {
                            self.GridData[_x][_y].CanView = true;
                            Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = self.GridData[_x][_y] });
                        }
                    }
                }
            }
            Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
        }

        public static void ChangeGround(this GridGroundComponent self, int x, int y)
        {
            var node = self.GridData[x][y];
            if (!node.CanView)
                return;
            node.Builded = true;
            node.CanView = true;
            Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
        }
    }
}