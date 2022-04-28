using System.Collections.Generic;

namespace ET
{
    [ObjectSystem]
    public class SlgUnitDeserializeSystem : DeserializeSystem<SlgUnit>
    {
        public override void Deserialize(SlgUnit self)
        {
            self.AddComponent<NumericComponent>();
            Game.EventSystem.Publish(new EventType.InitSlgUnit(){SlgUnit = self});
        }
    }

    [ObjectSystem]
    public class SlgUnitAwakeSystem : AwakeSystem<SlgUnit, int, int, UnitTeam>
    {
        public override void Awake(SlgUnit self, int x, int y, UnitTeam team)
        {
            self.Data = new SlgUnitData();
            self.Data.Team = team;
            self.Data.X = x;
            self.Data.Y = y;
            self.AddComponent<NumericComponent>();
            Game.EventSystem.Publish(new EventType.InitSlgUnit(){SlgUnit = self});
        }
    }

    [ObjectSystem]
    public class SlgUnitAwakeSystem2 : AwakeSystem<SlgUnit, int, int, int>
    {
        public override void Awake(SlgUnit self, int x, int y, int unitConfigId)
        {
            SlgUnitConfig config = SlgUnitConfigCategory.Instance.Get(unitConfigId);
            self.Data = new SlgUnitData();
            self.Data.ConfigId = unitConfigId;
            self.Data.X = x;
            self.Data.Y = y;
            self.Data.Hp = config.Hp;
            self.Data.Atk = config.Atk;
            self.Data.MoveRange = config.Move;
            if (config.UnitType == 2)
            {
                self.Data.Team = UnitTeam.B;
            }
            self.SlgUnitConfig = config;
            self.AddComponent<NumericComponent>();
            Game.EventSystem.Publish(new EventType.InitSlgUnit(){SlgUnit = self});
        }
    }

    [ObjectSystem]
    public class SlgUnitAwakeSystemWithData : AwakeSystem<SlgUnit, SlgUnitData>
    {
        public override void Awake(SlgUnit self, SlgUnitData data)
        {
            self.Data = data;
            self.AddComponent<NumericComponent>();
            Game.EventSystem.Publish(new EventType.InitSlgUnit(){SlgUnit = self});
        }
    }

    public static class SlgUnitSystem
    {
        public static SlgNode GetRootNode(this SlgUnit self)
        {
            return self.Parent as SlgNode;
        }

        public static SlgActionType TryMoveUnit(this SlgNode from, SlgNode to)
        {
            var SlgComponent = from.DomainScene().GetComponent<SlgComponent>();
            var actions = SlgComponent.CheckAction(from);
            var aciton = actions[to.X][to.Y];

            if (aciton == SlgActionType.Move || aciton == SlgActionType.Attack)
            {
                var MovePaths = SlgComponent.MovePaths;
                var MovePath = MovePaths[to.X][to.Y];
                for (int i = 0; i < MovePath.SlgNodes.Count - 1; i++)
                {
                    var next = MovePath.SlgNodes[i + 1];
                    MoveUnit(MovePath.SlgNodes[i], next);
                }

                return aciton;
            }

            return SlgActionType.Empty;
        }

        public static void MoveUnit(this SlgNode from, SlgNode to)
        {
            var SlgUnit = from.GetComponent<SlgUnit>();
            from.RemoveFromComponents(SlgUnit);
            to.AddComponent(SlgUnit);
            SlgUnit.ChangeActionNum();
        }

        public static void Attack(this SlgUnit self, SlgUnit target)
        {
            List<SlgAttackResult> slgAttackResults = new List<SlgAttackResult>();
            var SlgAttackResult = new SlgAttackResult();
            SlgAttackResult.ResultType = SlgAttackResultType.Hurt;
            SlgAttackResult.Attacker = self;
            SlgAttackResult.Defender = target;

            target.Data.Hp = target.Data.Hp - self.Data.Atk;

            Game.EventSystem.Publish(new EventType.UpdateSlgUnit(){SlgUnit = target});

            slgAttackResults.Add(SlgAttackResult);
            self.DomainScene().GetComponent<SlgComponent>().SlgAttackResults = slgAttackResults;
        }

        public static void ChangeActionNum(this SlgUnit self)
        {
            self.ActionNum = 0;
            Game.EventSystem.Publish(new EventType.UpdateSlgUnit(){SlgUnit = self});
        }

        public static void ResetAction(this SlgUnit self, UnitTeam moveTeam)
        {
            self.ActionNum = self.Team == moveTeam ? 1 : 0;
        }
    }
}
