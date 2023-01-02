using MongoDB.Bson;

namespace ET.Client
{
    public static class UnitSystem
    {
        public static async ETTask SayHi(this Unit unit, long targetId, string msg)
        {
            M2C_SayHi m = (M2C_SayHi)await unit.ClientScene().GetComponent<SessionComponent>().Session
                    .Call(new C2M_SayHi() { TargetId = targetId, Msg = msg });
            Log.Info(m.ToJson());
        }

        public static Unit GetUnit(this Entity entity)
        {
            Entity p = entity.Parent;

            while (p != null)
            {
                if (p is Unit)
                {
                    return p as Unit;
                }
                p = p.Parent;
            }

            return null;
        }
    }
}