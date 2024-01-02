using Xunit;

namespace ExCSS.Tests
{
    public class AnimationPropertyTests : CssConstructionFunctions
    {
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
