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

            self.AddSpotLight(new AreaData() { StartPosX = 30, StartPosY = 30, Width = 30, Height = 30 });

            self.AddBarrier(new AreaData() { StartPosX = 20, StartPosY = 20, Width = 5, Height = 5 });
            
            self.AddMineral(new AreaData() { StartPosX = 40, StartPosY = 40, Width = 5, Height = 3 });

            var BaseCampConfig = Game.Scene.GetComponent<LubanComponent>().Tables.TbBuilding.Get("BD000001");
            self.AddBuild(new AreaData() { StartPosX = 30, StartPosY = 30, Width = BaseCampConfig.Size.X, Height = BaseCampConfig.Size.Y }, BaseCampConfig);
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

        public static void AddBuild(this GridGroundComponent self, AreaData area, BuildingConfig config)
        {
            Building building = self.AddChild<Building, int, int, BuildingConfig>(area.StartPosX, area.StartPosY, config);
            for (int _x = area.StartPosX; _x <= area.EndPosX; _x++)
            {
                for (int _y = area.StartPosY; _y <= area.EndPosY; _y++)
                {
                    var node = self.GridData[_x][_y];
                    node.BuildingId = building.InstanceId;
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                    self.UpdateVision(node, config.Field);
                }
            }
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
                    node.AddComponent<GroundBarrierComponent>();
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                }
            }
        }

        public static void AddMineral(this GridGroundComponent self, AreaData area)
        {
            for (int _x = area.StartPosX; _x <= area.EndPosX; _x++)
            {
                for (int _y = area.StartPosX; _y <= area.EndPosY; _y++)
                {
                    var node = self.GridData[_x][_y];
                    node.AddComponent<GroundMineralComponent>();
                    Game.EventSystem.Publish(new EventType.UpdateGridNode() { Node = node });
                }
            }
        }

        public static void UpdateVision(this GridGroundComponent self, GridNode centerNode, AreaSize AreaSize)
        {
            int x = centerNode.x;
            int y = centerNode.y;

            for (int _x = x - AreaSize.X; _x <= x + AreaSize.X; _x++)
            {
                for (int _y = y - AreaSize.Y; _y <= y + AreaSize.Y; _y++)
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
    }
}