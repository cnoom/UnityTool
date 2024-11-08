namespace Cnoom.UnityTool.Extensions
{
    public static class BoolExtension
    {
        /// <summary>
        /// 将布尔值转换为整数。如果布尔值为 true，则返回 1；否则返回 0。
        /// </summary>
        /// <param name="value">要转换的布尔值</param>
        /// <returns>转换后的整数值</returns>
        public static int Int(this bool value)
        {
            return value? 1 : 0;
        }

        /// <summary>
        /// 将布尔值转换为整数，并进行取反操作。如果布尔值为 true，则返回 -1；否则返回 1。
        /// </summary>
        /// <param name="value">要转换的布尔值</param>
        /// <returns>转换并取反后的整数值</returns>
        public static int IntReverse(this bool value)
        {
            return value.IntReverse(1);
        }

        /// <summary>
        /// 将布尔值转换为整数，并根据指定的值进行取反操作。如果布尔值为 true，则返回指定的值；否则返回其相反数。
        /// </summary>
        /// <param name="value">要转换的布尔值</param>
        /// <param name="v">指定的值</param>
        /// <returns>转换并取反后的整数值</returns>
        public static int IntReverse(this bool value, int v)
        {
            return value? v : -v;
        }
    }
}
