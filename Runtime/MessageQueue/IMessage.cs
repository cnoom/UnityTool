using System;
using System.Diagnostics.CodeAnalysis;

namespace Cnoom.UnityTool.MessageQueue
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public interface IMessage
    {
        int priority { get; }

        void Handle([NotNull] Action onFinish);

        /// <summary>
        /// 创建消息
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="onFinish"></param>
        /// <returns></returns>
        public static IMessage Create(int priority, Action<Action> onFinish)
        {
            return Message.CreateInstance(priority, onFinish);
        }

        /// <summary>
        /// 创建简单的消息，不会等待
        /// </summary>
        /// <param name="priority"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IMessage Create(int priority, Action action)
        {
            return SimpleMessage.CreateInstance(priority,action);
        }
        
        private record SimpleMessage : IMessage
        {
            public int priority { get; }
            private readonly Action action;
            
            private SimpleMessage(int i, Action action)
            {
                this.action = action;
                priority = i;
            }
            
            public static SimpleMessage CreateInstance(int priority,Action action)
            {
                return new SimpleMessage(priority,action);
            }

            public void Handle(Action onFinish)
            {
                action();
                onFinish();
            }
        }

        private record Message : IMessage
        {

            public int priority { get; }
            private readonly Action<Action> action;
            
            private Message(int priority, [NotNull] Action<Action> action)
            {
                this.priority = priority;
                this.action = action;
            }

            public static Message CreateInstance(int priority, Action<Action> action)
            {
                return new Message(priority, action);
            }

            public void Handle(Action onFinish)
            {
                action(onFinish);
            }
        }
    }
}