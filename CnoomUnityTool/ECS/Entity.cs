// ReSharper disable CheckNamespace

using System.Collections.Generic;

namespace CnoomUnityTool.ECS
{
    /// <summary>
    /// 实体
    /// </summary>
    public class Entity
    {
        public int ID { get; private set; }
        
        private readonly Dictionary<System.Type, Component> components = new Dictionary<System.Type, Component>();

        public Entity(int id)
        {
            ID = id;
        }
        
        public void AddComponent(Component component)
        {
            components[component.GetType()] = component;
        }
        
        public T GetComponent<T>() where T : Component
        {
            if (components.ContainsKey(typeof(T)))
            {
                return (T)components[typeof(T)];
            }
            return null;
        }
    }
}