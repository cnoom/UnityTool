using System;
// ReSharper disable CheckNamespace
namespace CnoomUnityTool.UniUtility
{
    public class Singleton<T>
    {
        private static readonly Lazy<T> _instance = new Lazy<T>(() => Activator.CreateInstance<T>());
        
        protected Singleton()
        {
            // 防止外部直接构造实例
        }


        public static T Instance => _instance.Value;
    }
}