using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationTimingFunctionPropertyTests : BasePropertyTest<AnimationTimingFunctionProperty>
    {
        public AnimationTimingFunctionPropertyTests() : base(PropertyNames.AnimationTimingFunction)
        { }

        public static IEnumerable<object[]> CubicBezierTimingFunctionTestValues
        {
            get
            {
                var linear = CubicBezierTimingFunction.Linear(TokenValue.Empty);
                var ease = CubicBezierTimingFunction.Ease(TokenValue.Empty);
                var easeIn = CubicBezierTimingFunction.EaseIn(TokenValue.Empty);
                var easeOut = CubicBezierTimingFunction.EaseOut(TokenValue.Empty);
                var easeInOut = CubicBezierTimingFunction.EaseInOut(TokenValue.Empty);

                var tests = new List<object[]>
                {
                    //Keywords
                    new object[] { Keywords.Linear, linear },
                    new object[] { GetUppercasePermutations(Keywords.Linear), linear },

                    new object[] { Keywords.Ease, ease },
                    new object[] { GetUppercasePermutations(Keywords.Ease), ease },

                    new object[] { Keywords.EaseIn, easeIn },
                    new object[] { GetUppercasePermutations(Keywords.EaseIn), easeIn },

                    new object[] { Keywords.EaseOut, easeOut },
                    new object[] { GetUppercasePermutations(Keywords.EaseOut), easeOut },

                    new object[] { Keywords.EaseInOut, easeInOut },
                    new object[] { GetUppercasePermutations(Keywords.EaseInOut), easeInOut },

                    //Custom arguments
                    new object[] { "cubic-bezier(0.25, 0.1, 0.25, 1)", new CubicBezierTimingFunction(TokenValue.Empty, 0.25f, 0.1f, 0.25f, 1) },
                    new object[] { "cubic-bezier(0.42, 0, 1, 1)", new CubicBezierTimingFunction(TokenValue.Empty, 0.42f, 0, 1, 1) },
                    new object[] { "cubic-bezier(0, 0, 0.58, 1)", new CubicBezierTimingFunction(TokenValue.Empty, 0, 0, 0.58f, 1) },
                    new object[] { "cubic-bezier(0.42, 0, 0.58, 1)", new CubicBezierTimingFunction(TokenValue.Empty, 0.42f, 0, 0.58f, 1) },
                    new object[] { "cubic-bezier(0.5, -1, 0.5, -1)", new CubicBezierTimingFunction(TokenValue.Empty, 0.5f, -1, 0.5f, -1)
                }
                };

                return tests;
            }
        }

        public static IEnumerable<object[]> StepTimingFunctionKeywordTestValues
        {
            get
            {
                var stepStart = StepsTimingFunction.StepStart(TokenValue.Empty);
                var stepEnd = StepsTimingFunction.StepEnd(TokenValue.Empty);

                var tests = new List<object[]>
                {
                    //Keywords
                    new object[] { Keywords.StepStart, stepStart },
                    new object[] { GetUppercasePermutations(Keywords.StepStart), stepStart },

                    new object[] { Keywords.StepEnd, stepEnd },
                    new object[] { GetUppercasePermutations(Keywords.StepEnd), stepEnd },

                    //Custom arguments
                    new object[] { "steps(0, jump-start)", new StepsTimingFunction(TokenValue.Empty, 1, Keywords.JumpStart) },
                    new object[] { "steps(0, jump-both)", new StepsTimingFunction(TokenValue.Empty, 1, Keywords.JumpBoth) },
                    new object[] { "steps(1, jump-none)", new StepsTimingFunction(TokenValue.Empty, 1, Keywords.JumpNone) },
                    new object[] { "steps(1, start)", new StepsTimingFunction(TokenValue.Empty, 1, Keywords.Start) },
                    new object[] { "steps(1, end)", new StepsTimingFunction(TokenValue.Empty, 1, Keywords.End) },
                };

                return tests;
            }
        }


        [Theory]
        [MemberData(nameof(CubicBezierTimingFunctionTestValues))]
        public void AnimationTimingFunctionAcceptsCubicBezierTimingFunction(string value, CubicBezierTimingFunction expectedTimingFunction)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.CubicBezierTimingFunction, prop.Value.Kind);
                Assert.Equal(value, prop.ValueText);
                Assert.Equal(value, prop.Original);
                Assert.Equal(prop.Value.As<CubicBezierTimingFunction>(), expectedTimingFunction);
            });
        }

        [Theory]
        [MemberData(nameof(StepTimingFunctionKeywordTestValues))]
        public void AnimationTimingFunctionAcceptsStepTimingFunction(string value, StepsTimingFunction expectedTimingFunction)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.StepsTimingFunction, prop.Value.Kind);
                Assert.Equal(value, prop.ValueText);
                Assert.Equal(value, prop.Original);
                Assert.Equal(prop.Value.As<StepsTimingFunction>(), expectedTimingFunction);
            });
        }

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationTimingFunctionPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("none")]
        [InlineData("foo")]
        [InlineData("cubic-bezier(5,1,1,1)")]
        [InlineData("cubic-bezier(0,1,1,1,1,1,1)")]
        [InlineData("cubic-bezier(-0,-1,-1,-1)")]
        [InlineData("cubic-bezier(0,1,5,1)")]
        [InlineData("cubic-bezier")]
        [InlineData("cubic-bezier()")]
        [InlineData("cubic-bezier(1)")]
        [InlineData("cubic-bezier(1,1)")]
        [InlineData("cubic-bezier(1,1,1)")]
        [InlineData("cubic-bezier(a,b,c,d)")]
        [InlineData("cubic-bezier(1,1,1,a)")]
        [InlineData("cubic-bezier(1,1,a,1)")]
        [InlineData("cubic-bezier(1,a,1,1)")]
        [InlineData("cubic-bezier(a,1,1,1)")]
        [InlineData("step")]
        [InlineData("step-foo")]
        [InlineData("steps(-1, jump-start")]
        [InlineData("steps(0, jump-none)")]
        [InlineData("steps(1, foo)")]
        [InlineData("steps(1, initial)")]
        [InlineData("steps()")]
        [InlineData("steps(a, b)")]
        [InlineData("steps(jump-none)")]
        [InlineData("steps(jump-none, jump-both)")]
        [InlineData("steps(1.45, jump-both)")]
        [InlineData("steps(1, 1, jump-both)")]
        public void AnimationTimingFunctionIllegalValues(string value)
            => TestInvalidValue(value);
    }
}
