namespace Cnoom.UnityTool.LogUtils
{
    public static class LogExtensions
    {
        public static void LogMessage(this object ob, string message)
        {
            ILog.Current.Log($"{ob.GetType().Name} : {message}");
        }

        public static void LogWarning(this object ob, string message)
        {
            ILog.Current.Warning($"{ob.GetType().Name} : {message}");
        }

        public static void LogError(this object ob, string message)
        {
            ILog.Current.Error($"{ob.GetType().Name} : {message}");
        }
    }
}