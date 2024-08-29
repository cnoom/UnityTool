// ReSharper disable CheckNamespace

using System.Collections.Generic;

namespace CnoomUnityTool.ECS
{
    /// <summary>
    /// 包含系统、实体、组件的容器
    /// </summary>
    public class World
    {
        private List<Entity> entities = new List<Entity>();

        public Entity CreateEntity()
        {
            int id = entities.Count;
            Entity entity = new Entity(id);
            entities.Add(entity);
            return entity;
        }

        public void DestroyEntity(Entity entity)
        {
            entities.Remove(entity);
        }

        public void AddComponentToEntity(Entity entity, Component component)
        {
            entity.AddComponent(component);
        }

        public List<Entity> GetEntitiesWithComponent<T>() where T : Component
        {
            List<Entity> result = new List<Entity>();
            foreach (Entity entity in entities)
            {
                if(entity.GetComponent<T>() != null)
                {
                    result.Add(entity);
                }
            }
            return result;
        }
    }
}