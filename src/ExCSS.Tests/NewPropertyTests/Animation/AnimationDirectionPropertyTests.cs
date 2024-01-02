using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationDirectionPropertyTests : BasePropertyTest<AnimationDirectionProperty>
    {
        public AnimationDirectionPropertyTests() : base(PropertyNames.AnimationDirection)
        { }

        public static IEnumerable<object[]> DirectionTestValues
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { Keywords.Normal, AnimationDirection.Normal },
                    new object[] { GetUppercasePermutations(Keywords.Normal), AnimationDirection.Normal },

                    new object[] { Keywords.Reverse, AnimationDirection.Reverse },
                    new object[] { GetUppercasePermutations(Keywords.Reverse), AnimationDirection.Reverse },

                    new object[] { Keywords.Alternate, AnimationDirection.Alternate },
                    new object[] { GetUppercasePermutations(Keywords.Alternate), AnimationDirection.Alternate },

                    new object[] { Keywords.AlternateReverse, AnimationDirection.AlternateReverse },
                    new object[] { GetUppercasePermutations(Keywords.AlternateReverse), AnimationDirection.AlternateReverse }
                };
            }
        }

        [Theory]
        [MemberData(nameof(DirectionTestValues))]
        public void AnimationDirectionKeywordValueLegal(string value, AnimationDirection expectedDirection)
            => TestAcceptsEnumKeyword(value, expectedDirection);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationDirectionPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData("0")]
        public void AnimationDirectionIllegalValues(string value)
            => TestInvalidValue(value);

        [Fact]
        public void AnimationDirectionAcceptsKeywordList()
        {
            var propValue = "normal, reverse, alternate, alternate-reverse";

            TestAcceptsValue(propValue, prop =>
            {
                Assert.Equal(ValueKind.List, prop.Value.Kind);

                var listValue = prop.Value.As<ListValue<IValue>>();
                Assert.Equal(4, listValue.Values.Count);

                Assert.Equal(AnimationDirection.Normal, listValue.Values[0].As<EnumKeywordValue<AnimationDirection>>().Keyword);
                Assert.Equal(AnimationDirection.Reverse, listValue.Values[1].As<EnumKeywordValue<AnimationDirection>>().Keyword);
                Assert.Equal(AnimationDirection.Alternate, listValue.Values[2].As<EnumKeywordValue<AnimationDirection>>().Keyword);
                Assert.Equal(AnimationDirection.AlternateReverse, listValue.Values[3].As<EnumKeywordValue<AnimationDirection>>().Keyword);

                Assert.Equal(propValue, prop.ValueText);
            });
        }
    }
}