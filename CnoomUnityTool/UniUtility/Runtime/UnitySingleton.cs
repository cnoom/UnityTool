
using UnityEngine;

namespace CnoomUnityTool.ThirdParty.UnityTool.CnoomUnityTool.UniUtility.Runtime
{
    public abstract class UnitySingleton<T> : MonoBehaviour where T : UnitySingleton<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    // 查找场景中是否存在该类型的对象实例
                    _instance = FindObjectOfType<T>();
                    if (_instance == null)
                    {
                        // 如果没有找到，则创建一个新的GameObject并附加此单例脚本
                        var instanceObject = new GameObject(typeof(T).Name);
                        _instance = instanceObject.AddComponent<T>();
                        DontDestroyOnLoad(instanceObject); // 确保单例在场景切换时不被销毁
                    }
                }
                return _instance;
            }
        }
    
        protected virtual void Awake()
        {
            // 确保只有一个实例存在
            if (_instance != null && _instance != this)
            {
                Debug.LogError($"Trying to instantiate a second instance of singleton {typeof(T)}!");
                Destroy(gameObject);
                return;
            }
            _instance = (T)this;
        }

        // 可根据需要在此处添加对Update, OnDestroy等Unity生命周期方法的支持
    }
}