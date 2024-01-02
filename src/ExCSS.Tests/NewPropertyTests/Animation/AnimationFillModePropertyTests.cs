using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationFillModePropertyTests : BasePropertyTest<AnimationFillModeProperty>
    {
        public AnimationFillModePropertyTests() : base(PropertyNames.AnimationFillMode)
        { }

        public static IEnumerable<object[]> FillModeTestValues
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { Keywords.None, AnimationFillMode.None },
                    new object[] { GetUppercasePermutations(Keywords.None), AnimationFillMode.None },

                    new object[] { Keywords.Backwards, AnimationFillMode.Backwards },
                    new object[] { GetUppercasePermutations(Keywords.Backwards), AnimationFillMode.Backwards },

                    new object[] { Keywords.Both, AnimationFillMode.Both },
                    new object[] { GetUppercasePermutations(Keywords.Both), AnimationFillMode.Both },

                    new object[] { Keywords.Forwards, AnimationFillMode.Forwards },
                    new object[] { GetUppercasePermutations(Keywords.Forwards), AnimationFillMode.Forwards }
                };
            }
        }

        [Theory]
        [MemberData(nameof(FillModeTestValues))]
        public void AnimationFillModeKeywordValueLegal(string value, AnimationFillMode expectedFillStyle)
            => TestAcceptsEnumKeyword(value, expectedFillStyle);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationFillModePropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData("0")]
        public void AnimationFillModeIllegalValues(string value)
            => TestInvalidValue(value);

        [Fact]
        public void AnimationFillModeAcceptsKeywordList()
        {
            var propValue = "both, backwards, forwards, NONE";

            TestAcceptsValue(propValue, prop =>
            {
                Assert.Equal(ValueKind.List, prop.Value.Kind);

                var listValue = prop.Value.As<ListValue<IValue>>();
                Assert.Equal(4, listValue.Values.Count);

                Assert.Equal(AnimationFillMode.Both, listValue.Values[0].As<EnumKeywordValue<AnimationFillMode>>().Keyword);
                Assert.Equal(AnimationFillMode.Backwards, listValue.Values[1].As<EnumKeywordValue<AnimationFillMode>>().Keyword);
                Assert.Equal(AnimationFillMode.Forwards, listValue.Values[2].As<EnumKeywordValue<AnimationFillMode>>().Keyword);
                Assert.Equal(AnimationFillMode.None, listValue.Values[3].As<EnumKeywordValue<AnimationFillMode>>().Keyword);

                Assert.Equal(propValue, prop.ValueText);
            });
        }
    }
}