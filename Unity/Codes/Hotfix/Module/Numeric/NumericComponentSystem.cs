using System.Collections.Generic;

namespace ET
{
    public class NumericComponentDestroySystem : DestroySystem<NumericComponent>
    {
        public override void Destroy(NumericComponent self)
        {
            self.NumericDic.Clear();
            self.OriNumericDic.Clear();
        }
    }
    
    [FriendClass(typeof (NumericComponent))]
    public static class NumericComponentSystem
    {
        public static float GetAsFloat(this NumericComponent self, int numericType)
        {
            return (float)self.GetByKey(numericType) / 10000;
        }

        public static int GetAsInt(this NumericComponent self, int numericType)
        {
            return (int)self.GetByKey(numericType);
        }

        public static long GetAsLong(this NumericComponent self, int numericType)
        {
            return self.GetByKey(numericType);
        }
        
        public static long Get(this NumericComponent self, int numericType)
        {
            return self.GetByKey(numericType);
        }

        public static void Set(this NumericComponent self, int nt, float value)
        {
            self.Insert(nt, (int)(value * 10000));
        }

        public static void Set(this NumericComponent self, int nt, int value)
        {
            self.Insert(nt, value);
        }

        public static void Set(this NumericComponent self, int nt, long value)
        {
            self.Insert(nt, value);
        }

        public static void SetNoEvent(this NumericComponent self, int numericType, long value)
        {
            self.Insert(numericType, value, false);
        }

        public static void Insert(this NumericComponent self, int numericType, long value, bool isPublicEvent = true)
        {
            long oldValue = self.GetByKey(numericType);
            if (oldValue == value)
            {
                return;
            }

            self.NumericDic[numericType] = value;

            if (numericType >= NumericType.Max)
            {
                self.Update(numericType, isPublicEvent);
                return;
            }

            if (isPublicEvent)
            {
                EventType.NumbericChange args = EventType.NumbericChange.Instance;
                args.Parent = self.Parent;
                args.NumericType = numericType;
                args.Old = oldValue;
                args.New = value;
                Game.EventSystem.PublishClass(args);
            }
        }

        public static long GetByKey(this NumericComponent self, int key)
        {
            long value = 0;
            self.NumericDic.TryGetValue(key, out value);
            return value;
        }

        public static void Update(this NumericComponent self, int numericType, bool isPublicEvent)
        {
            int final = (int)numericType / 10;
            int bas = final * 10 + 1;
            int add = final * 10 + 2;
            int pct = final * 10 + 3;
            int finalAdd = final * 10 + 4;
            int finalPct = final * 10 + 5;

            // 一个数值可能会多种情况影响，比如速度,加个buff可能增加速度绝对值100，也有些buff增加10%速度，所以一个值可以由5个值进行控制其最终结果
            // final = (((base + add) * (100 + pct) / 100) + finalAdd) * (100 + finalPct) / 100;
            long result = (long)(((self.GetByKey(bas) + self.GetByKey(add)) * (100 + self.GetAsFloat(pct)) / 100f + self.GetByKey(finalAdd)) *
                (100 + self.GetAsFloat(finalPct)) / 100f);
            self.Insert(final, result, isPublicEvent);
        }
        
        public static void InitOriNumerDic(this NumericComponent self)
        {
            self.OriNumericDic = new Dictionary<int, long>(self.NumericDic);
        }

        public static float GetOriData(this NumericComponent self, int numericType)
        {
            return self.OriNumericDic[numericType];
        }
        
        public static Dictionary<int, long> GetOriNum(this NumericComponent self)
        {
            return self.OriNumericDic;
        }
    }
}