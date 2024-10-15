using UnityEngine;

namespace Cnoom.UnityTool.SingletonUtils
{
    public abstract class SingletonMonoBehaviour<T> : MonoBehaviour, ISingleton where T : SingletonMonoBehaviour<T>
    {
        private static T? instance;
        private static readonly object Lock = new object();
        protected bool IsDestroyOnLoad = false;
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (Lock)
                    {
                        if(instance == null)
                        {
                            instance = FindObjectOfType<T>();

                            if(FindObjectOfType<T>() == null)
                            {
                                GameObject singleton = new GameObject();
                                instance = singleton.AddComponent<T>();
                                singleton.name = typeof(T).Name + " (Singleton)";
                            }
                        }
                    }
                }

                return instance;
            }
        }

        protected virtual void Awake()
        {
            if(instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this as T;
                instance.OnSingletonInit();
                if(!IsDestroyOnLoad)
                {
                    DontDestroyOnLoad(instance);
                }
            }
        }

        protected virtual void OnDestroy()
        {
            if(instance == this)
            {
                Dispose();
            }
        }
        public virtual void Dispose()
        {
            instance = null;
        }

        public virtual void OnSingletonInit()
        {
        }
    }
}