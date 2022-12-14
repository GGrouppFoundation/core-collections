using System;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> Map<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var result = new TResult[source.Length];

        for (var i = 0; i < source.Length; i++)
        {
            var sourceItem = source[i];
            result[i] = map.Invoke(sourceItem);
        }

        return result;
    }

    public static FlatArray<TResult> Map<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, int, TResult> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var result = new TResult[source.Length];

        for (var i = 0; i < source.Length; i++)
        {
            result[i] = map.Invoke(source[i], i);
        }

        return result;
    }
}