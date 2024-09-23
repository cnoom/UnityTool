using UnityEditor;
using UnityEngine;
// ReSharper disable CheckNamespace

namespace CnoomUnityTool.BaseUtil
{
    public enum LogLevel
    {
        Debug,
        Info,
        Warning,
        Error
    }

    public static class GameLogger
    {
        private static LogLevel logLevel;
        #if UNITY_EDITOR

        [MenuItem("插件/日志输出/调试级别", false, 6)]
        private static void DebugLevel()
        {
            logLevel = LogLevel.Debug;
            Debug.Log($"{nameof(GameLogger)}当前输出级别:{logLevel}");
        }
        [MenuItem("插件/日志输出/调试级别", true)]
        private static bool DebugLevelIsMenuItem()
        {
            return logLevel != LogLevel.Debug;
        }
        [MenuItem("插件/日志输出/信息级别")]
        private static void InfoLogLevel()
        {
            logLevel = LogLevel.Info;
            Debug.Log($"{nameof(GameLogger)}当前输出级别:{logLevel}");
        }
        [MenuItem("插件/日志输出/信息级别", true)]
        private static bool InfoLogLevelIsMenuItem()
        {
            return logLevel != LogLevel.Info;
        }
        [MenuItem("插件/日志输出/警告级别")]
        private static void WarningLogLevel()
        {
            logLevel = LogLevel.Warning;
            Debug.Log($"{nameof(GameLogger)}当前输出级别:{logLevel}");
        }
        [MenuItem("插件/日志输出/警告级别", true)]
        private static bool WarningLogLevelIsMenuItem()
        {
            return logLevel != LogLevel.Warning;
        }
        [MenuItem("插件/日志输出/报错级别")]
        private static void ErrorLogLevel()
        {
            logLevel = LogLevel.Error;
            Debug.Log($"{nameof(GameLogger)}当前输出级别:{logLevel}");
        }
        [MenuItem("插件/日志输出/报错级别", true)]
        private static bool ErrorLogLevelIsMenuItem()
        {
            return logLevel != LogLevel.Error;
        }
        #endif
        // ReSharper disable Unity.PerformanceAnalysis
        public static void EditorLog<TObject>(string message)
        {
            if(Application.isEditor && Application.isPlaying)
            {
                Log(message, LogLevel.Debug, typeof(TObject).Name);
            }
        }

        public static void EditorLog(string message)
        {
            if(Application.isPlaying && Application.isEditor)
            {
                return;
            }
            Log(message, LogLevel.Debug);
        }

        private static void InfoLog(string message, string source = "")
        {
            Debug.Log($"[INFO] {source} {message}");
        }

        private static void WarningLog(string message, string source = "")
        {
            Debug.LogWarning($"<color=yellow>[WARNING] {source} {message}</color>");
        }

        private static void ErrorLog(string message, string source = "")
        {
            Debug.LogError($"<color=red>[ERROR] {source} {message}</color>");
        }

        public static void Log<TObject>(string message, LogLevel level = LogLevel.Info)
        {
            Log(message, level, typeof(TObject).Name);
        }

        public static void Log(string message, LogLevel level = LogLevel.Info, string source = "")
        {
            if((int)level >= (int)logLevel)
            {
                switch(level)
                {
                    case LogLevel.Debug:
                        Debug.Log($"{source}:{message}");
                        break;
                    case LogLevel.Info:
                        InfoLog(message, source);
                        break;
                    case LogLevel.Warning:
                        WarningLog(message, source);
                        break;
                    case LogLevel.Error:
                        ErrorLog(message, source);
                        break;
                }
            }
        }
    }
}