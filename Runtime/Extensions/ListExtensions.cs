using System;
using System.Collections.Generic;
using System.Linq;

namespace Cnoom.UnityTool.Extensions
{
    public static class ListExtensions
    {
        /// <summary>
        ///     筛选出满足条件的集合
        /// </summary>
        /// <param name="list"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> FindByCondition<T>(this List<T> list, Func<T, bool> condition)
        {
            return list.Where(condition).ToList();
        }

        /// <summary>
        ///     筛选出满足条件的第一个物体
        /// </summary>
        /// <param name="list"></param>
        /// <param name="condition"></param>
        /// <param name="defaultValue">默认值</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FindByConditionSingle<T>(this List<T> list, Func<T, bool> condition, T defaultValue = default)
        {
            T item = list.SingleOrDefault(condition);
            return item == null ? defaultValue : item;
        }
    }
}