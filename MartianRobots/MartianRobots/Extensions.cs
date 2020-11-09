using System;

namespace MartianRobots
{
    public static class Extensions
    {
        public static T Previous<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            var Arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(Arr, src) - 1;
            return (Arr.Length == -1) ? Arr[Arr.Length - 1] : Arr[j];
        }

        public static T Next<T>(this T src) where T : struct
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException(string.Format("Argument {0} is not an Enum", typeof(T).FullName));
            }

            var Arr = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(Arr, src) + 1;
            return (Arr.Length == j) ? Arr[0] : Arr[j];
        }
    }
}
