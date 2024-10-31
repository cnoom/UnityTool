using System;

namespace Cnoom.UnityTool.Extensions
{
    public static class ArrayExtension
    {
        /// <summary>
        /// 清空数组中的所有元素，将它们设置为默认值
        /// </summary>
        /// <param name="array">要清空的数组</param>
        public static void Clear<T>(this T[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
        }

        /// <summary>
        /// 将数组中的所有元素设置为指定的值
        /// </summary>
        /// <param name="array">要设置值的数组</param>
        /// <param name="value">要设置的值</param>
        public static void UniValue<T>(this T[] array,T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
        /// <summary>
        /// 随机获取数组中的元素
        /// </summary>
        /// <param name="array"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Random<T>(this T[] array)
        {
            return array[UnityEngine.Random.Range(0, array.Length)];
        }
    }
}
