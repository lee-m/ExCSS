using ExCSS.New.StyleProperties;
using Xunit;

namespace ExCSS.Tests
{
    public class AnimationPropertyTests : CssConstructionFunctions
    {
        [Fact]
        public void AnimationDurationMillisecondsLegal()
        {
            var snippet = "animation-duration : 60ms";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-duration", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDurationProperty>(property);
            var concrete = (AnimationDurationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("60ms", concrete.ValueText);
        }

        [Fact]
        public void AnimationDurationMultipleSecondsLegal()
        {
            var snippet = "animation-duration : 1s  , 2s  , 3s  , 4s";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-duration", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDurationProperty>(property);
            var concrete = (AnimationDurationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("1s, 2s, 3s, 4s", concrete.ValueText);
        }

        [Fact]
        public void AnimationDelayMillisecondsLegal()
        {
            var snippet = "animation-delay : 0ms";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-delay", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDelayProperty>(property);
            var concrete = (AnimationDelayProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("0ms", concrete.ValueText);
        }

        [Fact]
        public void AnimationDelayZeroIllegal()
        {
            var snippet = "animation-delay : 0";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-delay", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDelayProperty>(property);
            var concrete = (AnimationDelayProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationDelayZeroZeroSecondMillisecondsLegal()
        {
            var snippet = "animation-delay : 0s  , 0s  , 1s  , 20ms";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-delay", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDelayProperty>(property);
            var concrete = (AnimationDelayProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("0s, 0s, 1s, 20ms", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameDashSpecificLegal()
        {
            var snippet = "animation-name : -specific";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-name", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationNameProperty>(property);
            var concrete = (AnimationNameProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("-specific", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameSlidingVerticallyLegal()
        {
            var snippet = "animation-name : sliding-vertically";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-name", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationNameProperty>(property);
            var concrete = (AnimationNameProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("sliding-vertically", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameTest05Legal()
        {
            var snippet = "animation-name : test_05";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-name", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationNameProperty>(property);
            var concrete = (AnimationNameProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("test_05", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameNumberIllegal()
        {
            var snippet = "animation-name : 42";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-name", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationNameProperty>(property);
            var concrete = (AnimationNameProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationNameMyAnimationOtherAnimationLegal()
        {
            var snippet = "animation-name : my-animation, other-animation";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-name", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationNameProperty>(property);
            var concrete = (AnimationNameProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("my-animation, other-animation", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountZeroLegal()
        {
            var snippet = "animation-iteration-count : 0";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("0", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountInfiniteLegal()
        {
            var snippet = "animation-iteration-count : infinite";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("infinite", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountInfiniteUppercaseLegal()
        {
            var snippet = "animation-iteration-count : INFINITE";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("infinite", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountFloatLegal()
        {
            var snippet = "animation-iteration-count : 2.3";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("2.3", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountTwoZeroInfiniteLegal()
        {
            var snippet = "animation-iteration-count : 2, 0, infinite";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("2, 0, infinite", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountNegativeIllegal()
        {
            var snippet = "animation-iteration-count : -1";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-iteration-count", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationIterationCountProperty>(property);
            var concrete = (AnimationIterationCountProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationTimingFunctionEaseUppercaseLegal()
        {
            var snippet = "animation-timing-function : EASE";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("ease", concrete.ValueText);
        }

        [Fact]
        public void AnimationTimingFunctionNoneIllegal()
        {
            var snippet = "animation-timing-function : none";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationTimingFunctionEaseInOutLegal()
        {
            var snippet = "animation-timing-function : ease-IN-out";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("ease-in-out", concrete.ValueText);
        }

        [Fact]
        public void AnimationTimingFunctionStepEndLegal()
        {
            var snippet = "animation-timing-function : step-END";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("step-end", concrete.ValueText);
        }

        [Fact]
        public void AnimationTimingFunctionStepStartLinearLegal()
        {
            var snippet = "animation-timing-function : step-start  , LINeAr";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("step-start, linear", concrete.ValueText);
        }

        [Fact]
        public void AnimationTimingFunctionStepStartCubicBezierLegal()
        {
            var snippet = "animation-timing-function : step-start  , cubic-bezier(0,1,1,1)";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-timing-function", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationTimingFunctionProperty>(property);
            var concrete = (AnimationTimingFunctionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("step-start, cubic-bezier(0, 1, 1, 1)", concrete.ValueText);
        }

        [Fact]
        public void AnimationPlayStateRunningLegal()
        {
            var snippet = "animation-play-state: running";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-play-state", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationPlayStateProperty>(property);
            var concrete = (AnimationPlayStateProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("running", concrete.ValueText);
        }

        [Fact]
        public void AnimationPlayStatePausedUppercaseLegal()
        {
            var snippet = "animation-play-state: PAUSED";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-play-state", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationPlayStateProperty>(property);
            var concrete = (AnimationPlayStateProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("paused", concrete.ValueText);
        }

        [Fact]
        public void AnimationPlayStatePausedRunningPausedLegal()
        {
            var snippet = "animation-play-state: paused, Running, paused";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-play-state", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationPlayStateProperty>(property);
            var concrete = (AnimationPlayStateProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("paused, running, paused", concrete.ValueText);
        }

        [Fact]
        public void AnimationFillModeNoneLegal()
        {
            var snippet = "animation-fill-mode: none";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-fill-mode", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationFillModeProperty>(property);
            var concrete = (AnimationFillModeProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("none", concrete.ValueText);
        }

        [Fact]
        public void AnimationFillModeZeroIllegal()
        {
            var snippet = "animation-fill-mode: 0";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-fill-mode", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationFillModeProperty>(property);
            var concrete = (AnimationFillModeProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationFillModeBackwardsLegal()
        {
            var snippet = "animation-fill-mode: backwards !important";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-fill-mode", property.Name);
            Assert.True(property.IsImportant);
            Assert.IsType<AnimationFillModeProperty>(property);
            var concrete = (AnimationFillModeProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("backwards", concrete.ValueText);
        }

        [Fact]
        public void AnimationFillModeForwardsUppercaseLegal()
        {
            var snippet = "animation-fill-mode: FORWARDS";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-fill-mode", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationFillModeProperty>(property);
            var concrete = (AnimationFillModeProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("forwards", concrete.ValueText);
        }

        [Fact]
        public void AnimationFillModeBothBackwardsForwardsNoneLegal()
        {
            var snippet = "animation-fill-mode: both , backwards ,  forwards  ,NONE";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-fill-mode", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationFillModeProperty>(property);
            var concrete = (AnimationFillModeProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("both, backwards, forwards, none", concrete.ValueText);
        }

        [Fact]
        public void AnimationDirectionNormalLegal()
        {
            var snippet = "animation-direction: normal";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-direction", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDirectionProperty>(property);
            var concrete = (AnimationDirectionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("normal", concrete.ValueText);
        }

        [Fact]
        public void AnimationDirectionReverseLegal()
        {
            var snippet = "animation-direction  : reverse";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-direction", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDirectionProperty>(property);
            var concrete = (AnimationDirectionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("reverse", concrete.ValueText);
        }

        [Fact]
        public void AnimationDirectionNoneIllegal()
        {
            var snippet = "animation-direction  : none";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-direction", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDirectionProperty>(property);
            var concrete = (AnimationDirectionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationDirectionAlternateReverseUppercaseLegal()
        {
            var snippet = "animation-direction : alternate-REVERSE";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-direction", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationDirectionProperty>(property);
            var concrete = (AnimationDirectionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("alternate-reverse", concrete.ValueText);
        }

        [Fact]
        public void AnimationDirectionNormalAlternateReverseAlternateReverseLegal()
        {
            var snippet = "animation-direction: normal,alternate  , reverse   ,ALTERNATE-reverse !important";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation-direction", property.Name);
            Assert.True(property.IsImportant);
            Assert.IsType<AnimationDirectionProperty>(property);
            var concrete = (AnimationDirectionProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("normal, alternate, reverse, alternate-reverse", concrete.ValueText);
        }

        [Fact]
        public void AnimationIterationCountLegal()
        {
            var snippet = "animation : 5";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("5", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameLegal()
        {
            var snippet = "animation : my-animation";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("my-animation", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameDurationDelayLegal()
        {
            var snippet = "animation : my-animation 2s 0.5s";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("2s 0.5s my-animation", concrete.ValueText);
        }

        [Fact]
        public void AnimationNameDurationDelayEaseLegal()
        {
            var snippet = "animation : my-animation  200ms 0.5s    ease";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("200ms ease 0.5s my-animation", concrete.ValueText);
        }

        [Fact]
        public void AnimationCountDoubleIllegal()
        {
            var snippet = "animation : 10 20";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.False(concrete.HasValue);
        }

        [Fact]
        public void AnimationNameDurationCountEaseInOutLegal()
        {
            var snippet = "animation : my-animation  200ms 2.5   ease-in-out";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("200ms ease-in-out 2.5 my-animation", concrete.ValueText);
        }

        [Fact]
        public void AnimationMultipleLegal()
        {
            var snippet = "animation : my-animation 0s 10 ease,   other-animation  5 linear,yet-another 0s 1s  10 step-start !important";
            var property = ParseDeclaration(snippet);
            Assert.Equal("animation", property.Name);
            Assert.True(property.IsImportant);
            Assert.IsType<AnimationProperty>(property);
            var concrete = (AnimationProperty)property;
            Assert.False(concrete.IsInherited);
            Assert.True(concrete.HasValue);
            Assert.Equal("0s ease 10 my-animation, linear 5 other-animation, 0s step-start 1s 10 yet-another", concrete.ValueText);
        }
    }
}
