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

        void Handle([NotNull]Action onFinish);
    }
}