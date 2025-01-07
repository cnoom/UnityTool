using System;
using System.Collections;
using System.Collections.Generic;
using Cnoom.UnityTool.Extensions;

namespace Cnoom.UnityTool.MessageQueue
{
    /// <summary>
    /// 可以随时向后插入消息的消息队列
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MessageQueue<T> where T : IMessage
    {
        public int count => messageList.Count;
        public bool isRunning { get; private set; }

        private readonly LinkedList<T> messageList = new LinkedList<T>();
        private LinkedListNode<T> currentMessageNode;
        public Action OnFinish;

        public void Run()
        {
            isRunning = true;
            HandleMessage(messageList.First);
        }

        /// <summary>
        /// 从当前消息向后插入一条消息, 直到找到优先级小于等于他的消息停止
        /// </summary>
        /// <param name="item"></param>
        public void InsertAfter(T item)
        {
            if(currentMessageNode.Next == null)
            {
                messageList.AddLast(item);
                return;
            }
            currentMessageNode.Next.ForeachUntil(n => item.priority <= n.priority, message => { messageList.AddBefore(message, item); });
        }

        /// <summary>
        /// 排序
        /// </summary>
        public void Sort()
        {
            messageList.Sort(Comparer<T>.Create((n1, n2) => n1.priority.CompareTo(n2.priority)));
        }

        /// <summary>
        /// 添加一条消息到末尾
        /// </summary>
        /// <param name="item"></param>
        public void AddLast(T item)
        {
            messageList.AddLast(item);
        }

        public void Clear()
        {
            messageList.Clear();
        }

        public bool Contains(T item)
        {
            return messageList.Contains(item);
        }

        public bool Remove(T item)
        {
            return messageList.Remove(item);
        }

        private void HandleMessage(LinkedListNode<T> messageNode)
        {
            currentMessageNode = messageNode;
            messageNode.Value.Handle(TryNext);
        }

        private void TryNext()
        {
            if(currentMessageNode.Next == null)
            {
                isRunning = false;
                OnFinish?.Invoke();
                return;
            }
            HandleMessage(currentMessageNode.Next);
        }
    }
}