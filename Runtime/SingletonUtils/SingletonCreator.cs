using System;
using System.Reflection;
using UnityEngine;

namespace Cnoom.UnityTool.SingletonUtils
{
    internal class SingletonCreator
    {
        public static T CreateSingleton<T>() where T : class, ISingleton
        {
            var type = typeof(T);

            var instance = CreateNonPublicConstructorObject<T>();
            instance.OnSingletonInit();
            return instance;
        }

        static T CreateNonPublicConstructorObject<T>() where T : class, ISingleton
        {
            var type = typeof(T);
            // 获取私有构造函数
            var constructorInfos = type.GetConstructors(BindingFlags.Instance | BindingFlags.NonPublic);

            // 获取无参构造函数
            var ctor = Array.Find(constructorInfos, c => c.GetParameters().Length == 0);

            if(ctor == null)
            {
                throw new Exception("Non-Public Constructor() not found! in " + type);
            }

            T result = (T)ctor.Invoke(null);
            return result; 
        }
    }
}