// using System;
//
// namespace ET
// {
//     public static class ChatHelper
//     {
//         public static async ETTask<int> SendMessage(Scene ClientScene, string Msg)
//         {
//             if (string.IsNullOrEmpty(Msg))
//             {
//                 return ErrorCode.ERR_ChatMessageEmpty;
//             }
//
//             Chat2C_SendChatInfo chat2CSendChatInfo = null;
//
//             try
//             {
//                 chat2CSendChatInfo = (Chat2C_SendChatInfo)await ClientScene.GetComponent<SessionComponent>().Session
//                         .Call(new C2Chat_SendChatInfo() { ChatMessage = Msg });
//             }
//             catch (Exception e)
//             {
//                 Log.Error(e.ToString());
//                 return ErrorCode.ERR_NetworkError;
//             }
//
//             if (chat2CSendChatInfo.Error != ErrorCode.ERR_Success)
//                 return chat2CSendChatInfo.Error;
//             
//             return ErrorCode.ERR_Success;
//         }
//     }
// }