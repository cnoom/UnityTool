namespace Cnoom.UnityTool.Extensions
{
    public static class BoolExtension
    {
        public static int Int(this bool value)
        {
            return value ? 1 : 0;
        }

        public static int IntReverse(this bool value)
        {
            return value.IntReverse(1);
        }

        public static int IntReverse(this bool value, int v)
        {
            return value ? v : -1;
        }
    }
}