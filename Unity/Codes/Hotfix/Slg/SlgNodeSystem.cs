using System;
using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class SlgNodeDeserialize : DeserializeSystem<SlgNode>
    {
        public override void Deserialize(SlgNode self)
        {
            Game.EventSystem.PublishAsync(new EventType.InitSlgNode() { SlgNode = self }).Coroutine();
        }
    }
    
    [ObjectSystem]
    public class SlgNodeAwakeSystem : AwakeSystem<SlgNode, int, int>
    {
        public override void Awake(SlgNode self, int x, int y)
        {
            self.SlgNodeData = new SlgNodeData();
            self.SlgNodeData.X = x;
            self.SlgNodeData.Y = y;
            self.SlgNodeData.SlgGroundType = SlgGroundType.Normal;
            Game.EventSystem.PublishAsync(new EventType.InitSlgNode() { SlgNode = self }).Coroutine();
        }
    }
    
    [ObjectSystem]
    public class SlgNodeAwakeSystemWithData : AwakeSystem<SlgNode, SlgNodeData>
    {
        public override void Awake(SlgNode self, SlgNodeData data)
        {
            self.SlgNodeData = data;
            Game.EventSystem.PublishAsync(new EventType.InitSlgNode() { SlgNode = self }).Coroutine();
        }
    }

    public static class SlgNodeSystem
    {
        public static SlgUnit GetUnit(this SlgNode self)
        {
            var unit = self.GetComponent<SlgUnit>();
            return unit;
        }

        public static SlgNode GetRandomMove(this SlgNode self)
        {
            var SlgComponent = self.DomainScene().GetComponent<SlgComponent>();
            SlgActionType[][] actions = SlgComponent.CheckAction(self);
            List<SlgNode> moves = new List<SlgNode>();
            for (int i = 0; i < actions.Length; i++)
            {
                var length = actions[i].Length;
                for (int j = 0; j < length; j++)
                {
                    if (actions[i][j] == SlgActionType.Move)
                    {
                        moves.Add(SlgComponent.GetNode(i, j));
                    }
                }
            }
            
            if(moves.Count == 0)
                return null;

            return moves.RandomArray();
        }

        public static SlgActionType CheckAction(this SlgNode self, SlgNode start, SlgNode other)
        {
            if (other.SlgGroundType == SlgGroundType.Hole)
                return SlgActionType.CannotMove;

            var startUnit = start.GetComponent<SlgUnit>();
            var otherUnit = other.GetComponent<SlgUnit>();

            if (startUnit != null && otherUnit != null)
            {
                if (startUnit.Team == otherUnit.Team)
                    return SlgActionType.Teammate;
                return SlgActionType.Attack;
            }

            return SlgActionType.Move;
        }
    }
}