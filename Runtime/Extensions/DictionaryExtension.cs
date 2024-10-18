using System.Collections;
using System.Collections.Generic;

namespace Cnoom.UnityTool.Extensions
{
    public static class DictionaryExtension
    {
        /// <summary>
        /// 获取字典值的子类(减少转换代码)
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <typeparam name="T3"></typeparam>
        /// <returns></returns>
        public static bool TryGetValueAsChild<T1,T2,T3>(this Dictionary<T1,T2> dictionary, T1 key,out T3 value) where T3 : T2
        {
            if(dictionary.TryGetValue(key, out T2 v))
            {
                value = (T3)v;
                return true;
            }
            value = default;
            return false;
        }
    }
}