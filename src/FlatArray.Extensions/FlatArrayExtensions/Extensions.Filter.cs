using System;
using System.Collections.Generic;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static FlatArray<T> Filter<T>(this FlatArray<T> array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (array.IsEmpty)
        {
            return default;
        }

        var list = new List<T>(array.Length);

        foreach (var item in array)
        {
            if (predicate.Invoke(item))
            {
                list.Add(item);
            }
        }

        return list;
    }
}