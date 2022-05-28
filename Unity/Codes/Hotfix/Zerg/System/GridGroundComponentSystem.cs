using Cfg.zerg;

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
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = self.GridData[x][y] });
                }
            }

            self.AddSpotLight(new AreaData() { StartPosX = 30, StartPosY = 30, Width = 20, Height = 20 });

            self.AddBarrier(new AreaData() { StartPosX = 35, StartPosY = 35, Width = 5, Height = 5 });

            var BaseCampConfig = Game.Scene.GetComponent<LubanComponent>().Tables.TbCardConfig.Get(1);
            self.AddBuild(new AreaData() { StartPosX = 30, StartPosY = 30, Width = BaseCampConfig.Width, Height = BaseCampConfig.Height }, BaseCampConfig);
        }
    }

    public static class GridGroundComponentSystem
    {
        public static GridNode GetNode(this GridGroundComponent self, int x, int y)
        {
            if (x >= self.Width || x < 0 || y >= self.Height || y < 0)
            {
                return null;
            }

            return self.GridData[x][y];
        }

        public static void AddBuild(this GridGroundComponent self, AreaData area, CardConfig data)
        {
            for (int _x = area.StartPosX; _x <= area.EndPosX; _x++)
            {
                for (int _y = area.StartPosY; _y <= area.EndPosY; _y++)
                {
                    var node = self.GridData[_x][_y];
                    node.IsBuilded = true;
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                    self.UpdateVision(node, data.Vision);
                }
            }

            self.AddChild<Building, int, int, CardConfig>(area.StartPosX, area.StartPosY, data);
        }

        public static void AddSpotLight(this GridGroundComponent self, AreaData area)
        {
            for (int _x = area.StartPosX; _x <= area.EndPosX; _x++)
            {
                for (int _y = area.StartPosX; _y <= area.EndPosY; _y++)
                {
                    var node = self.GridData[_x][_y];
                    node.CanView = true;
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                }
            }
        }

        public static void AddBarrier(this GridGroundComponent self, AreaData area)
        {
            for (int _x = area.StartPosX; _x <= area.EndPosX; _x++)
            {
                for (int _y = area.StartPosX; _y <= area.EndPosY; _y++)
                {
                    var node = self.GridData[_x][_y];
                    node.AddChild<GroundBarrierComponent>();
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                }
            }
        }

        public static void UpdateVision(this GridGroundComponent self, GridNode centerNode, int range)
        {
            int x = centerNode.x;
            int y = centerNode.y;

            for (int _x = x - range; _x <= x + range; _x++)
            {
                for (int _y = y - range; _y <= y + range; _y++)
                {
                    if (_x < 0 || _x >= self.Width || _y < 0 || _y >= self.Height)
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
        }

        public static void ChangeGround(this GridGroundComponent self, int x, int y)
        {
            var node = self.GridData[x][y];
            if (!node.CanView)
                return;
            node.IsBuilded = true;
            node.CanView = true;
            Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
        }
    }
}