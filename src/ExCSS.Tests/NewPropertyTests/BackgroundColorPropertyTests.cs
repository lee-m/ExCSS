using ExCSS.New.Enumerations;
using ExCSS.New.StyleProperties.Background;
using ExCSS.New.Values;
using Xunit;

namespace ExCSS.Tests.NewPropertyTests
{
    public class BackgroundColorPropertyTests : BasePropertyTest<BackgroundColorProperty>
    {
        public BackgroundColorPropertyTests() : base(PropertyNames.BackgroundColor)
        { }

        [Theory]
        [InlineData("#bbff00")]
        [InlineData("#bf0")]
        [InlineData("#11ffee00")]
        [InlineData("#1fe7")]
        [InlineData("#11ffeeff")]
        [InlineData("#1fef")]
        public void BackgroundColorPropertyAcceptsHexColours(string value)
            => TestAcceptsColor(value, ColorValue.FromHex(TokenValue.FromString(value), value.TrimStart('#')));

        [Theory]
        [InlineData("red")]
        [InlineData("indigo")]
        [InlineData("transparent")]
        public void BackgroundColorPropertyAcceptsNamedColours(string value)
            => TestAcceptsColor(value, ColorValue.FromName(TokenValue.FromString(value), value));

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
            => TestAcceptsColor(value, ColorValue.FromRgba(TokenValue.FromString(value), 
                                                           expectedRed, expectedGreen, expectedBlue, expectedAlpha));

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
            => TestAcceptsColor(value, ColorValue.FromHsla(TokenValue.FromString(value),
                                                           expectedHue, expectedSaturation, expectedLightness, expectedAlpha));

        [Theory]
        [InlineData("hwb(120, 0%, 0%)", 120, 0, 0)]
        [InlineData("hwb(120deg, 80%, 0%)", 120, 80, 0)]
        public void BackgroundColorPropertyAcceptsHWBColorFunction(string value,
                                                                   float expectedHue,
                                                                   float expectedWhiteness,
                                                                   float expectedBlackness)
            => TestAcceptsColor(value, ColorValue.FromHwb(TokenValue.FromString(value),
                                                          expectedHue, expectedWhiteness, expectedBlackness));

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void BackgroundColorPropertyAcceptsWideKeywords(string value, WideKeyword expected)
            => TestAcceptsEnumKeyword(value, expected);

        [Theory]
        [InlineData("currentcolor")]
        public void BackgroundColorPropertyAcceptsSpecialKeywordColours(string value)
            => TestAcceptsKeyword(value);

        [Theory]
        [InlineData("")]
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
            => TestInvalidValue(value);
    }
}
