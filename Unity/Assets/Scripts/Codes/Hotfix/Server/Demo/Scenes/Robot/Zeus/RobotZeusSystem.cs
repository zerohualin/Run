using System;
using System.Collections.Generic;

namespace ET.Server
{
    public static class RobotCaseZeusSystem
    {
        // 创建机器人，生命周期是RobotCase
        public static async ETTask NewZeusRobot(this RobotCase self, int count, List<Scene> scenes)
        {
            ETTask[] tasks = new ETTask[count];
            for (int i = 0; i < count; ++i)
            {
                tasks[i] = self.NewZeusRobot(scenes);
            }

            await ETTaskHelper.WaitAll(tasks);
        }
        
        private static async ETTask NewZeusRobot(this RobotCase self, List<Scene> scenes)
        {
            try
            {
                scenes.Add(await self.NewZeusRobot());
            }
            catch (Exception e)
            {
                Log.Error(e);
            }
        }
        
        private static async ETTask<Scene> NewZeusRobot(this RobotCase self)
        {
            int zone = self.GetParent<RobotCaseComponent>().GetN();
            Scene clientScene = null;

            try
            {
                clientScene = await Client.SceneFactory.CreateClientScene(zone, $"Robot_{zone}");
                // string account = $"Jan_{RandomGenerator.RandInt32()}";
                string account = "Jan001";
                await Client.LoginHelper.LoginAsync(clientScene, account, "123456");
                Log.Debug($"create robot ok: {zone}");
                self.Scenes.Add(clientScene.Id);
                return clientScene;
            }
            catch (Exception e)
            {
                clientScene?.Dispose();
                throw new Exception($"RobotCase create robot fail, zone: {zone}", e);
            }
        }
    }
}