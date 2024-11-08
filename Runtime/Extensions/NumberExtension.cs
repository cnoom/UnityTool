using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class NumberExtensions
    {
        /// <summary>
        /// 计算并返回指定浮点数的绝对值
        /// </summary>
        /// <param name="f">要计算绝对值的浮点数</param>
        /// <returns>浮点数的绝对值</returns>
        public static float Abs(this float f)
        {
            return Mathf.Abs(f);
        }

        /// <summary>
        /// 计算并返回指定整数的绝对值
        /// </summary>
        /// <param name="f">要计算绝对值的整数</param>
        /// <returns>整数的绝对值</returns>
        public static int Abs(this int f)
        {
            return Mathf.Abs(f);
        }
    }
}
