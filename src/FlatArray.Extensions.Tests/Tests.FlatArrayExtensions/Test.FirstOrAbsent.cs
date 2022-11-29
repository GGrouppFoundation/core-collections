using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.FlatArray.Extensions.Tests;

partial class FlatArrayExtensionsTest
{
    [Fact]
    public void FirstOrAbsent_SourceIsEmpty_ExpectAbsent()
    {
        var source = FlatArray<RefType>.Empty;

        var actual = source.FirstOrAbsent();
        var expected = Optional.Absent<RefType>();

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData(null)]
    [InlineData(null, SomeString, AnotherString)]
    [InlineData(AnotherString, EmptyString)]
    public void FirstOrAbsent_SourceIsNotEmpty_ExpectFirstItem(string? first, params string?[] others)
    {
        var sourceBuilder = FlatArray<string?>.Builder.OfLength(others.Length + 1);
        sourceBuilder[0] = first;

        for (var i = 0; i < others.Length; i++)
        {
            sourceBuilder[i + 1] = others[i];
        }

        var source = sourceBuilder.MoveToArray();

        var actual = source.FirstOrAbsent();
        var expected = Optional.Present(first);

        Assert.Equal(expected, actual);
    }
}