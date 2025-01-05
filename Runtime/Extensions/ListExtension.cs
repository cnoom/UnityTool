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
        /// 根据指定条件移除列表中的元素。
        /// </summary>
        /// <typeparam name="T">列表中元素的类型。</typeparam>
        /// <param name="list">要操作的列表。</param>
        /// <param name="condition">用于确定是否应移除元素的条件。</param>
        /// <returns>移除了符合条件元素后的新列表。</returns>
        public static List<T> RemoveByCondition<T>(this List<T> list, Func<T,  bool> condition)
        {
            // 创建一个新的列表来存储元素
            List<T> listToRemove = new List<T>(list);

            // 遍历原始列表中的每个元素
            foreach (T item in list)
            {
                // 如果元素符合条件，则将其添加到移除列表中
                if (condition(item))
                {
                    listToRemove.Remove(item);
                }
            }
            // 返回移除了符合条件元素后的新列表
            return listToRemove;
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

        /// <summary>
        /// 克隆列表并返回新的列表。
        /// </summary>
        public static List<T> Clone<T>(this List<T> list)
        {
            return new List<T>(list);
        }
    }
}
