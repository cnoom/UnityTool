namespace Cnoom.UnityTool.LogUtils
{
    public interface ILog
    {
        void Log(string message);
        
        void Warning(string message);
        
        void Error(string message);
        
        static ILog Current { get; set; } = new SimpleLog();
    }
}