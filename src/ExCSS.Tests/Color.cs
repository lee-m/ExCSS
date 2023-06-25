using ExCSS.New.Values;
using ExCSS;

using Xunit;

namespace ExCSS.Tests
{
    public class ColorTests
    {
        [Fact]
        public void TestMethod1()
        {
            var parser = new StylesheetParser();
            parser.Parse("body .class #item:hover{ background-color: red;}");
        }
        [Fact]
        public void ColorInvalidHexDigitString()
        {
            var color = "BCDEFG";
            var result = ColorValue.TryFromHex(TokenValue.Empty, color, out _);
            Assert.False(result);
        }

        [Fact]
        public void ColorValidFourLetterString()
        {
            var color = "abcd";
            var result = ColorValue.TryFromHex(TokenValue.Empty, color, out ColorValue hc);
            Assert.Equal(new ColorValue(TokenValue.Empty, 170, 187, 204, 221), hc);
            Assert.True(result);
        }

        [Fact]
        public void ColorInvalidLengthString()
        {
            var color = "abcde";
            var result = ColorValue.TryFromHex(TokenValue.Empty, color, out _);
            Assert.False(result);
        }

        [Fact]
        public void ColorValidLengthShortString()
        {
            var color = "fff";
            var result = ColorValue.TryFromHex(TokenValue.Empty, color, out _);
            Assert.True(result);
        }

        [Fact]
        public void ColorValidLengthLongString()
        {
            var color = "fffabc";
            var result = ColorValue.TryFromHex(TokenValue.Empty, color, out _);
            Assert.True(result);
        }

        [Fact]
        public void ColorWhiteShortString()
        {
            var color = "fff";
            var result = ColorValue.FromHex(TokenValue.Empty, color);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 255, 255, 255), result);
        }

        [Fact]
        public void ColorRedShortString()
        {
            var color = "f00";
            var result = ColorValue.FromHex(TokenValue.Empty, color);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 255, 0, 0), result);
        }

        [Fact]
        public void ColorFromRedName()
        {
            var color = "red";
            var result = ColorValue.FromName(TokenValue.Empty, color);
            Assert.NotNull(result);
            Assert.Equal(ColorValue.Red, result);
        }

        [Fact]
        public void ColorFromWhiteName()
        {
            var color = "white";
            var result = ColorValue.FromName(TokenValue.Empty, color);
            Assert.NotNull(result);
            Assert.Equal(ColorValue.White, result);
        }

        [Fact]
        public void ColorFromUnknownName()
        {
            var color = "bla";
            var result = ColorValue.FromName(TokenValue.Empty, color);
            Assert.Null(result);
        }

        [Fact]
        public void ColorMixedLongString()
        {
            var color = "facc36";
            var result = ColorValue.FromHex(TokenValue.Empty, color);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 250, 204, 54), result);
        }

        [Fact]
        public void ColorMixedEightDigitLongStringTransparent()
        {
            var color = "facc3600";
            var result = ColorValue.FromHex(TokenValue.Empty, color);
            Assert.Equal(ColorValue.FromRgba(TokenValue.Empty, 250, 204, 54, 0), result);
        }

        [Fact]
        public void ColorMixedEightDigitLongStringOpaque()
        {
            var color = "facc36ff";
            var result = ColorValue.FromHex(TokenValue.Empty, color);
            Assert.Equal(ColorValue.FromRgba(TokenValue.Empty, 250, 204, 54, 1), result);
        }

        [Fact]
        public void ColorMixBlackOnWhite50Percent()
        {
            var color1 = ColorValue.Black;
            var color2 = ColorValue.White;
            var mix = ColorValue.Mix(0.5, color1, color2);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 127, 127, 127), mix);
        }

        [Fact]
        public void ColorMixRedOnWhite75Percent()
        {
            var color1 = ColorValue.Red;
            var color2 = ColorValue.White;
            var mix = ColorValue.Mix(0.75, color1, color2);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 255, 63, 63), mix);
        }

        [Fact]
        public void ColorMixBlueOnWhite10Percent()
        {
            var color1 = ColorValue.Blue;
            var color2 = ColorValue.White;
            var mix = ColorValue.Mix(0.1, color1, color2);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 229, 229, 255), mix);
        }

        [Fact]
        public void ColorMixGreenOnRed30Percent()
        {
            var color1 = ColorValue.PureGreen;
            var color2 = ColorValue.Red;
            var mix = ColorValue.Mix(0.3, color1, color2);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 178, 76, 0), mix);
        }

        [Fact]
        public void ColorMixWhiteOnBlack20Percent()
        {
            var color1 = ColorValue.White;
            var color2 = ColorValue.Black;
            var mix = ColorValue.Mix(0.2, color1, color2);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 51, 51, 51), mix);
        }

        [Fact]
        public void ColorHslBlackMixed()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 0, 1, 0);
            Assert.Equal(ColorValue.Black, color);
        }

        [Fact]
        public void ColorHslBlackMixed1()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 0, 1, 0);
            Assert.Equal(ColorValue.Black, color);
        }

        [Fact]
        public void ColorHslBlackMixed2()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 0.5f, 1, 0);
            Assert.Equal(ColorValue.Black, color);
        }

        [Fact]
        public void ColorHslRedPure()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 0, 1, 0.5f);
            Assert.Equal(ColorValue.Red, color);
        }

        [Fact]
        public void ColorHslGreenPure()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 1f / 3f, 1, 0.5f);
            Assert.Equal(ColorValue.PureGreen, color);
        }

        [Fact]
        public void ColorHslBluePure()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 2f / 3f, 1, 0.5f);
            Assert.Equal(ColorValue.Blue, color);
        }

        [Fact]
        public void ColorHslBlackPure()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 0, 0, 0);
            Assert.Equal(ColorValue.Black, color);
        }

        [Fact]
        public void ColorHslMagentaPure()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 300f / 360f, 1, 0.5f);
            Assert.Equal(ColorValue.Magenta, color);
        }

        [Fact]
        public void ColorHslYellowGreenMixed()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 1f / 4f, 0.75f, 0.63f);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 161, 231, 90), color);
        }

        [Fact]
        public void ColorHslGrayBlueMixed()
        {
            var color = ColorValue.FromHsl(TokenValue.Empty, 210f / 360f, 0.25f, 0.25f);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 48, 64, 80), color);
        }

        [Fact]
        public void ColorFlexHexOneLetter()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "F");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0xf, 0x0, 0x0), color);
        }

        [Fact]
        public void ColorFlexHexTwoLetters()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "0F");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0x0, 0xf, 0x0), color);
        }

        [Fact]
        public void ColorFlexHexFourLetters()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "0F0F");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0xf, 0xf, 0x0), color);
        }

        [Fact]
        public void ColorFlexHexSevenLetters()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "0F0F0F0");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0xf, 0xf0, 0x0), color);
        }

        [Fact]
        public void ColorFlexHexFifteenLetters()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "1234567890ABCDE");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0x12, 0x67, 0xab), color);
        }

        [Fact]
        public void ColorFlexHexExtremelyLong()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "1234567890ABCDE1234567890ABCDE");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0x34, 0xcd, 0x89), color);
        }

        [Fact]
        public void ColorFlexHexRandomString()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "6db6ec49efd278cd0bc92d1e5e072d68");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0x6e, 0xcd, 0xe0), color);
        }

        [Fact]
        public void ColorFlexHexSixLettersInvalid()
        {
            var color = ColorValue.FromFlexHex(TokenValue.Empty, "zqbttv");
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 0x0, 0xb0, 0x0), color);
        }

        [Fact]
        public void ColorFromGraySimple()
        {
            var color = ColorValue.FromGray(TokenValue.Empty, 25);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 25, 25, 25), color);
        }

        [Fact]
        public void ColorFromGrayWithAlpha()
        {
            var color = ColorValue.FromGray(TokenValue.Empty, 25, 0.5f);
            Assert.Equal(ColorValue.FromRgba(TokenValue.Empty, 25, 25, 25, 0.5f), color);
        }

        [Fact]
        public void ColorFromGrayPercent()
        {
            var color = ColorValue.FromGray(TokenValue.Empty, 0.5f, 0.5f);
            Assert.Equal(ColorValue.FromRgba(TokenValue.Empty, 128, 128, 128, 0.5f), color);
        }

        [Fact]
        public void ColorFromHwbRed()
        {
            var color = ColorValue.FromHwb(TokenValue.Empty, 0f, 0.2f, 0.2f);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 204, 51, 51), color);
        }

        [Fact]
        public void ColorFromHwbGreen()
        {
            var color = ColorValue.FromHwb(TokenValue.Empty, 1f / 3f, 0.2f, 0.6f);
            Assert.Equal(ColorValue.FromRgb(TokenValue.Empty, 51, 102, 51), color);
        }

        [Fact]
        public void ColorFromHwbMagentaTransparent()
        {
            var color = ColorValue.FromHwba(TokenValue.Empty, 5f / 6f, 0.4f, 0.2f, 0.5f);
            Assert.Equal(ColorValue.FromRgba(TokenValue.Empty, 204, 102, 204, 0.5f), color);
        }
    }
}
