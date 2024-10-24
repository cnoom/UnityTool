using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class Vector2Extension
    {
        public static Vector2 UniValue(float value)
        {
            return new Vector2(value, value);
        }

        public static Vector2 SetX(this Vector2 self, float x)
        {
            return new Vector2(x, self.y);
        }

        public static Vector2 SetY(this Vector2 self, float y)
        {
            return new Vector2(self.x, y);
        }


        public static Vector2 AddX(this Vector2 self, float x)
        {
            return new Vector2(self.x + x, self.y);
        }

        public static Vector2 AddY(this Vector2 self, float y)
        {
            return new Vector2(self.x, self.y + y);
        }

        public static float Distance2(this Vector2 self, Vector2 other)
        {
            float dx = other.x - self.x;
            float dy = other.y - self.y;
            return dx * dx + dy * dy;
        }
    }
}