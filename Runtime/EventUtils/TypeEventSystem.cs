using System;
using System.Collections.Generic;
using Cnoom.UnityTool.SingletonUtils;

namespace Cnoom.UnityTool.EventUtils
{
    /// <summary>
    /// 触发事件基类,可以在里面添加参数
    /// </summary>
    public class EventArgBase
    {

    }

    // 定义一个弱引用委托，用于在事件处理程序中避免强引用导致的内存泄漏
    class WeakAction<TEventArgs> where TEventArgs : EventArgBase
    {
        private readonly WeakReference targetRef;
        private readonly Action<TEventArgs> action;

        public WeakAction(Action<TEventArgs> action)
        {
            this.action = action;
            targetRef = new WeakReference(action.Target);
        }

        public void Invoke(TEventArgs eventArgs)
        {
            if(targetRef.IsAlive)
            {
                ((Action<TEventArgs>)targetRef.Target)(eventArgs);
            }
            else
            {
                // 对象已被回收，可以自动取消订阅
                TypeEventSystem.Instance.Unsubscribe<TEventArgs>(action);
            }
        }
    }

    // 事件系统的单例类，用于管理事件的订阅和触发
    public class TypeEventSystem : Singleton<TypeEventSystem>, IEventSystem
    {
        private Dictionary<Type, List<Delegate>> eventHandlers = new Dictionary<Type, List<Delegate>>();

        private TypeEventSystem()
        {
        }

        // 订阅事件
        public void Subscribe<TEventArgs>(Action<TEventArgs> handler) where TEventArgs : EventArgBase
        {
            var eventType = typeof(TEventArgs);
            if(!eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType] = new List<Delegate>();
            }
            var weakHandler = new WeakAction<TEventArgs>(handler);
            eventHandlers[eventType].Add(new Action<TEventArgs>(weakHandler.Invoke));
        }

        // 取消订阅
        public void Unsubscribe<TEventArgs>(Action<TEventArgs> handler) where TEventArgs : EventArgBase
        {
            var eventType = typeof(TEventArgs);
            if(eventHandlers.ContainsKey(eventType))
            {
                eventHandlers[eventType].Remove(handler);
                if(eventHandlers[eventType].Count == 0)
                {
                    eventHandlers.Remove(eventType);
                }
            }
        }

        // 触发事件
        public void TriggerEvent<TEventArgs>(TEventArgs eventArgs) where TEventArgs : EventArgBase
        {
            var eventType = typeof(TEventArgs);
            if(eventHandlers.ContainsKey(eventType))
            {
                // 创建一个副本列表，以避免在遍历和触发过程中可能出现的并发修改异常
                var handlersCopy = new List<Delegate>(eventHandlers[eventType]);
                foreach (var handler in handlersCopy)
                {
                    ((Action<TEventArgs>)handler)(eventArgs);
                }
            }
        }
    }
}
