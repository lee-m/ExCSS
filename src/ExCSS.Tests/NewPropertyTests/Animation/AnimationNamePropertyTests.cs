using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationNamePropertyTests : BasePropertyTest<AnimationNameProperty>
    {
        public AnimationNamePropertyTests() : base(PropertyNames.AnimationName)
        { }

        [Fact]
        public void AnimationNamePropertyAcceptsNoneKeyword()
            => TestAcceptsKeyword(Keywords.None);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationNamePropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword<WideKeyword, WideKeywordValue>(value, ValueKind.WideKeyword, expected);

    }
}
