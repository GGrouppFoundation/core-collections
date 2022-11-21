using System;
using System.Collections.Generic;

namespace GGroupp;

partial class FlatArrayExtensions
{
    public static Optional<T> FirstOrAbsent<T>(this FlatArray<T> array)
        =>
        array.IsEmpty
            ? default
            : Optional.Present(array[0]);

    public static Optional<T> FirstOrAbsent<T>(this FlatArray<T> array, Predicate<T> predicate)
    {
        ArgumentNullException.ThrowIfNull(predicate);

        if (array.IsEmpty)
        {
            return default;
        }

        foreach (var item in array)
        {
            if (predicate.Invoke(item))
            {
                return Optional.Present(item);
            }
        }

        return default;
    }
}