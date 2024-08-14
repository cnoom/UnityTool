using UnityEngine;

namespace ThirdParty.UnityTool.CnoomUnityTool.BaseUtil.Runtime
{
    public class SceneSingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lock = new object();

        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_lock)
                    {
                        if(_instance == null)
                        {
                            _instance = FindObjectOfType<T>();

                            if(FindObjectOfType<T>() == null)
                            {
                                GameObject singleton = new GameObject();
                                _instance = singleton.AddComponent<T>();
                                singleton.name = typeof(T).Name + " (Singleton)";
                            }
                        }
                    }
                }

                return _instance;
            }
        }

        protected virtual void Awake()
        {
            if(_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this as T;
            }
        }

        protected virtual void OnDestroy()
        {
            if(_instance == this)
            {
                _instance = null;
            }
        }
    }
}