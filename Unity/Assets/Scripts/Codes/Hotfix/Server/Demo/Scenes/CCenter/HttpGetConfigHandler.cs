using System.Collections.Generic;
using System.IO;
using System.Net;

namespace ET.Server
{
    [HttpHandler(SceneType.RouterManager, "/GetConfig")]
    public class HttpGetConfigHandler : IHttpHandler
    {
        public async ETTask Handle(Scene scene, HttpListenerContext context)
        {
            string ZeusBundleVersion = File.ReadAllText("../Config/ZeusBundleVersion.txt");
            string DefaultPackageBundleVersion = File.ReadAllText("../Config/DefaultPackageBundleVersion.txt");
            
            HttpGetConfigResponse response = new HttpGetConfigResponse();
            response.KV = new Dictionary<string, string>();
            response.KV.Add("LaunchDownloadUrl", "https://aftershock-2022.oss-cn-hangzhou.aliyuncs.com/HttpServer/Aftershock.apk");
            response.KV.Add("LaunchVersion", "1.0");
            response.KV.Add("BundleMainUrl", "http://192.168.1.2:8899/Bundles");
            response.KV.Add("DefaultPackageBundleVersion", DefaultPackageBundleVersion);
            response.KV.Add("ZeusBundleVersion", ZeusBundleVersion);
            HttpHelper.Response(context, response);
            await ETTask.CompletedTask;
        }
    }
}