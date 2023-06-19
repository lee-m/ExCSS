using ExCSS.New;
using ExCSS.New.StyleProperties.Flexbox;
using ExCSS.Values;

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
        public void AlignContentAcceptsOverflowPosition(string value, bool? safe, bool? notSafe)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.ContentPosition);

                var contentPosition = prop.Value.As<ContentPosition>();

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
        public void AlignContentInvalidOverflowPosition(string value)
            => TestInvalidValue(value);

        [Theory]
        [InlineData("center")]
        [InlineData("start")]
        [InlineData("end")]
        [InlineData("flex-start")]
        [InlineData("flex-end")]
        public void AlignContentAcceptsContentPosition(string value)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.ContentPosition);

                var contentPosition = prop.Value.As<ContentPosition>();

                Assert.Null(contentPosition.Overflow);
                Assert.Equal(value, contentPosition.Value);
            });
        }
    }
}
