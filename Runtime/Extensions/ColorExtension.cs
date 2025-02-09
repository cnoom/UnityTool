using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class ColorExtension
    {
        public static Color SetAlpha(this Color self, float alpha)
        {
            return new Color(self.r, self.g, self.b, alpha);
        }

        public static Color SetR(this Color self, float red)
        {
            return new Color(red, self.g, self.b, self.a);
        }

        public static Color SetG(this Color self, float green)
        {
            return new Color(self.r, green, self.b, self.a);
        }

        public static Color SetB(this Color self, float blue)
        {
            return new Color(self.r, self.g, blue, self.a);
        }

        public static string ToHex(this Color self)
        {
            // 将颜色的RGB值从0 - 1范围转换为0 - 255范围，并转换为整数
            int r = Mathf.RoundToInt(self.r * 255f);
            int g = Mathf.RoundToInt(self.g * 255f);
            int b = Mathf.RoundToInt(self.b * 255f);
            int a = Mathf.RoundToInt(self.a * 255f);
            // 使用ToString("X2")将整数转换为两位的十六进制字符串
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", r, g, b, a);
        }

    }
}