namespace Cnoom.UnityTool.Extensions
{
    public static class BoolExtension
    {
        public static int Int(this bool value)
        {
            return value ? 1 : 0;
        }
    }
}