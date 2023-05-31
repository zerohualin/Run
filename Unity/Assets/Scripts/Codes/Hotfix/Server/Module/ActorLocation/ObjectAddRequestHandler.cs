using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Location)]
    public class ObjectAddRequestHandler: AMActorRpcHandler<Scene, ObjectAddRequest, ObjectAddResponse>
    {
        protected override async ETTask Run(Scene scene, ObjectAddRequest request, ObjectAddResponse response)
        {
            LocationOneType locationOneType = scene.GetComponent<LocationManagerComoponent>().Get(request.Type);
            await locationOneType.Add(request.Key, request.InstanceId);
        }
    }
}