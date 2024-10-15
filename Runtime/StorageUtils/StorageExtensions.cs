
using System;

namespace Cnoom.UnityTool.StorageUtils
{
    public static class StorageExtensions
    {

        #region private

        private static string GetKey(this IStorageUser storageUser, string key)
        {
            return storageUser.GetType().FullName + key;
        }

        private static IStorage TryGetStorageUtil()
        {
            if(IStorage.Current != null) return IStorage.Current;
            throw new NullReferenceException("IStorage.Current is null");
        }

        #endregion

        #region 获取

        public static int GetInt(this IStorageUser storageUser, string key, int defaultValue = default)
        {
            return TryGetStorageUtil().LoadInt(storageUser.GetKey(key), defaultValue);
        }

        public static float GetFloat(this IStorageUser storageUser, string key, float defaultValue = default)
        {
            return TryGetStorageUtil().LoadFloat(storageUser.GetKey(key), defaultValue);
        }

        public static string GetString(this IStorageUser storageUser, string key, string defaultValue = "")
        {
            return TryGetStorageUtil().LoadString(storageUser.GetKey(key), defaultValue);
        }

        public static T GetObject<T>(this IStorageUser storageUser, string key, T defaultValue = default)
        {
            return TryGetStorageUtil().LoadObject(storageUser.GetKey(key), defaultValue);
        }

        #endregion

        #region 保存

        public static void SaveInt(this IStorageUser storageUser, string key, int value, bool isSave = true)
        {
            TryGetStorageUtil().SaveInt(storageUser.GetKey(key), value, isSave);
        }

        public static void SaveFloat(this IStorageUser storageUser, string key, float value, bool isSave = true)
        {
            TryGetStorageUtil().SaveFloat(storageUser.GetKey(key), value, isSave);
        }

        public static void SaveString(this IStorageUser storageUser, string key, string value, bool isSave = true)
        {
            TryGetStorageUtil().SaveString(storageUser.GetKey(key), value, isSave);
        }

        public static void SaveObject(this IStorageUser storageUser, string key, object value, bool isSave = true)
        {
            TryGetStorageUtil().SaveObject(storageUser.GetKey(key), value, isSave);
        }

        #endregion

        public static void Delete(this IStorageUser storageUser, string key)
        {
            TryGetStorageUtil().Delete(storageUser.GetKey(key));
        }
    }
}