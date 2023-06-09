using ExCSS.New;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests
{
    public class AllPropertyTests : CssConstructionFunctions
    {
        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AllPropertyAcceptsWideKeywords(string value)
        {
            var property = ParseDeclaration($"all: {value}");

            Assert.Equal("all", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<AllProperty>(property);

            var concrete = (AllProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Keyword, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var keyword = concrete.Value.As<string>();

            Assert.NotNull(keyword);
            Assert.Equal(value, keyword);
        }

    }
}
