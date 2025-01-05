using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Cnoom.UnityTool.Extensions
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// 尝试从字典中获取指定键的值，并将其转换为指定的子类型。
        /// </summary>
        /// <typeparam name="T1">字典键的类型。</typeparam>
        /// <typeparam name="T2">字典值的类型。</typeparam>
        /// <typeparam name="T3">要转换为的值的类型，必须是 T2 的子类型。</typeparam>
        /// <param name="dictionary">要搜索的字典。</param>
        /// <param name="key">要搜索的键。</param>
        /// <param name="value">如果找到键，则返回转换后的值；否则返回默认值。</param>
        /// <returns>如果找到键并成功转换，则返回 true；否则返回 false。</returns>
        public static bool TryGetValueAsChild<T1, T2, T3>(this Dictionary<T1, T2> dictionary, T1 key, out T3 value) where T3 : T2
        {
            // 尝试从字典中获取指定键的值
            if (dictionary.TryGetValue(key, out T2 v))
            {
                // 如果找到键，则将值转换为指定的子类型
                value = (T3)v;
                // 返回 true 表示转换成功
                return true;
            }
            // 如果没有找到键，则将默认值赋给 out 参数
            value = default;
            // 返回 false 表示没有找到键或转换失败
            return false;
        }

        public static Dictionary<T1, T2> Clone<T1, T2>(this Dictionary<T1, T2> dictionary)
        {
            return dictionary.ToDictionary(item => item.Key, item => item.Value);
        }
    }
}
