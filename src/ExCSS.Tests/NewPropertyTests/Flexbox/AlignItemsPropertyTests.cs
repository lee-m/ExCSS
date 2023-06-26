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
            => TestAcceptsEnumKeyword<WideKeyword, WideKeywordValue>(value, ValueKind.WideKeyword, expected);

        [Theory]
        [InlineData("center", SelfPositionKeyword.Center)]
        [InlineData("start", SelfPositionKeyword.Start)]
        [InlineData("end", SelfPositionKeyword.End)]
        [InlineData("self-start", SelfPositionKeyword.SelfStart)]
        [InlineData("self-end", SelfPositionKeyword.SelfEnd)]
        [InlineData("flex-start", SelfPositionKeyword.FlexStart)]
        [InlineData("flex-end", SelfPositionKeyword.FlexEnd)]
        public void AlignItemsPropertyAcceptsSelfPositionKeywords(string value, SelfPositionKeyword expected)
            => TestAcceptsEnumKeyword<SelfPositionKeyword, SelfPositionValue>(value, ValueKind.SelfPosition, expected);

        [Theory]
        [InlineData("safe center", SelfPositionKeyword.Center, true, null)]
        [InlineData("safe start", SelfPositionKeyword.Start, true, null)]
        [InlineData("safe end", SelfPositionKeyword.End, true, null)]
        [InlineData("safe self-start", SelfPositionKeyword.SelfStart, true, null)]
        [InlineData("safe self-end", SelfPositionKeyword.SelfEnd, true, null)]
        [InlineData("safe flex-start", SelfPositionKeyword.FlexStart, true, null)]
        [InlineData("safe flex-end", SelfPositionKeyword.FlexEnd, true, null)]
        [InlineData("unsafe center", SelfPositionKeyword.Center, null, true)]
        [InlineData("unsafe start", SelfPositionKeyword.Start, null, true)]
        [InlineData("unsafe end", SelfPositionKeyword.End, null, true)]
        [InlineData("unsafe self-start", SelfPositionKeyword.SelfStart, null, true)]
        [InlineData("unsafe self-end", SelfPositionKeyword.SelfEnd, null, true)]
        [InlineData("unsafe flex-start", SelfPositionKeyword.FlexStart, null, true)]
        [InlineData("unsafe flex-end", SelfPositionKeyword.FlexEnd, null, true)]
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
