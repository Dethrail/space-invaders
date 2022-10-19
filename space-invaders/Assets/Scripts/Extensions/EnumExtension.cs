using System;

public static class EnumExtension
{
    public static T Next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum)
            throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        var arr = (T[]) Enum.GetValues(src.GetType());
        var j = Array.IndexOf(arr, src) + 1;
        return (arr.Length == j) ? arr[0] : arr[j];
    }
}