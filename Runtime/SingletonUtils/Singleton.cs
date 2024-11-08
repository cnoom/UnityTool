namespace Cnoom.UnityTool.SingletonUtils
{
    public class Singleton<T> : ISingleton where T : Singleton<T>
    {

        #region Properties
        
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    lock (singletonLock)
                    {
                        if(instance == null)
                        {
                            instance = SingletonCreator.CreateSingleton<T>();
                            instance.OnSingletonInit();
                        }
                    }
                }

                return instance;
            }
        }

        #endregion

        public void Dispose()
        {

            instance = default;
        }

        public virtual void OnSingletonInit()
        {
        }
        #region Fields

        private static T instance;
        /// <summary>
        ///     线程锁
        /// </summary>
        private static readonly object singletonLock = new object();

        #endregion
    }
}