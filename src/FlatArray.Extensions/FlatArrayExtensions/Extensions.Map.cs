using System;
using System.Collections.Generic;

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

        var builder = FlatArray<TResult>.Builder.Create(source.Length);
        var index = 0;

        foreach (var sourceItem in source)
        {
            builder[index] = map.Invoke(sourceItem);
            index++;
        }

        return builder.Build();
    }
}