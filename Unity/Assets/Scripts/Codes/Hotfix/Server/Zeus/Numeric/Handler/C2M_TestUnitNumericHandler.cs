// using System;
//
// namespace ET
// {
//     public class C2M_TestUnitNumericHandler: AMActorLocationRpcHandler<Unit, C2M_TestUnitNumeric, M2C_TestUnitNumeric>
//     {
//         protected override async ETTask Run(Unit unit, C2M_TestUnitNumeric request, M2C_TestUnitNumeric response, Action reply)
//         {
//             NumericComponent numericComponent = unit.GetComponent<NumericComponent>();
//             
//             int newGlod = numericComponent.GetAsInt(NumericType.Glod) + 100;
//             numericComponent.Set(NumericType.Glod, newGlod);
//                     
//             reply();
//             await ETTask.CompletedTask;
//         }
//     }
// }