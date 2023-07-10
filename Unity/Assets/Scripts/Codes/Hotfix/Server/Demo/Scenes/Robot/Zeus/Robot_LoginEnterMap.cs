using System;

namespace ET.Server
{
    [Invoke(RobotCaseType.LoginEnterMap)]
    public class RobotCase_LoginEnterMap: ARobotCase
    {
        protected override async ETTask Run(RobotCase robotCase)
        {
            Log.Console("RobotZeus LoginEnterMap Start");
            using ListComponent<Scene> robots = ListComponent<Scene>.Create();
            
            await robotCase.NewZeusRobot(1, robots);

            foreach (Scene robotScene in robots)
            {
                M2C_TestRobotCase response = await robotScene.GetComponent<Client.SessionComponent>().Session.Call(new C2M_TestRobotCase() {N = robotScene.Zone}) as M2C_TestRobotCase;
                if (response.N != robotScene.Zone)
                {
                    throw new Exception($"robot case: {RobotCaseType.FirstCase} run fail!");
                }
            }
            Log.Console("RobotZeus LoginEnterMap End");
        }
    }
}