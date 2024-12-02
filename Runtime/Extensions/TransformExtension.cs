using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cnoom.UnityTool.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// 在子物体中查找物体并添加组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <typeparam name="TMono"></typeparam>
        /// <returns></returns>
        public static TMono FindAdd<TMono>(this Transform self, string path) where TMono : MonoBehaviour
        {
            // 在当前Transform的子物体中查找指定路径的子物体
            Transform childTransform = self.Find(path);
            // 如果找到了子物体，则在该子物体上添加指定类型的组件，并返回该组件
            if (childTransform!= null)
            {
                return childTransform.gameObject.AddComponent<TMono>();
            }
            // 如果没有找到子物体，则返回null
            return null;
        }


        /// <summary>
        /// 在子物体中查找物体并获取组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindGet<T>(this Transform self, string path)
        {
            // 在当前Transform的子物体中查找指定路径的子物体
            Transform childTransform = self.Find(path);
            // 如果找到了子物体，则返回该子物体上的指定类型的组件
            if (childTransform!= null)
            {
                return childTransform.gameObject.GetComponent<T>();
            }
            // 如果没有找到子物体，则返回null
            return default(T);
        }

        /// <summary>
        /// 在子物体及其子物体中查找物体并获取组件
        /// </summary>
        /// <param name="self"></param>
        /// <param name="path"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindGetInChildren<T>(this Transform self, string path)
        {
            // 在当前Transform的子物体中查找指定路径的子物体
            Transform childTransform = self.Find(path);
            // 如果找到了子物体，则返回该子物体或其任何子物体上的指定类型的组件
            if (childTransform!= null)
            {
                return childTransform.gameObject.GetComponentInChildren<T>();
            }
            // 如果没有找到子物体，则返回null
            return default(T);
        }


        #region Children

        /// <summary>
        /// 对当前Transform的所有子物体执行指定的操作
        /// </summary>
        /// <param name="self">当前Transform对象</param>
        /// <param name="action">要执行的操作</param>
        /// <param name="isRecursion">是否递归执行操作</param>
        public static void FuncChildren(this Transform self, Action<Transform> action, bool isRecursion = false)
        {
            foreach (Transform child in self)
            {
                action.Invoke(child);
                if(isRecursion)
                {
                    child.FuncChildren(action, true);
                }
            }
        }

        /// <summary>
        /// 销毁当前Transform的所有子物体，可以指定延迟时间
        /// </summary>
        /// <param name="self">当前Transform对象</param>
        /// <param name="duration">延迟销毁的时间</param>
        public static void DestroyChildren(this Transform self, float duration = 0)
        {
            self.FuncChildren(t => Object.Destroy(t.gameObject, duration));
        }

        /// <summary>
        /// 立即销毁当前Transform的所有子物体
        /// </summary>
        /// <param name="self">当前Transform对象</param>
        public static void DestroyChildrenImmediate(this Transform self)
        {
            self.FuncChildren(t => Object.DestroyImmediate(t.gameObject));
        }

        #endregion

        #region Parent
        /// <summary>
        /// 在当前Transform的父物体中查找指定标签的物体
        /// </summary>
        /// <param name="current"></param>
        /// <param name="tag"></param>
        /// <param name="includeSelf"></param>
        /// <returns></returns>
        public static Transform FindParentWithTag(this Transform current, string tag,bool includeSelf = false)
        {
            if(includeSelf)
            {
                if (current.CompareTag(tag))
                {
                    return current;
                }    
            }
            
            if (current.parent == null)
            {
                return null;
            }
            return current.parent.FindParentWithTag(tag);
        }
        #endregion
    }
}