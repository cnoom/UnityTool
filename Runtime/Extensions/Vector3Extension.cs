using UnityEngine;

namespace Cnoom.UnityTool.Extensions
{
    public static class Vector3Extension
    {
        public static Vector3 UniValue(float value)
        {
            return new Vector3(value, value, value);
        }

        public static Vector3 SetX(this Vector3 self, float x)
        {
            return new Vector3(x, self.y, self.z);
        }

        public static Vector3 SetY(this Vector3 self, float y)
        {
            return new Vector3(self.x, y, self.z);
        }

        public static Vector3 SetZ(this Vector3 self, float z)
        {
            return new Vector3(self.x, self.y, z);
        }

        public static Vector3 AddX(this Vector3 self, float x)
        {
            return new Vector3(self.x + x, self.y, self.z);
        }

        public static Vector3 AddY(this Vector3 self, float y)
        {
            return new Vector3(self.x, self.y + y, self.z);
        }

        public static Vector3 AddZ(this Vector3 self, float z)
        {
            return new Vector3(self.x, self.y, self.z + z);
        }
    }
}