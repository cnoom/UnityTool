using System;
using Newtonsoft.Json;

namespace Cnoom.UnityTool.StorageUtils
{
    public static class PlayerPrefsExtension
    {
        public static void SaveObject(this IPlayerPrefsUser storageUser, string key, object value, bool isSave = true, params JsonConverter[] converters)
        {
            TryGetPlayerPrefsStorage().SaveObject(storageUser.GetKey(key), value, isSave, converters);
        }

        public static T GetObject<T>(this IPlayerPrefsUser storageUser, string key, T defaultValue = default, params JsonConverter[] converters)
        {
            return TryGetPlayerPrefsStorage().LoadObject(storageUser.GetKey(key), defaultValue, converters);
        }

        private static PlayerPrefsStorage TryGetPlayerPrefsStorage()
        {
            if(IStorage.Current == null)
                throw new NullReferenceException("IStorage.Current is null");
            if(IStorage.Current is PlayerPrefsStorage storage)
            {
                return storage;
            }
            throw new NullReferenceException("IStorage.Current is not PlayerPrefsStorage");
        }
    }
}