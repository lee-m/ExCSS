using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationIterationCountPropertyTests : BasePropertyTest<AnimationIterationCountProperty>
    {
        public AnimationIterationCountPropertyTests() : base(PropertyNames.AnimationIterationCount)
        { }

        public static IEnumerable<object[]> InfiniteCasingVariationTestValues
            => new List<object[]>
            {
                new object[] { Keywords.Infinite },
                new object[] { GetUppercasePermutations(Keywords.Infinite) }
            };

        [Theory]
        [InlineData("0", 0)]
        [InlineData("2.3", 2.3)]
        public void AnimationIterationCountNumericValuesLegal(string value, float expectedValue)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(expectedValue, prop.Value.As<NumberValue>().Value);
                Assert.Equal(value, prop.ValueText);
            });
        }

        [Theory]
        [MemberData(nameof(InfiniteCasingVariationTestValues))]
        public void AnimationIterationCountInfiniteLegal(string value)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(Keywords.Infinite, prop.Value.As<KeywordValue>().Keyword);
                Assert.Equal(Keywords.Infinite, prop.ValueText);
            });
        }

        [Fact]
        public void AnimationIterationCountAcceptsMultipleLegalValues()
        {
            var value = "2, 0, infinite";

            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.List, prop.Value.Kind);
                Assert.Equal(value, prop.ValueText);

                var listValues = prop.Value.As<ListValue<IValue>>().Values;

                Assert.Equal(ValueKind.Number, listValues[0].Kind);
                Assert.Equal(2f, listValues[0].As<NumberValue>().Value);

                Assert.Equal(ValueKind.Number, listValues[1].Kind);
                Assert.Equal(0f, listValues[1].As<NumberValue>().Value);

                Assert.Equal(ValueKind.Keyword, listValues[2].Kind);
                Assert.Equal(Keywords.Infinite, listValues[2].As<KeywordValue>().Keyword);
            });
        }

        [Fact]
        public void AnimationIterationCountAcceptsMultipleLegalValuesKeywordFirst()
        {
            var value = "infinite, 0, 10";

            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.List, prop.Value.Kind);
                Assert.Equal(value, prop.ValueText);

                var listValues = prop.Value.As<ListValue<IValue>>().Values;

                Assert.Equal(ValueKind.Keyword, listValues[0].Kind);
                Assert.Equal(Keywords.Infinite, listValues[0].As<KeywordValue>().Keyword);

                Assert.Equal(ValueKind.Number, listValues[1].Kind);
                Assert.Equal(0f, listValues[1].As<NumberValue>().Value);

                Assert.Equal(ValueKind.Number, listValues[2].Kind);
                Assert.Equal(10f, listValues[2].As<NumberValue>().Value);
            });
        }

        [Theory]
        [InlineData("-1")]
        [InlineData("1, -1")]
        [InlineData("abc")]
        [InlineData("infinite, abc")]
        [InlineData("10, abc")]
        public void AnimationIterationCountIllegalValues(string value)
            => TestInvalidValue(value);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationIterationCountPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);
    }
}