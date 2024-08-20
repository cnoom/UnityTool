// ReSharper disable CheckNamespace

using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CnoomUnityTool.Extensions
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

        public static void FuncChildren(this Transform self, Action<Transform> action)
        {
            foreach (Transform child in self)
            {
                action.Invoke(child);
            }
        }

        public static void DestroyChildren(this Transform self, float duration = 0)
        {
            self.FuncChildren(t => Object.Destroy(t.gameObject, duration));
        }

        public static void DestroyChildrenImmediate(this Transform self)
        {
            self.FuncChildren(t => Object.DestroyImmediate(t.gameObject));
        }

        #endregion
    }
}