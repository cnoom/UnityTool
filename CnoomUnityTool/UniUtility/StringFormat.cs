﻿using System;
using System.Text;

// ReSharper disable CheckNamespace
namespace CnoomUnityTool.UniUtility
{
    public static class StringFormat
    {
        [ThreadStatic]
        private static readonly StringBuilder CacheBuilder = new StringBuilder(1024);

        public static string Format(string format, object arg0)
        {
            if(string.IsNullOrEmpty(format))
                throw new ArgumentNullException();

            CacheBuilder.Length = 0;
            CacheBuilder.AppendFormat(format, arg0);
            return CacheBuilder.ToString();
        }
        public static string Format(string format, object arg0, object arg1)
        {
            if(string.IsNullOrEmpty(format))
                throw new ArgumentNullException();

            CacheBuilder.Length = 0;
            CacheBuilder.AppendFormat(format, arg0, arg1);
            return CacheBuilder.ToString();
        }
        public static string Format(string format, object arg0, object arg1, object arg2)
        {
            if(string.IsNullOrEmpty(format))
                throw new ArgumentNullException();

            CacheBuilder.Length = 0;
            CacheBuilder.AppendFormat(format, arg0, arg1, arg2);
            return CacheBuilder.ToString();
        }
        public static string Format(string format, params object[] args)
        {
            if(string.IsNullOrEmpty(format))
                throw new ArgumentNullException();

            if(args == null)
                throw new ArgumentNullException();

            CacheBuilder.Length = 0;
            CacheBuilder.AppendFormat(format, args);
            return CacheBuilder.ToString();
        }
    }
}