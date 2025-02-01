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
    }
}