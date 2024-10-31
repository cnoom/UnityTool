using System;
using System.Collections.Generic;
using System.Linq;

namespace Cnoom.UnityTool.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        /// 根据指定条件查找列表中的元素，并返回符合条件的元素列表。
        /// </summary>
        /// <typeparam name="T">列表中元素的类型。</typeparam>
        /// <param name="list">要搜索的列表。</param>
        /// <param name="condition">用于确定是否应包含元素的条件。</param>
        /// <returns>符合条件的元素列表。</returns>
        public static List<T> FindByCondition<T>(this List<T> list, Func<T, bool> condition)
        {
            return list.Where(condition).ToList();
        }
        
        /// <summary>
        /// 根据指定条件查找列表中的单个元素，如果未找到则返回默认值。
        /// </summary>
        /// <typeparam name="T">列表中元素的类型。</typeparam>
        /// <param name="list">要搜索的列表。</param>
        /// <param name="condition">用于确定是否应包含元素的条件。</param>
        /// <param name="defaultValue">如果未找到符合条件的元素，则返回此默认值。</param>
        /// <returns>符合条件的单个元素，如果未找到则返回默认值。</returns>
        public static T FindByConditionSingle<T>(this List<T> list, Func<T, bool> condition, T defaultValue = default)
        {
            T item = list.SingleOrDefault(condition);
            return item == null? defaultValue : item;
        }
        
        /// <summary>
        /// 从列表中随机返回一个元素。
        /// </summary>
        /// <typeparam name="T">列表中元素的类型。</typeparam>
        /// <param name="list">要搜索的列表。</param>
        /// <returns>随机选择的元素。</returns>
        public static T RandomElement<T>(this List<T> list)
        {
            return list[UnityEngine.Random.Range(0, list.Count)];
        }
    }
}
