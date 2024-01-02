using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationDelayPropertyTests : BasePropertyTest<AnimationDelayProperty>
    {
        public AnimationDelayPropertyTests() : base(PropertyNames.AnimationDelay)
        { }

        [Theory]
        [InlineData("0ms", 0, TimeUnit.Ms)]
        [InlineData("0s", 0, TimeUnit.S)]
        [InlineData("10MS", 10, TimeUnit.Ms)]
        [InlineData("10S", 10, TimeUnit.S)]
        [InlineData("-500MS", -500, TimeUnit.Ms)]
        [InlineData("-500S", -500, TimeUnit.S)]
        public void AnimationDelayLegalValues(string value, double parsedValue, TimeUnit unit)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.Time);

                var duration = prop.Value.As<TimeValue>();
                Assert.Equal(parsedValue, duration.Value);
                Assert.Equal(value, duration.Original);
                Assert.Equal(unit, duration.Type);
                Assert.Equal(value, prop.ValueText);
            });
        }

        [Fact]
        public void AnimationDelayMultipleSecondsLegal()
        {
            TestAcceptsValue("1s  , 2s  , 300ms  , 400ms", prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.List);

                var durationList = prop.Value.As<ListValue<TimeValue>>();

                Assert.Equal(4, durationList.Values.Count);

                Assert.Equal(1, durationList.Values[0].Value);
                Assert.Equal(TimeUnit.S, durationList.Values[0].Type);
                Assert.Equal("1s", durationList.Values[0].Original);

                Assert.Equal(2, durationList.Values[1].Value);
                Assert.Equal(TimeUnit.S, durationList.Values[1].Type);
                Assert.Equal("2s", durationList.Values[1].Original);

                Assert.Equal(300, durationList.Values[2].Value);
                Assert.Equal(TimeUnit.Ms, durationList.Values[2].Type);
                Assert.Equal("300ms", durationList.Values[2].Original);

                Assert.Equal(400, durationList.Values[3].Value);
                Assert.Equal(TimeUnit.Ms, durationList.Values[3].Type);
                Assert.Equal("400ms", durationList.Values[3].Original);
            });
        }

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationDelayPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData("10")]
        [InlineData("abc")]
        public void AnimationDelayPropertyIllegalValue(string value)
            => TestInvalidValue(value);
    }
}
