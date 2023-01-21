using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.ChatInfo)]
    public class G2Chat_RequestExitChatHandler: AMActorRpcHandler<ChatInfoUnit, G2Chat_RequestExitChat, Chat2G_ResponseExitChat>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, G2Chat_RequestExitChat request, Chat2G_ResponseExitChat response, Action reply)
        {
            ChatInfoUnitsComponent chatInfoUnitsComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitsComponent>();
            chatInfoUnitsComponent.Remove(chatInfoUnit.Id);
            reply();
            await ETTask.CompletedTask;
        }
    }
}