/** This is an automatically generated class by FairyGUI. Please do not modify it. **/

using System;
using System.Collections.Generic;
using System.Linq;
using Cfg;
using MongoDB.Bson;
using UnityEngine;
using YooAsset;

namespace ET.Client
{
    [FriendOf(typeof(Btn_RightSlash))]
    [FriendOf(typeof(FUI_SelectServer_Component))]
    [FriendOfAttribute(typeof(ET.ServerInfosComponent))]
    [FriendOfAttribute(typeof(ET.ServerInfo))]
    [FriendOfAttribute(typeof(ET.RoleInfosComponent))]
    public static class FUI_SelectServer_ComponentSystem
    {
        public static void Init(this FUI_SelectServer_Component self)
        {
        }

        public static async ETTask ShowServerInfos(this FUI_SelectServer_Component self)
        {
            List<CommonSelectCellData> list = new List<CommonSelectCellData>();

            var zoneScene = self.DomainScene();
            foreach (var serverInfo in self.DomainScene().GetComponent<ServerInfosComponent>().ServerInfos)
            {
                list.Add(new CommonSelectCellData()
                {
                    Name = serverInfo.Name,
                    Action = async () =>
                    {
                        int result = await LoginHelper.LoginZone(zoneScene, serverInfo.Zone);
                        if (result != ErrorCode.ERR_Success)
                            return;

                        result = await LoginHelper.LoginGate(zoneScene);
                        if (result != ErrorCode.ERR_Success)
                            return;

                        result = await LoginHelper.GetRoleInfos(zoneScene);
                        if (result != ErrorCode.ERR_Success)
                            return;

                        RoleInfosComponent roleInfosComponent = zoneScene.GetComponent<RoleInfosComponent>();
                        RoleInfo roleInfo = roleInfosComponent.RoleInfos.First();
                        if (roleInfo != null)
                        {
                            // await LoginHelper.DeleteRoleById(zoneScene, roleInfo.Id);
                        }
                        roleInfosComponent.CurrentRoleId = roleInfo.Id;
                        
                        await LoginHelper.EnterMap(zoneScene);
                    }
                });
            }

            EventSystem.Instance.Publish(self.ClientScene(),
                new EventType.CommonSelectListEvent() { ZoneScene = self.DomainScene(), CellDataList = list });
        }

        public static async ETTask OpenServerList(this FUI_SelectServer_Component self)
        {
            List<CommonSelectCellData> list = new List<CommonSelectCellData>();

            for (int i = 0; i < self.ServerRouters.Count; i++)
            {
                int index = i;
                list.Add(
                    new CommonSelectCellData() { Name = self.ServerRouters[i].Name, Action = () => { self.SetSelectServer(index).Coroutine(); } });
            }

            EventSystem.Instance.Publish(self.ClientScene(),
                new EventType.CommonSelectListEvent() { ZoneScene = self.DomainScene(), CellDataList = list });
        }

        public static void OpenAccountList(this FUI_SelectServer_Component self)
        {
            var accounts = LubanComponent.Instance.Tables.TbTestAccountConfig.DataList;
            List<CommonSelectCellData> list = new List<CommonSelectCellData>();
            foreach (var v in accounts)
            {
                list.Add(new CommonSelectCellData() { Name = v.Account, Action = () => { self.SetUsername(v.Account); } });
            }

            EventSystem.Instance.Publish(self.ClientScene(),
                new EventType.CommonSelectListEvent() { ZoneScene = self.DomainScene(), CellDataList = list });
        }

        public static void SetUsername(this FUI_SelectServer_Component self, string acc)
        {
            self.userNameBtn.name.text = acc;
            PlayerPrefs.SetString(LocalData.LastAccount, acc);
        }

        public static async ETTask SetSelectServer(this FUI_SelectServer_Component self, int routerIndex = 0)
        {
            if (self.ServerRouters == null)
            {
                var serverAddress = YooAssets.LoadRawFileSync("ServerAddress");
                string json = serverAddress.GetRawFileText();
                self.ServerRouters = MongoHelper.FromJson<List<ServerRouter>>(json);
            }

            ServerRouter serverRouter = self.ServerRouters[routerIndex];
            self.serverListBtn.name.text = serverRouter.Name;
            ConstValue.RouterHttpHost = serverRouter.RouterHost;
            ConstValue.RouterHttpPort = serverRouter.RouterPort;
        }

        public static async ETTask TryLogin(this FUI_SelectServer_Component self)
        {
            try
            {
                string account = self.userNameBtn.name.text;

                var loginResultCode = await LoginHelper.LoginAsync(self.DomainScene(), account, "123456");

                if (loginResultCode != ErrorCode.ERR_Success)
                {
                    Log.Error(loginResultCode.ToString());
                    return;
                }

                int getServerInfosResult = await LoginHelper.GetServerInfos(self.DomainScene());
                if (getServerInfosResult != ErrorCode.ERR_Success)
                {
                    Log.Error(loginResultCode.ToString());
                    return;
                }

                self.ShowServerInfos().Coroutine();

                self.DomainScene().GetComponent<FGUIComponent>().Close(FGUIType.SelectServer);

                // await LoginHelper.GetServerInfos(self.DomainScene());
                //
                // await LoginHelper.GetRealmKey(self.DomainScene());
                //
                // await LoginHelper.EnterGame(self.DomainScene());
                //
                // await EventSystem.Instance.PublishAsync(new EventType.LoginFinish() { ZoneScene = self.DomainScene(), LastSceneType = SceneType.Map });
            }
            catch (Exception e)
            {
                Log.Error(e);
                throw;
            }
        }
    }

    [FGUIEvent(FGUIType.SelectServer)]
    [FriendOf(typeof (FUI_SelectServer_Component))]
    [ComponentOf(typeof (FGUIEntity))]
    [FriendOf(typeof (Btn_RightSlash))]
    [FriendOf(typeof (BgGray))]
    [FriendOf(typeof (Btn_Notice))]
    public class FUI_SelectServer_ComponentEvent: FGUIEvent<FUI_SelectServer_Component>
    {
        public override void OnCreate(FUI_SelectServer_Component component)
        {
            var LastAccount = PlayerPrefs.GetString(LocalData.LastAccount);
            component.SetUsername(LastAccount);

            var lastServer = PlayerPrefs.GetInt(LocalData.LastServer);
            component.SetSelectServer(lastServer).Coroutine();

            component.userNameBtn.self.AddListener(() => { component.OpenAccountList(); });

            component.serverListBtn.self.AddListener(() => { component.OpenServerList().Coroutine(); });

            component.Btn_Bg.self.AddListener(() => { component.TryLogin().Coroutine(); });

            component.Btn_Notice.self.AddListener(() => { FGUIComponent.Instance.OpenAysnc(FGUIType.Notice).Coroutine(); });
        }

        public override void OnShow(FUI_SelectServer_Component component)
        {
        }

        public override void OnRefresh(FUI_SelectServer_Component component)
        {
        }

        public override void OnHide(FUI_SelectServer_Component component)
        {
        }

        public override void OnDestroy(FUI_SelectServer_Component component)
        {
        }
    }
}