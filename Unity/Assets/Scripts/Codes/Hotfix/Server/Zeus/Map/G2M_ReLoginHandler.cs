using System.Collections.Generic;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Map)]
    public class G2M_ReLoginHandler : AMActorLocationHandler<Unit, G2M_ReLogin>
    {
        protected override async ETTask Run(Unit unit, G2M_ReLogin message)
        {
            M2C_CreateMyUnit m2CCreateMyUnit = new M2C_CreateMyUnit();
            m2CCreateMyUnit.Unit = UnitHelper.CreateUnitInfo(unit);
            MessageHelper.SendToClient(unit, m2CCreateMyUnit);
            
            M2C_CreateUnits createUnits = new M2C_CreateUnits() { Units = new List<UnitInfo>() };

            Dictionary<long, AOIEntity> units = unit.GetSeeUnits();
            foreach (var VARIABLE in units)
            {
                createUnits.Units.Add(UnitHelper.CreateUnitInfo(VARIABLE.Value.GetParent<Unit>()));
            }
            MessageHelper.SendToClient(unit, createUnits);
            
            await ETTask.CompletedTask;
        }
    }
}