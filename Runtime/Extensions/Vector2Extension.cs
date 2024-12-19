using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class Vector2Extension
    {
        /// <summary>
        /// 创建一个新的 Vector2，其中 x 和 y 分量都设置为指定的值
        /// </summary>
        /// <param name="value">要设置的 x 和 y 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 UniValue(float value)
        {
            return new Vector2(value, value);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 x 分量设置为指定的值，y 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="x">要设置的 x 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 SetX(this Vector2 self, float x)
        {
            return new Vector2(x, self.y);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 y 分量设置为指定的值，x 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="y">要设置的 y 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 SetY(this Vector2 self, float y)
        {
            return new Vector2(self.x, y);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 x 分量增加指定的值，y 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="x">要增加的 x 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 AddX(this Vector2 self, float x)
        {
            return new Vector2(self.x + x, self.y);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 y 分量增加指定的值，x 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="y">要增加的 y 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 AddY(this Vector2 self, float y)
        {
            return new Vector2(self.x, self.y + y);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 x 和 y 分量都增加指定的值
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="x">要增加的 x 分量的值</param>
        /// <param name="y">要增加的 y 分量的值</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 Add(this Vector2 self, float x, float y)
        {
            return new Vector2(self.x + x, self.y + y);
        }

        /// <summary>
        /// 创建一个新的 Vector2，其中 x 和 y 分量都增加另一个 Vector2 的对应分量
        /// </summary>
        /// <param name="self">原始的 Vector2 对象</param>
        /// <param name="other">要增加的 Vector2 对象</param>
        /// <returns>新的 Vector2 对象</returns>
        public static Vector2 Add(this Vector2 self, Vector2 other)
        {
            return self.Add(other.x, other.y);
        }

        /// <summary>
        /// 计算两个 Vector2 之间的平方距离
        /// </summary>
        /// <param name="self">第一个 Vector2 对象</param>
        /// <param name="other">第二个 Vector2 对象</param>
        /// <returns>两个 Vector2 之间的平方距离</returns>
        public static float Distance2(this Vector2 self, Vector2 other)
        {
            return (self - other).sqrMagnitude;
        }

        /// <summary>
        /// 计算两个 Vector2 之间的距离
        /// </summary>
        /// <param name="self">第一个 Vector2 对象</param>
        /// <param name="other">第二个 Vector2 对象</param>
        /// <returns>两个 Vector2 之间的距离</returns>
        public static float Distance(this Vector2 self, Vector2 other)
        {
            return (self - other).magnitude;
        }

        /// <summary>
        /// 将Vector2转换为Vector3，z默认为0
        /// </summary>
        /// <param name="self"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        public static Vector3 ToVector3(this Vector2 self, float z = 0)
        {
            return new Vector3(self.x, self.y, z);
        }
    }
}
