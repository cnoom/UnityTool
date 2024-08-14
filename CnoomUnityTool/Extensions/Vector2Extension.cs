using UnityEngine;

namespace CnoomUnityTool.Extensions
{
    public static class Vector2Extension
    {
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

    }
}