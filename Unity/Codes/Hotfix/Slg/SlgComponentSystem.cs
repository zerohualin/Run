using System.Collections;
using System.Collections.Generic;
using System.IO;
using TiledSharp;
using UnityEngine;

namespace ET
{
    [ObjectSystem]
    public class SlgComponentAwakeSystem : AwakeSystem<SlgComponent>
    {
        public override async void Awake(SlgComponent self)
        {
            self.AddComponent<SlgUnitComponent>();
            // self.Init(2, 2);
            TiledComponent tiledComponent = Game.Scene.GetComponent<TiledComponent>();
            var tiledMap = await tiledComponent.LoadMap("test");
            // var tileSet = await tiledComponent.LoadTileset("tiles");
            self.InitWithTiled(tiledMap);
            Game.EventSystem.Publish(new EventType.InitSlgComponent() { SlgComponent = self });
        }
    }

    [ObjectSystem]
    public class SlgComponentAwakeSystemWithData : AwakeSystem<SlgComponent, SlgData>
    {
        public override void Awake(SlgComponent self, SlgData slgData)
        {
            self.Data = slgData;

            self.Nodes = new SlgNode[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                self.Nodes[i] = new SlgNode[self.MapHeight];

            for (int i = 0; i < self.Data.SlgMapData.NodeDatas.Count; i++)
            {
                var data = self.Data.SlgMapData.NodeDatas[i];
                var node = self.AddChild<SlgNode, SlgNodeData>(data);
                self.Nodes[data.X][data.Y] = node;
            }

            SlgUnitComponent slgUnitComponent = self.AddComponent<SlgUnitComponent>();
            for (int i = 0; i < self.Data.SlgUnitDatas.Count; i++)
            {
                var data = self.Data.SlgUnitDatas[i];
                var unit = self.Nodes[data.X][data.Y].AddComponent<SlgUnit, SlgUnitData>(data);
                slgUnitComponent.Add(unit);
            }

            Game.EventSystem.Publish(new EventType.InitSlgComponent() { SlgComponent = self });
        }
    }

    [ObjectSystem]
    public class SlgComponentDeserializeSystem : DeserializeSystem<SlgComponent>
    {
        public override void Deserialize(SlgComponent self)
        {
            var SlgUnitComponent = self.AddComponent<SlgUnitComponent>();
            self.Nodes = new SlgNode[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                self.Nodes[i] = new SlgNode[self.MapHeight];

            foreach (var vaEntity in self.Children)
            {
                var node = vaEntity.Value as SlgNode;
                if (node != null)
                {
                    self.Nodes[node.X][node.Y] = node;
                }

                var unit = vaEntity.Value.GetComponent<SlgUnit>();
                if (unit != null)
                {
                    SlgUnitComponent.Add(unit);
                }
            }

            Game.EventSystem.Publish(new EventType.InitSlgComponent() { SlgComponent = self });
        }
    }

    public static class SlgComponentSystem
    {
        public static void Init(this SlgComponent self, int inX, int inY)
        {
            self.Data = new SlgData();
            self.Data.SlgMapData = new SlgMapData();
            self.Data.SlgMapData.MapWidth = inX;
            self.Data.SlgMapData.MapHeight = inY;

            self.Nodes = new SlgNode[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                self.Nodes[i] = new SlgNode[self.MapHeight];

            for (int x = 0; x < self.MapWidth; x++)
            {
                for (int y = 0; y < self.MapHeight; y++)
                {
                    var node = self.AddChild<SlgNode, int, int>(x, y);
                    self.Nodes[x][y] = node;
                }
            }

            self.InitRound();
            self.AddUnit(0, 0, UnitTeam.A);
            self.AddUnit(1, 1, UnitTeam.B);
            self.NextRound();
        }

        public static void InitWithTiled(this SlgComponent self, TmxMap tiledMap)
        {
            self.Data = new SlgData();
            self.Data.SlgMapData = new SlgMapData();
            self.Data.SlgMapData.MapWidth = tiledMap.Width;
            self.Data.SlgMapData.MapHeight = tiledMap.Height;

            self.Nodes = new SlgNode[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                self.Nodes[i] = new SlgNode[self.MapHeight];
            
            for (int x = 0; x < self.MapWidth; x++)
            {
                for (int y = 0; y < self.MapHeight; y++)
                {
                    string SlgGroundTypeStr = tiledMap.GetTilePropertie(x, y, "Ground", "Grounds", "GroundType");
                    SlgGroundType slgGroundType = SlgGroundType.Normal;
                    if (SlgGroundTypeStr == "2")
                        slgGroundType = SlgGroundType.Hole;
                    var data = new SlgNodeData() { X = x, Y = y, SlgGroundType = slgGroundType };
                    var node = self.AddChild<SlgNode, SlgNodeData>(data);
                    self.Nodes[x][y] = node;

                    // string UnitTeamStr = tiledMap.GetTilePropertie(x, y, "Unit", "Units", "UnitTeam");
                    // int unitTeamId = int.Parse(UnitTeamStr);
                    // if (unitTeamId == 1)
                    // { 
                    //     self.AddUnit(x, y, UnitTeam.A);
                    // }
                    // if (unitTeamId == 2)
                    // { 
                    //     self.AddUnit(x, y, UnitTeam.B);
                    // }
                    
                    string UnitIdStr = tiledMap.GetTilePropertie(x, y, "Unit", "Units", "UnitId");
                    if (UnitIdStr != "0")
                    {
                        int unitId = int.Parse(UnitIdStr);
                        self.AddUnit(x, y, unitId);
                    }

                }
            }

            self.InitRound();
            self.NextRound();
        }

        public static SlgNode GetNode(this SlgComponent self, int x, int y)
        {
            return self.Nodes[x][y];
        }

        public static bool IsInMap(this SlgComponent self, int x, int y)
        {
            if (x < 0 || y < 0)
                return false;
            if (x >= self.MapWidth || y >= self.MapHeight)
                return false;
            return true;
        }

        public static SlgActionType[][] CheckAction(this SlgComponent self, SlgNode start)
        {
            SlgActionType[][] checkedNode = new SlgActionType[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                checkedNode[i] = new SlgActionType[self.MapHeight];

            var unit = start.GetComponent<SlgUnit>();
            if (unit == null)
            {
                Log.Error("Unit怎么会空呢？");
                return null;
            }

            if (unit.ActionNum == 0)
                return checkedNode;

            int maxRange = unit.MoveRange;

            List<SlgNode> nextList = new List<SlgNode>();
            nextList.Add(start);

            int checkRound = 1;
            checkedNode[start.X][start.Y] = SlgActionType.Self;

            List<SlgVector> slgVectors = new List<SlgVector>();
            slgVectors.Add(new SlgVector() { X = -1, Y = 0 });
            slgVectors.Add(new SlgVector() { X = 1, Y = 0 });
            slgVectors.Add(new SlgVector() { X = 0, Y = -1 });
            slgVectors.Add(new SlgVector() { X = 0, Y = 1 });

            self.MovePaths = new SlgMovePath[self.MapWidth][];
            for (int i = 0; i < self.MapWidth; i++)
                self.MovePaths[i] = new SlgMovePath[self.MapHeight];

            self.MovePaths[start.X][start.Y] = new SlgMovePath();
            self.MovePaths[start.X][start.Y].SlgNodes.Add(start);

            while (checkRound <= maxRange)
            {
                checkRound = checkRound + 1;
                List<SlgNode> tempNextList = new List<SlgNode>();
                for (int i = 0; i < nextList.Count; i++)
                {
                    for (int j = 0; j < slgVectors.Count; j++)
                    {
                        var centerNode = nextList[i];
                        var vector = slgVectors[j];
                        int nextX = centerNode.X + vector.X;
                        int nextY = centerNode.Y + vector.Y;
                        var inMap = self.IsInMap(nextX, nextY);
                        if (!inMap)
                            continue;

                        var roundNum = checkedNode[nextX][nextY];
                        if (roundNum > 0)
                            continue;

                        var nextNode = self.Nodes[nextX][nextY];
                        var action = centerNode.CheckAction(start, nextNode);

                        if (action == SlgActionType.Move || action == SlgActionType.Teammate)
                        {
                            tempNextList.Add(nextNode);
                        }

                        if (action == SlgActionType.Move || action == SlgActionType.Attack ||
                            action == SlgActionType.Teammate)
                        {
                            self.SetPath(centerNode, nextNode, action);
                        }

                        checkedNode[nextX][nextY] = action;
                    }
                }

                nextList = tempNextList;
            }

            return checkedNode;
        }

        public static void SetPath(this SlgComponent self, SlgNode start, SlgNode next,
            SlgActionType action = SlgActionType.Move)
        {
            var lastPath = self.MovePaths[start.X][start.Y];
            var nextPath = new SlgMovePath();
            nextPath.SlgNodes = new List<SlgNode>();
            for (int i = 0; i < lastPath.SlgNodes.Count; i++)
            {
                nextPath.SlgNodes.Add(lastPath.SlgNodes[i]);
            }

            if (action == SlgActionType.Move)
                nextPath.SlgNodes.Add(next);
            self.MovePaths[next.X][next.Y] = nextPath;
        }

        public static void InitRound(this SlgComponent self)
        {
            self.MoveTeam = UnitTeam.B;
            self.RoundNum = 0;
        }

        public static void TryNextRound(this SlgComponent self)
        {
        }

        public static void NextRound(this SlgComponent self)
        {
            self.RoundNum = self.RoundNum + 1;
            self.MoveTeam = self.MoveTeam == UnitTeam.A ? UnitTeam.B : UnitTeam.A;

            SlgUnitComponent slgUnitComponent = self.GetComponent<SlgUnitComponent>();
            slgUnitComponent.ResetAction(self.MoveTeam);

            Game.EventSystem.Publish(new EventType.UpdateSlgRound()
            {
                SlgComponent = self
            });
        }
        
        public static void AddUnit(this SlgComponent self, int x, int y, UnitTeam team)
        {
            var unitNodeA = self.GetNode(x, y);
            var unit = unitNodeA.AddComponent<SlgUnit, int, int, UnitTeam>(x, y, team);
            self.GetComponent<SlgUnitComponent>().Add(unit);
        }

        public static void AddUnit(this SlgComponent self, int x, int y, int unitId)
        {
            var unitNodeA = self.GetNode(x, y);
            var unit = unitNodeA.AddComponent<SlgUnit, int, int, int>(x, y, unitId);
            self.GetComponent<SlgUnitComponent>().Add(unit);
        }
    }
}