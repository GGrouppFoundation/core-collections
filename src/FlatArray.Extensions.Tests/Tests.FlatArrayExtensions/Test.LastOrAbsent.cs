using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.FlatArray.Extensions.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void LastOrAbsent_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<RecordType?>.Empty;

        var actual = source.LastOrAbsent();
        var expected = Optional.Absent<RecordType?>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(null, MinusFifteen, One)]
    [InlineData(MinusFifteen, Zero)]
    public void LastOrAbsent_SourceIsNotEmpty_ExpectLastItem(int? last, params int?[] others)
    {
        var sourceBuilder = FlatArray<int?>.Builder.OfLength(others.Length + 1);

        for (var i = 0; i < others.Length; i++)
        {
            sourceBuilder[i] = others[i];
        }

        sourceBuilder[others.Length] = last;

        var source = sourceBuilder.MoveToArray();

        var actual = source.LastOrAbsent();
        var expected = Optional.Present(last);

        Assert.Equal(expected, actual);
    }
}