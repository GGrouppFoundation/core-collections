using System;
using System.Collections.Generic;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<TResult> FlatMap<TSource, TResult>(this FlatArray<TSource> source, Func<TSource, FlatArray<TResult>> map)
    {
        ArgumentNullException.ThrowIfNull(map);

        if (source.IsEmpty)
        {
            return default;
        }

        var list = new List<TResult>();

        foreach (var item in source)
        {
            var items = map.Invoke(item);

            if (items.IsEmpty)
            {
                continue;
            }

            list.AddRange(items.AsEnumerable());
        }

        return list;
    }
}