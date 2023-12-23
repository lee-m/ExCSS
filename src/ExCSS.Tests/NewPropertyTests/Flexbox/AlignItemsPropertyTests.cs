using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Flexbox;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Flexbox
{
    public class AlignItemsPropertyTests : BasePropertyTest<AlignItemsProperty>
    {
        public AlignItemsPropertyTests() : base(PropertyNames.AlignItems)
        { }

        [Fact]
        public void AlignItemsPropertyAcceptsNormalKeyword()
            => TestAcceptsKeyword(Keywords.Normal);

        [Fact]
        public void AlignItemsPropertyAcceptsStretchKeyword()
            => TestAcceptsKeyword(Keywords.Stretch);

        [Theory]
        [MemberData(nameof(ValidBaselinePropertyValues))]
        public void AlignItemsPropertyAcceptsBaselinePosition(string value, bool? first, bool? last)
            => TestAcceptsBaselineValue(value, first, last);

        [Theory]
        [MemberData(nameof(InvalidBaselinePropertyValues))]
        public void AlignItemsPropertyInvalidBaselinePosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AlignItemsPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [MemberData(nameof(SelfPositionKeywordValues))]
        public void AlignItemsPropertyAcceptsSelfPositionKeywords(string value, SelfPositionKeyword expected)
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
        public void AlignItemsPropertyAcceptsOverflowSelfPositionKeywords(string value, SelfPositionKeyword keyword, bool? safe, bool? notSafe)
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
