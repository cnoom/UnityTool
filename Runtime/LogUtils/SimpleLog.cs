using UnityEngine;

namespace Cnoom.UnityTool.LogUtils
{
    public class SimpleLog : ILog
    {

        public void Log(string message)
        {
            Debug.Log(ColorString(message, Color.white));

        }
        public void Warning(string message)
        {
            Debug.LogWarning(ColorString(message, Color.yellow));
        }
        public void Error(string message)
        {
            Debug.LogError(ColorString(message, Color.red));
        }

        private string ColorString(string text, Color color)
        {
            return string.Format("<color=#{0}>{1}</color>", ColorUtility.ToHtmlStringRGB(color), text);
        }
    }

}