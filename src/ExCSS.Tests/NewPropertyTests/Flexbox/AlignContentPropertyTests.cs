using ExCSS.New;
using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Flexbox;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Flexbox
{
    public class AlignContentPropertyTests : BasePropertyTest<AlignContentProperty>
    {
        public AlignContentPropertyTests() : base(PropertyNames.AlignContent)
        { }

        [Fact]
        public void AlignContentPropertyAcceptsNormalKeyword()
            => TestAcceptsKeyword(Keywords.Normal);

        [Theory]
        [InlineData("first baseline", true, null)]
        [InlineData("last baseline", null, true)]
        [InlineData("baseline", null, null)]
        public void AlignContentPropertyAcceptsBaselinePosition(string value, bool? first, bool? last)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.BaselinePosition);

                var baselinePosition = prop.Value.As<BaselinePositionValue>();

                Assert.Equal(first, baselinePosition.First);
                Assert.Equal(last, baselinePosition.Last);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData("first first baseline")]
        [InlineData("last last baseline")]
        [InlineData("baseline baseline")]
        [InlineData("first baseline last")]
        [InlineData("last baseline first")]
        public void AlignContentPropertyInvalidBaselinePosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [InlineData("space-around", ContentDistributionKeyword.SpaceAround)]
        [InlineData("space-between", ContentDistributionKeyword.SpaceBetween)]
        [InlineData("space-evenly", ContentDistributionKeyword.SpaceEvenly)]
        [InlineData("stretch", ContentDistributionKeyword.Stretch)]
        public void AlignContentPropertyAcceptsContentDistribution(string value, ContentDistributionKeyword expectedKeyword)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.ContentDistribution);

                var contentDistribution = prop.Value.As<ContentDistributionValue>();
                Assert.Equal(expectedKeyword, contentDistribution.Keyword);
            });
        }

        [Theory]
        [InlineData("safe center", true, null)]
        [InlineData("safe start", true, null)]
        [InlineData("safe end", true, null)]
        [InlineData("safe flex-start", true, null)]
        [InlineData("safe flex-end", true, null)]
        [InlineData("unsafe center", null, true)]
        [InlineData("unsafe start", null, true)]
        [InlineData("unsafe end", null, true)]
        [InlineData("unsafe flex-start", null, true)]
        [InlineData("unsafe flex-end", null, true)]
        public void AlignContentPropertyAcceptsOverflowPosition(string value, bool? safe, bool? notSafe)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.ContentPosition);

                var contentPosition = prop.Value.As<ContentPositionValue>();

                Assert.Equal(safe, contentPosition.Overflow.Safe);
                Assert.Equal(notSafe, contentPosition.Overflow.Unsafe);
            });
        }

        [Theory]
        [InlineData("")]
        [InlineData("safe safe center")]
        [InlineData("safe start start")]
        [InlineData("safe")]
        [InlineData("unsafe unsafe center")]
        [InlineData("unsafe start start")]
        [InlineData("unsafe")]
        public void AlignContentPropertyInvalidOverflowPosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [InlineData("center", ContentPositionKeyword.Center)]
        [InlineData("start", ContentPositionKeyword.Start)]
        [InlineData("end", ContentPositionKeyword.End)]
        [InlineData("flex-start", ContentPositionKeyword.FlexStart)]
        [InlineData("flex-end", ContentPositionKeyword.FlexEnd)]
        public void AlignContentPropertyAcceptsContentPosition(string value, ContentPositionKeyword expectedKeyword)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.ContentPosition);

                var contentPosition = prop.Value.As<ContentPositionValue>();

                Assert.Null(contentPosition.Overflow);
                Assert.Equal(expectedKeyword, contentPosition.Keyword);
            });
        }

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AlignContentPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsWideKeyword(value, expected);
    }
}
