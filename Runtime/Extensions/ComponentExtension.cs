using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class ComponentExtension
    {
        /// <summary>
        /// 获取或添加指定类型的组件到当前组件所在的游戏对象上
        /// </summary>
        /// <typeparam name="T">要获取或添加的组件类型</typeparam>
        /// <param name="self">当前组件</param>
        /// <returns>获取或添加的组件</returns>
        public static T GetOrAddComponent<T>(this Component self) where T : Component
        {
            // 尝试获取当前组件所在的游戏对象上的指定类型组件
            T component = self.GetComponent<T>();

            // 如果没有找到该组件
            if(component == null)
            {
                // 则在当前游戏对象上添加该组件
                component = self.gameObject.AddComponent<T>();
            }
            // 返回获取或添加的组件
            return component;
        }
    }
}