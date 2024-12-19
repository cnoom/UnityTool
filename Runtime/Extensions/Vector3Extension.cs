using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class Vector3Extension
    {
        /// <summary>
        /// 创建一个新的 Vector3，其中 x、y 和 z 分量都设置为指定的值
        /// </summary>
        /// <param name="value">要设置的 x、y 和 z 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 UniValue(float value)
        {
            return new Vector3(value, value, value);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 x 分量设置为指定的值，y 和 z 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="x">要设置的 x 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 SetX(this Vector3 self, float x)
        {
            return new Vector3(x, self.y, self.z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 y 分量设置为指定的值，x 和 z 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="y">要设置的 y 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 SetY(this Vector3 self, float y)
        {
            return new Vector3(self.x, y, self.z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 z 分量设置为指定的值，x 和 y 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="z">要设置的 z 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 SetZ(this Vector3 self, float z)
        {
            return new Vector3(self.x, self.y, z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 x 分量增加指定的值，y 和 z 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="x">要增加的 x 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 AddX(this Vector3 self, float x)
        {
            return new Vector3(self.x + x, self.y, self.z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 y 分量增加指定的值，x 和 z 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="y">要增加的 y 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 AddY(this Vector3 self, float y)
        {
            return new Vector3(self.x, self.y + y, self.z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 z 分量增加指定的值，x 和 y 分量保持不变
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="z">要增加的 z 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 AddZ(this Vector3 self, float z)
        {
            return new Vector3(self.x, self.y, self.z + z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 x、y 和 z 分量都增加指定的值
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="x">要增加的 x 分量的值</param>
        /// <param name="y">要增加的 y 分量的值</param>
        /// <param name="z">要增加的 z 分量的值</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 Add(this Vector3 self, float x, float y, float z)
        {
            return new Vector3(self.x + x, self.y + y, self.z + z);
        }

        /// <summary>
        /// 创建一个新的 Vector3，其中 x、y 和 z 分量都增加另一个 Vector3 的对应分量
        /// </summary>
        /// <param name="self">原始的 Vector3 对象</param>
        /// <param name="other">要增加的 Vector3 对象</param>
        /// <returns>新的 Vector3 对象</returns>
        public static Vector3 Add(this Vector3 self, Vector3 other)
        {
            return self.Add(other.x, other.y, other.z);
        }

        /// <summary>
        /// 计算两个 Vector3 之间的平方距离
        /// </summary>
        /// <param name="self">第一个 Vector3 对象</param>
        /// <param name="other">第二个 Vector3 对象</param>
        /// <returns>两个 Vector3 之间的平方距离</returns>
        public static float Distance2(this Vector3 self, Vector3 other)
        {
            float dx = other.x - self.x;
            float dy = other.y - self.y;
            float dz = other.z - self.z;
            return dx * dx + dy * dy + dz * dz;
        }

        /// <summary>
        /// 计算两个 Vector3 之间的距离
        /// </summary>
        /// <param name="self">第一个 Vector3 对象</param>
        /// <param name="other">第二个 Vector3 对象</param>
        /// <returns>两个 Vector3 之间的距离</returns>
        public static float Distance(this Vector3 self, Vector3 other)
        {
            return Mathf.Sqrt(Distance2(self, other));
        }

        public static Vector2 ToVector2(this Vector3 self)
        {
            return new Vector2(self.x, self.y);
        }
    }
}
