using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationDurationPropertyTests : BasePropertyTest<AnimationDurationProperty>
    {
        public AnimationDurationPropertyTests() : base(PropertyNames.AnimationDuration)
        { }

        [Fact]
        public void AnimationDurationMillisecondsLegal()
        {
            var propValue = "60ms";

            TestAcceptsValue(propValue, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.Time);

                var duration = prop.Value.As<TimeValue>();
                Assert.Equal(60, duration.Value);
                Assert.Equal(propValue, duration.Original);
                Assert.Equal(TimeUnit.Ms, duration.Type);
                Assert.Equal(propValue, prop.ValueText);
            });
        }

        [Fact]
        public void AnimationDurationMultipleSecondsLegal()
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
        public void AnimationDurationPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);
    }
}
