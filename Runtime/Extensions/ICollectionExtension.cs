using System.Collections.Generic;
using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class ICollectionExtension
    {
        public static T RandomElement<T>(this ICollection<T> self)
        {
            T[] arr = new T[self.Count];
            self.CopyTo(arr, 0);
            return arr[Random.Range(0, arr.Length)];
        }
    }
}