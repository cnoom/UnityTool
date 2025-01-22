﻿using System;
using System.Collections.Generic;
using System.Linq;
using Random = UnityEngine.Random;

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
        
        /// <summary>
        /// 随机排序
        /// </summary>
        /// <param name="self"></param>
        /// <typeparam name="T"></typeparam>
        public static void Shuffle<T>(this ICollection<T> self)
        {
            System.Random rand = new System.Random();
            T[] array = self.ToArray();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                int r = i + rand.Next(n - i);
                (array[r], array[i]) = (array[i], array[r]);
            }
            self.Clear();
            foreach (T item in array)
            {
                self.Add(item);
            }
        }
    }
}