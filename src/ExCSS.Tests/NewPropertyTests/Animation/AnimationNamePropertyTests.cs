using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Animation;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests.Animation
{
    public class AnimationNamePropertyTests : BasePropertyTest<AnimationNameProperty>
    {
        public AnimationNamePropertyTests() : base(PropertyNames.AnimationName)
        { }

        [Theory]
        [InlineData("-specific")]
        [InlineData("sliding-vertically")]
        [InlineData("test_05")]
        public void AnimationNameSingleIdentifierLegal(string value)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.Identifier);

                var identifier = prop.Value.As<IdentifierValue>();
                Assert.Equal(value, identifier.Identifier);
                Assert.Equal(value, identifier.Original);
            });
        }

        [Theory]
        [InlineData("none")]
        public void AnimationNameAllowedKeywordsLegal(string value)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.Keyword);

                var identifier = prop.Value.As<KeywordValue>();
                Assert.Equal(value, identifier.Keyword);
                Assert.Equal(value, identifier.Original);
            });
        }

        [Fact]
        public void AnimationNameIdentifierListLegal()
        {
            TestAcceptsValue("my-animation, other-animation", prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.IdentifierList);

                var identifierList = prop.Value.As<IdentifierListValue>();

                Assert.Equal(2, identifierList.Identifiers.Count);
                Assert.Equal("my-animation", identifierList.Identifiers[0].Identifier);
                Assert.Equal("other-animation", identifierList.Identifiers[1].Identifier);
            });
        }

        [Theory]
        [InlineData("42")]
        public void AnimationNameNumberIllegal(string value)
            => TestInvalidValue(value);

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AnimationNamePropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);
    }
}