using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Cnoom.UnityTool.Extensions
{
    public static class TransformExtensions
    {
        public static TMono FindAdd<TMono>(this Transform self, string path) where TMono : MonoBehaviour
        {
            Transform childTransform = self.Find(path);
            return childTransform.gameObject.AddComponent<TMono>();
        }

        public static T FindGet<T>(this Transform self, string path)
        {
            Transform childTransform = self.Find(path);
            return childTransform.gameObject.GetComponent<T>();
        }

        public static T FindGetInChildren<T>(this Transform self, string path)
        {
            Transform childTransform = self.Find(path);
            return childTransform.gameObject.GetComponentInChildren<T>();
        }

        #region Children

        /// <summary>
        ///     使子物体执行某种方法
        /// </summary>
        /// <param name="self"></param>
        /// <param name="action"></param>
        /// <param name="isRecursion">是否递归使子物体的子物体们也执行该方法</param>
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
        ///     销毁所有的子物体
        /// </summary>
        /// <param name="self"></param>
        /// <param name="duration"></param>
        public static void DestroyChildren(this Transform self, float duration = 0)
        {
            self.FuncChildren(t => Object.Destroy(t.gameObject, duration));
        }

        /// <summary>
        ///     立即销毁所有的子物体
        /// </summary>
        /// <param name="self"></param>
        public static void DestroyChildrenImmediate(this Transform self)
        {
            self.FuncChildren(t => Object.DestroyImmediate(t.gameObject));
        }

        #endregion
    }
}