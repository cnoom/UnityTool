using System;

namespace Cnoom.UnityTool.Extensions
{
    public static class NumberExtensions
    {
        public static float Abs(this float f)
        {
            return Math.Abs(f);
        }
        
        public static int Abs(this int f)
        {
            return Math.Abs(f);
        }

        public static long Abs(this long l)
        {
            return Math.Abs(l);
        }

        /// <summary>
        /// 将数值转换为k为单位的数值，保留两位小数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string ConvertToK(this int i)
        {
            double d = (double)i / 1000;
            return d.ToString("0.00") + "k";
        }
        
        /// <summary>
        /// 将数值转换为k为单位的数值，保留两位小数
        /// </summary>
        /// <param name="l"></param>
        /// <returns></returns>
        public static string ConvertToK(this long l)
        {
            double d = (double)l / 1000;
            return d.ToString("0.00") + "k";
        }
    }
}
