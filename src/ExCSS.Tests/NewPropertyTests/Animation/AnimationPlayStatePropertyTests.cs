using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationPlayStatePropertyTests : BasePropertyTest<AnimationPlayStateProperty>
    {
        public AnimationPlayStatePropertyTests() : base(PropertyNames.AnimationPlayState)
        { }

        public static IEnumerable<object[]> PlayStateTestValues
        {
            get
            {
                return new List<object[]>
                {
                    new object[] { Keywords.Running, AnimationPlayState.Running },
                    new object[] { GetUppercasePermutations(Keywords.Running), AnimationPlayState.Running },

                    new object[] { Keywords.Paused, AnimationPlayState.Paused },
                    new object[] { GetUppercasePermutations(Keywords.Paused), AnimationPlayState.Paused }
                };
            }
        }

        [Theory]
        [MemberData(nameof(PlayStateTestValues))]
        public void AnimationPlayStateKeywordValueLegal(string value, AnimationPlayState expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationPlayStatePropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData("0")]
        public void AnimationPlayStateIllegalValues(string value)
            => TestInvalidValue(value);

        [Fact]
        public void AnimationPlayStateAcceptsKeywordList()
        {
            var propValue = "running, paused";

            TestAcceptsValue(propValue, prop =>
            {
                Assert.Equal(ValueKind.List, prop.Value.Kind);

                var listValue = prop.Value.As<ListValue<IValue>>();
                Assert.Equal(2, listValue.Values.Count);

                Assert.Equal(AnimationPlayState.Running, listValue.Values[0].As<EnumKeywordValue<AnimationPlayState>>().Keyword);
                Assert.Equal(AnimationPlayState.Paused, listValue.Values[1].As<EnumKeywordValue<AnimationPlayState>>().Keyword);

                Assert.Equal(propValue, prop.ValueText);
            });
        }
    }
}