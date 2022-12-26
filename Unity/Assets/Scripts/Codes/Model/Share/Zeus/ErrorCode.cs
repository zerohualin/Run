namespace ET
{
    public static partial class ErrorCode
    {
        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        // 110000 以上，避免跟SocketError冲突
        public const int ERR_MyErrorCode = 110000;

        public const int ERR_KcpConnectTimeout = 100205;
        public const int ERR_PeerDisconnect = 100208;
        public const int ERR_SocketCantSend = 100209;
        public const int ERR_SocketError = 100210;
        public const int ERR_KcpWaitSendSizeTooLarge = 100211;
        public const int ERR_KcpCreateError = 100212;
        public const int ERR_SendMessageNotFoundTChannel = 100213;
        public const int ERR_TChannelRecvError = 100214;
        public const int ERR_MessageSocketParserError = 100215;
        public const int ERR_KcpNotFoundChannel = 100216;

        public const int ERR_WebsocketSendError = 100217;
        public const int ERR_WebsocketPeerReset = 100218;
        public const int ERR_WebsocketMessageTooBig = 100219;
        public const int ERR_WebsocketRecvError = 100220;

        public const int ERR_KcpReadNotSame = 100230;
        public const int ERR_KcpSplitError = 100231;
        public const int ERR_KcpSplitCountError = 100232;

        public const int ERR_ActorNoMailBoxComponent = 110003;
        public const int ERR_ActorLocationSenderTimeout = 110004;
        public const int ERR_PacketParserError = 110005;
        public const int ERR_KcpChannelAcceptTimeout = 110206;
        public const int ERR_KcpRemoteDisconnect = 110207;
        public const int ERR_WebsocketError = 110303;
        public const int ERR_WebsocketConnectError = 110304;
        public const int ERR_RpcFail = 110307;
        public const int ERR_ReloadFail = 110308;
        public const int ERR_ConnectGateKeyError = 110309;
        public const int ERR_SessionSendOrRecvTimeout = 110311;
        public const int ERR_OuterSessionRecvInnerMessage = 110312;
        public const int ERR_NotFoundActor = 110313;
        public const int ERR_ActorTimeout = 110315;
        public const int ERR_UnverifiedSessionSendMessage = 110316;
        public const int ERR_ActorLocationSenderTimeout2 = 110317;
        public const int ERR_ActorLocationSenderTimeout3 = 110318;
        public const int ERR_ActorLocationSenderTimeout4 = 110319;
        public const int ERR_ActorLocationSenderTimeout5 = 110320;

        public const int ERR_KcpRouterTimeout = 110401;
        public const int ERR_KcpRouterTooManyPackets = 110402;
        public const int ERR_KcpRouterSame = 110403;
        
        //-----------------------------------
        // 小于这个Rpc会抛异常，大于这个异常的error需要自己判断处理，也就是说需要处理的错误应该要大于该值
        public const int ERR_Repeatedly = 199999;
        public const int ERR_Exception = 200000;
        public const int ERR_Cancel = 200001;
        public const int ERR_NetworkError = 200002;
        public const int ERR_LoginInfoIsNull = 200003;
        public const int ERR_AccountNameFormError = 200004;
        public const int ERR_PasswordFormError = 200005;
        public const int ERR_AccountInBlackListError = 200006;
        public const int ERR_LoginPasswordError = 200007;
        public const int ERR_RequestRepeatedly = 200008;
        public const int ERR_TokenError = 200009;

        public const int ERR_RoleNameIsNum = 200010;
        public const int ERR_RoleNameUsed = 200011;
        public const int ERR_RoleNotExit = 200012;

        public const int ERR_RequestSceneTypeError = 200013;

        public const int ERR_OtherAccountLogin = 200014;
        public const int ERR_NoneSessionPlayer = 200015;
        public const int ERR_NonePlayer = 200016;
        public const int ERR_SessionStateError = 200017;
        public const int ERR_ReEnterGameError = 200018;
        public const int ERR_EnterGameError = 200019;

        public const int ERR_ChatMessageEmpty = 200020;

        public const int ERR_RoomNotExit = 200021;
        
        
        public const int ERR_Login_RealmAdressError = 201001;
        public const int ERR_Login_AccountNotExits = 201002;
        public const int ERR_Login_PasswordWrong = 201003;
        public const int ERR_Login_AccountOrPasswordWrongFormat = 201004;
        public const int ERR_Login_RepeatLogin = 201005;
        public const int ERR_Login_NotLogin = 201006;
        public const int ERR_Login_AccountNotLogin = 201007;
        public const int ERR_Login_ZoneNotExist = 201008;
        public const int ERR_Login_NoLoginGateInfo = 201009;
        public const int ERR_Login_MultiLogin = 201010;
        public const int ERR_Login_NoGateUser = 201011;
        public const int ERR_Login_NoneAccountZone = 201012;
        public const int ERR_Login_NoName = 201013;
        public const int ERR_Login_NoneCheckName = 201014;
        public const int ERR_Login_NameRepeated = 201015;
        public const int ERR_Login_NoRole = 201016;
        public const int ERR_Login_NoRoleDB = 201017;
        public const int ERR_Login_RoleNotExits = 201018;
        public const int ERR_Login_RoleInMap = 201019;
        public static bool IsRpcNeedThrowException(int error)
        {
            if (error == 0)
            {
                return false;
            }

            // ws平台返回错误专用的值
            if (error == -1)
            {
                return false;
            }

            if (error > ERR_Exception)
            {
                return false;
            }

            return true;
        }

        public static bool IsTargetNotOnline(this int error)
        {
            if (error == ERR_NotFoundActor)
            {
                return true;
            }

            return false;
        }

        // 1-11004 是SocketError请看SocketError定义
        //-----------------------------------
        // 100000-109999是Core层的错误
        
        // 110000以下的错误请看ErrorCore.cs
        
        // 这里配置逻辑层的错误码
        // 110000 - 200000是抛异常的错误
        // 200001以上不抛异常
    }
}