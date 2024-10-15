
namespace Cnoom.UnityTool.StorageUtils
{
    public interface IStorage
    {
        #region 数据保存

        public void SaveInt(string key, int value, bool isSave = true);

        public void SaveFloat(string key, float value, bool isSave = true);

        public void SaveString(string key, string value, bool isSave = true);

        public void SaveObject(string key, object value, bool isSave = true);

        #endregion

        #region 数据读取

        public int LoadInt(string key, int defaultValue = 0);

        public float LoadFloat(string key, float defaultValue = 0);

        public string LoadString(string key, string defaultValue = "");

        public T? LoadObject<T>(string key, T? defaultValue = default);

        #endregion
    
        public void Delete(string key);

        public void Clear();

        public bool Exists(string key);
    
        public static IStorage? Current { get; set; }
    }
}