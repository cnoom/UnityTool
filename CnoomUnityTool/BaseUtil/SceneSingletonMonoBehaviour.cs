using UnityEngine;
// ReSharper disable CheckNamespace
namespace CnoomUnityTool.BaseUtil
{
    public class SceneSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;
        // ReSharper disable once StaticMemberInGenericType
        private static readonly object Lock = new object();

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
            }
        }

        protected virtual void OnDestroy()
        {
            if(instance == this)
            {
                instance = null;
            }
        }
    }
}