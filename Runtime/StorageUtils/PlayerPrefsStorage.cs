using Newtonsoft.Json;
using UnityEngine;
namespace Cnoom.UnityTool.StorageUtils
{
    public class PlayerPrefsStorage : IStorage
    {
        #region 数据保存

        public void SaveInt(string key, int value, bool isSave = true)
        {
            PlayerPrefs.SetInt(key, value);
            TrySave(isSave);
        }

        public void SaveFloat(string key, float value, bool isSave = true)
        {
            PlayerPrefs.SetFloat(key, value);
            TrySave(isSave);
        }

        public void SaveString(string key, string value, bool isSave = true)
        {
            PlayerPrefs.SetString(key, value);
            TrySave(isSave);
        }

        public void SaveObject(string key, object value, bool isSave = true)
        {
            SaveObject(key, value, isSave,null);
        }

        public void SaveObject(string key, object value, bool isSave = true, params JsonConverter[] converters)
        {
            string json = JsonConvert.SerializeObject(value,converters);
            SaveString(key, json, isSave);
        }

        private void TrySave(bool isSave)
        {
            if(isSave)
            {
                PlayerPrefs.Save();
            }
        }

        #endregion

        #region 数据读取
    
        public int LoadInt(string key, int defaultValue = 0)
        {
            if(!PlayerPrefs.HasKey(key))
            {
                return defaultValue;
            }
            return PlayerPrefs.GetInt(key, defaultValue);
        }

        public float LoadFloat(string key, float defaultValue = 0f)
        {
            if(!PlayerPrefs.HasKey(key))
            {
                return defaultValue;
            }
            return PlayerPrefs.GetFloat(key, defaultValue);
        }

        public string LoadString(string key, string defaultValue = null)
        {
            if(!PlayerPrefs.HasKey(key))
            {
                return defaultValue;
            }
            return PlayerPrefs.GetString(key, defaultValue);
        }

        public T LoadObject<T>(string key, T defaultValue = default)
        {
            string json = PlayerPrefs.GetString(key);
            if(string.IsNullOrEmpty(json))
            {
                return defaultValue;
            }
            return JsonConvert.DeserializeObject<T>(json);
        }

        public T LoadObject<T>(string key, T defaultValue = default, params JsonConverter[] converters)
        {
            string json = PlayerPrefs.GetString(key);
            if(string.IsNullOrEmpty(json))
            {
                return defaultValue;
            }
            return JsonConvert.DeserializeObject<T>(json,converters);
        }

        #endregion

        #region 数据清理
    
        public void Delete(string key)
        {
            PlayerPrefs.DeleteKey(key);
        }

        public void Clear()
        {
            PlayerPrefs.DeleteAll();
        }
        #endregion
    
        public bool Exists(string key)
        {
            return PlayerPrefs.HasKey(key);
        }
    }
}