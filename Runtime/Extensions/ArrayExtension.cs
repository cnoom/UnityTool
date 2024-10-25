using System;

namespace Cnoom.UnityTool.Extensions
{
    public static class ArrayExtension
    {
        public static void Clear<T>(this T[] array)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = default;
            }
        }

        public static void UniValue<T>(this T[] array,T value)
        {
            for(int i = 0; i < array.Length; i++)
            {
                array[i] = value;
            }
        }
    }
}