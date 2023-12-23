using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Flexbox;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Flexbox
{
    public class AlignSelfPropertyTests : BasePropertyTest<AlignSelfProperty>
    {
        public AlignSelfPropertyTests() : base(PropertyNames.AlignSelf)
        { }

        [Fact]
        public void AlignSelfPropertyAcceptsAutoKeyword()
            => TestAcceptsKeyword(Keywords.Auto);

        [Fact]
        public void AlignSelfPropertyAcceptsNormalKeyword()
            => TestAcceptsKeyword(Keywords.Normal);

        [Fact]
        public void AlignSelfPropertyAcceptsStretchKeyword()
            => TestAcceptsKeyword(Keywords.Stretch);

        [Theory]
        [MemberData(nameof(ValidBaselinePropertyValues))]
        public void AlignSelfPropertyAcceptsBaselinePosition(string value, bool? first, bool? last)
            => TestAcceptsBaselineValue(value, first, last);

        [Theory]
        [MemberData(nameof(InvalidBaselinePropertyValues))]
        public void AlignSelfPropertyInvalidBaselinePosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [MemberData(nameof(SelfPositionKeywordValues))]
        public void AlignSelfPropertyAcceptsSelfPositionKeywords(string value, SelfPositionKeyword expected)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.SelfPosition);

                var selfPosition = prop.Value.As<SelfPositionValue>();

                Assert.Equal(expected, selfPosition.Keyword);
                Assert.Null(selfPosition.Overflow);
            });
        }

        [Theory]
        [MemberData(nameof(OverflowSelfPositionKeywordValues))]
        public void AlignSelfPropertyAcceptsOverflowSelfPositionKeywords(string value, SelfPositionKeyword keyword, bool? safe, bool? notSafe)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.SelfPosition);

                var selfPosition = prop.Value.As<SelfPositionValue>();

                Assert.Equal(keyword, selfPosition.Keyword);
                Assert.Equal(safe, selfPosition.Overflow.Safe);
                Assert.Equal(notSafe, selfPosition.Overflow.Unsafe);
            });
        }
    }
}
