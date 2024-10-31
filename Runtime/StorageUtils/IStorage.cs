namespace Cnoom.UnityTool.StorageUtils
{
    /// <summary>
    /// 定义一个存储接口，用于存储和读取数据
    /// </summary>
    public interface IStorage
    {
        #region 数据保存

        /// <summary>
        /// 保存一个整数值到存储中
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="value">要保存的值</param>
        /// <param name="isSave">是否立即保存</param>
        public void SaveInt(string key, int value, bool isSave = true);

        /// <summary>
        /// 保存一个浮点数值到存储中
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="value">要保存的值</param>
        /// <param name="isSave">是否立即保存</param>
        public void SaveFloat(string key, float value, bool isSave = true);

        /// <summary>
        /// 保存一个字符串值到存储中
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="value">要保存的值</param>
        /// <param name="isSave">是否立即保存</param>
        public void SaveString(string key, string value, bool isSave = true);

        /// <summary>
        /// 保存一个对象到存储中
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="value">要保存的对象</param>
        /// <param name="isSave">是否立即保存</param>
        public void SaveObject(string key, object value, bool isSave = true);

        #endregion

        #region 数据读取

        /// <summary>
        /// 从存储中读取一个整数值
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="defaultValue">如果键不存在，返回的默认值</param>
        /// <returns>读取的值</returns>
        public int LoadInt(string key, int defaultValue = 0);

        /// <summary>
        /// 从存储中读取一个浮点数值
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="defaultValue">如果键不存在，返回的默认值</param>
        /// <returns>读取的值</returns>
        public float LoadFloat(string key, float defaultValue = 0);

        /// <summary>
        /// 从存储中读取一个字符串值
        /// </summary>
        /// <param name="key">存储的键</param>
        /// <param name="defaultValue">如果键不存在，返回的默认值</param>
        /// <returns>读取的值</returns>
        public string LoadString(string key, string defaultValue = "");

        /// <summary>
        /// 从存储中读取一个对象
        /// </summary>
        /// <typeparam name="T">对象的类型</typeparam>
        /// <param name="key">存储的键</param>
        /// <param name="defaultValue">如果键不存在，返回的默认值</param>
        /// <returns>读取的对象</returns>
        public T LoadObject<T>(string key, T defaultValue = default);

        #endregion

        /// <summary>
        /// 删除存储中的一个键值对
        /// </summary>
        /// <param name="key">要删除的键</param>
        public void Delete(string key);

        /// <summary>
        /// 清除存储中的所有数据
        /// </summary>
        public void Clear();

        /// <summary>
        /// 检查一个键是否存在于存储中
        /// </summary>
        /// <param name="key">要检查的键</param>
        /// <returns>如果键存在，返回 true；否则返回 false</returns>
        public bool Exists(string key);

        /// <summary>
        /// 获取当前的存储实例
        /// </summary>
        public static IStorage Current { get; set; }
    }
}
