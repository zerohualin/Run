using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.Location)]
    public class ObjectGetRequestHandler: AMActorRpcHandler<Scene, ObjectGetRequest, ObjectGetResponse>
    {
        protected override async ETTask Run(Scene scene, ObjectGetRequest request, ObjectGetResponse response)
        {
            LocationOneType locationOneType = scene.GetComponent<LocationManagerComoponent>().Get(request.Type);
            long instanceId = await locationOneType.Get(request.Key);
            response.InstanceId = instanceId;
        }
    }
}