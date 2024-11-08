namespace Cnoom.UnityTool.SingletonUtils
{
    public interface ISingletonMono : ISingleton
    {
        bool IsDestroyOnLoad { get; }
    }
}