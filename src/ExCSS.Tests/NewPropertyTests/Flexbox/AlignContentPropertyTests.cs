using ExCSS.New;
using ExCSS.New.StyleProperties.Flexbox;
using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Flexbox
{
    public class AlignContentPropertyTests : BasePropertyTest<AlignContentProperty>
    {
        public AlignContentPropertyTests() : base(PropertyNames.AlignContent)
        { }

        [Fact]
        public void AlignContentAcceptsNormalKeyword()
            => TestAcceptsKeyword(Keywords.Normal);

        [Theory]
        [InlineData("first baseline", true, null)]
        [InlineData("last baseline", null, true)]
        [InlineData("baseline", null, null)]
        public void AlignContentAcceptsBaselinePosition(string value, bool? first, bool? last)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.BaselinePosition);

                var baselinePosition = prop.Value.As<BaselinePosition>();

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
        public void AlignContentInvalidBaselinePosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [InlineData("space-around")]
        [InlineData("space-between")]
        [InlineData("space-evenly")]
        [InlineData("stretch")]
        public void AlignContentAcceptsContentDistribution(string value)
            => TestAcceptsKeyword(value);

        [Theory]
        [InlineData("safe center")]
        [InlineData("safe start")]
        [InlineData("safe end")]
        [InlineData("safe flex-start")]
        [InlineData("safe flex-end")]
        [InlineData("unsafe center")]
        [InlineData("unsafe start")]
        [InlineData("unsafe end")]
        [InlineData("unsafe flex-start")]
        [InlineData("unsafe flex-end")]
        public void AlignContentAcceptsOverflowPosition(string value)
            => TestAcceptsKeyword(value);

        [Theory]
        [InlineData("center")]
        [InlineData("start")]
        [InlineData("end")]
        [InlineData("flex-start")]
        [InlineData("flex-end")]
        public void AlignContentAcceptsContentPosition(string value)
            => TestAcceptsKeyword(value);
    }
}
