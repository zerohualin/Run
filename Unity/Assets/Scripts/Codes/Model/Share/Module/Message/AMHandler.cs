using System;

namespace ET
{
    public abstract class AMHandler<Message>: IMHandler where Message : class
    {
        protected abstract ETTask Run(Session session, Message message);

        public void Handle(Session session, object msg)
        {
            Message message = msg as Message;
            if (message == null)
            {
                Log.Error($"消息类型转换错误: {msg.GetType().FullName} to {typeof (Message).FullName}");
                return;
            }

            if (session.IsDisposed)
            {
                Log.Error($"session disconnect {msg}");
                return;
            }

            this.Run(session, message).Coroutine();
        }

        public Type GetMessageType()
        {
            return typeof (Message);
        }

        public Type GetResponseType()
        {
            return null;
        }
    }
}