﻿using System;

namespace ET.Server
{
    [ActorMessageHandler(SceneType.ChatInfo)]
    [FriendOfAttribute(typeof(ET.Server.ChatInfoUnitsComponent))]
    public class C2Chat_SendChatInfoHandler : AMActorRpcHandler<ChatInfoUnit, C2Chat_SendChatInfo, Chat2C_SendChatInfo>
    {
        protected override async ETTask Run(ChatInfoUnit chatInfoUnit, C2Chat_SendChatInfo request, Chat2C_SendChatInfo response)
        {
            if (string.IsNullOrEmpty(request.ChatMessage))
            {
                response.Error = ErrorCode.ERR_ChatMessageEmpty;
                return;
            }

            ChatInfoUnitsComponent chatInfoUnitsComponent = chatInfoUnit.DomainScene().GetComponent<ChatInfoUnitsComponent>();
            foreach (var otherUnit in chatInfoUnitsComponent.ChatInfoUnitDict.Values)
            {
                MessageHelper.SendActor(otherUnit.GateSessionActorId,
                    new Chat2C_NoticeChatInfo() { Name = chatInfoUnit.Name, ChatMessage = request.ChatMessage, UnitId = chatInfoUnit.Id });
            }
            
            await ETTask.CompletedTask;
        }
    }
}