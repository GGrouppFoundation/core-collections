using System;
using System.Collections.Generic;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> Map<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, TResult> map)
    {
        _ = map ?? throw new ArgumentNullException(nameof(map));

        if (source.IsEmpty)
        {
            return default;
        }

        var results = new TResult[source.Length];
        var index = 0;

        foreach (var sourceItem in source)
        {
            results[index] = map.Invoke(sourceItem);
            index++;
        }

        return new(results);
    }
}