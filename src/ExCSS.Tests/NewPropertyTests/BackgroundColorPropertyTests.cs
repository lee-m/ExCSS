using ExCSS.New;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests
{
    public class BackgroundColorPropertyTests : CssConstructionFunctions
    {
        [Theory]
        [InlineData("#bbff00")]
        [InlineData("#bf0")]
        [InlineData("#11ffee00")]
        [InlineData("#1fe7")]
        [InlineData("#11ffeeff")]
        [InlineData("#1fef")]
        public void BackgroundColorPropertyAcceptsHexColours(string value)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.Equal(ValueKind.Color, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var color = concrete.Value.As<Color>();
            Assert.True(Color.FromHex(value.TrimStart('#')).Equals(color));
        }

        [Theory]
        [InlineData("red")]
        [InlineData("indigo")]
        [InlineData("transparent")]
        public void BackgroundColorPropertyAcceptsNamedColours(string value)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.Equal(ValueKind.Color, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var color = concrete.Value.As<Color>();
            Assert.True(Color.FromName(value).Equals(color));
        }

        [Theory]
        [InlineData("rgb(255, 255, 128)", 255, 255, 128, 1)]
        [InlineData("rgb(117,190,218,0.5)", 117, 190, 218, 0.5)]
        [InlineData("rgba(117, 190, 218)", 117, 190, 218, 1)]
        [InlineData("rgba(117, 190, 218, 0.5)", 117, 190, 218, 0.5)]
        [InlineData("rgba(117, 190, 218, 50%)", 117, 190, 218, 0.5)]
        public void BackgroundColorPropertyAcceptsRGBColorFunction(string value,
                                                                   byte expectedRed,
                                                                   byte expectedGreen,
                                                                   byte expectedBlue,
                                                                   float expectedAlpha)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Color, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var color = concrete.Value.As<Color>();

            Assert.NotNull(color);
            Assert.True(Color.FromRgba(expectedRed, expectedGreen, expectedBlue, expectedAlpha).Equals(color));
        }

        [Theory]
        [InlineData("hsl(147, 50%, 47%)", 147, 50, 47, 1f)]
        [InlineData("hsl(147deg, 50%, 47%, 0.5)", 147, 50, 47, 0.5f)]
        [InlineData("hsla(147grad, 50%, 47%)", 147, 50, 47, 1f)]
        [InlineData("hsla(147rad, 50%, 47%, 0.5)", 147, 50, 47, 0.5f)]
        [InlineData("hsla(147turn, 50%, 47%, 50%)", 147, 50, 47, 0.5f)]
        [InlineData("hsl(147deg, 50%, 47%)", 147, 50, 47, 1f)]
        [InlineData("hsl(147grad, 50%, 47%, 0.5)", 147, 50, 47, 0.5f)]
        [InlineData("hsla(147rad, 50%, 47%)", 147, 50, 47, 1f)]
        [InlineData("hsla(147turn, 50%, 47%, 0.5)", 147, 50, 47, 0.5f)]
        [InlineData("hsla(147deg, 50%, 47%, 50%)", 147, 50, 47, 0.5f)]
        public void BackgroundColorPropertyAcceptsHSLColorFunction(string value,
                                                                   float expectedHue,
                                                                   float expectedSaturation,
                                                                   float expectedLightness,
                                                                   float expectedAlpha)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Color, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var color = concrete.Value.As<Color>();

            Assert.NotNull(color);
            Assert.True(Color.FromHsla(expectedHue, expectedSaturation, expectedLightness, expectedAlpha).Equals(color));
        }

        [Theory]
        [InlineData("hwb(120, 0%, 0%)", 120, 0, 0)]
        [InlineData("hwb(120deg, 80%, 0%)", 120, 80, 0)]
        public void BackgroundColorPropertyAcceptsHWBColorFunction(string value,
                                                                   float expectedHue,
                                                                   float expectedWhiteness,
                                                                   float expectedBlackness)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Color, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var color = concrete.Value.As<Color>();

            Assert.NotNull(color);
            Assert.True(Color.FromHwb(expectedHue, expectedWhiteness, expectedBlackness).Equals(color));
        }

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void BackgroundColorPropertyAcceptsWideKeywords(string value)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Keyword, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var keyword = concrete.Value.As<string>();

            Assert.NotNull(keyword);
            Assert.Equal(value, keyword);
        }

        [Theory]
        [InlineData("currentcolor")]
        public void BackgroundColorPropertyAcceptsSpecialKeywordColours(string value)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.NotNull(concrete.Value);
            Assert.Equal(ValueKind.Keyword, concrete.Value.Kind);
            Assert.Equal(value, concrete.Original);

            var keyword = concrete.Value.As<string>();

            Assert.NotNull(keyword);
            Assert.Equal(value, keyword);
        }

        [Theory]
        [InlineData("rgb()")]
        [InlineData("rgb(117)")]
        [InlineData("rgba(117, 190)")]
        [InlineData("rgba(1.5, 3.4, 4.5)")]
        [InlineData("rgba(rr, gg, bb, aa)")]
        [InlineData("rgba(117%, 190deg, 57px)")]
        [InlineData("hsl()")]
        [InlineData("hsl(117)")]
        [InlineData("hsl(117, 190)")]
        [InlineData("hsl(1.5, 3.4, 4.5)")]
        [InlineData("hsl(rr, gg, bb, aa)")]
        [InlineData("hsl(117%, 190deg, 57px)")]
        [InlineData("hsla()")]
        [InlineData("hsla(117)")]
        [InlineData("hsla(117, 190)")]
        [InlineData("hsla(1.5, 3.4, 4.5)")]
        [InlineData("hsla(rr, gg, bb, aa)")]
        [InlineData("hsla(117%, 190deg, 57px)")]
        [InlineData("hwb()")]
        [InlineData("hwb(hh, ww, ll")]
        [InlineData("hwb(54px, 64rem, 90")]
        [InlineData("#1")]
        [InlineData("#12")]
        [InlineData("#XYZ")]
        [InlineData("#XXYYZZ")]
        [InlineData("#XXYYZZUU")]
        [InlineData("#AABBCCDDEEFF")]
        public void BackgroundColorPropertyInvalidValue(string value)
        {
            var property = ParseDeclaration($"background-color: {value}");

            Assert.Equal("background-color", property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<BackgroundColorProperty>(property);

            var concrete = (BackgroundColorProperty)property;

            Assert.False(concrete.IsInherited);
            Assert.Null(concrete.Value);
        }
    }
}
