using System;
using System.Collections.Generic;
using System.Linq;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace GGroupp.Core.Collections.FlatArray.Extensions.Tests;

partial class FlatArrayExtensionsTest
{
    [Theory]
    [InlineData(true)]
    [InlineData(false)]
    public void Map_MapArgumentIsNull_ExpectArgumentNullException(bool isSourceDefault)
    {
        var source = isSourceDefault ? default : new FlatArray<int>(PlusFifteen, Zero, MinusOne);

        var ex = Assert.Throws<ArgumentNullException>(Test);
        Assert.Equal("map", ex.ParamName);

        void Test()
            =>
            _ = source.Map<int, RecordType>(null!);
    }

    [Fact]
    public void Map_SourceIsEmpty_ExpectDefault()
    {
        var source = FlatArray<RecordStruct>.Empty;
        var actual = source.Map(Map);

        var expected = default(FlatArray<RefType>);
        Assert.Equal(expected, actual);

        static RefType Map(RecordStruct _)
            =>
            MinusFifteenIdRefType;
    }

    [Fact]
    public void Map_SourceIsNotEmpty_ExpectMappedValues()
    {
        var mapper = new Dictionary<string, RecordType>
        {
            [SomeString] = PlusFifteenIdLowerSomeStringNameRecord,
            [AnotherString] = ZeroIdNullNameRecord,
            [MixedWhiteSpacesString] = MinusFifteenIdSomeStringNameRecord
        };

        var source = new FlatArray<string>(mapper.Keys.ToArray());
        var actual = source.Map(Map);

        var expected = new FlatArray<RecordType>(mapper.Values.ToArray());
        Assert.Equal(expected, actual);

        RecordType Map(string sourceValue)
            =>
            mapper[sourceValue];
    }
}
