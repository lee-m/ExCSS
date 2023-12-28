using System;
using System.Collections.Generic;
using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class ColorValue : BaseValue, IEquatable<ColorValue>, IComparable<ColorValue>, IFormattable
    {
        private readonly byte _alpha;
        private readonly byte _red;
        private readonly byte _green;
        private readonly byte _blue;

        #region Basic colors

        /// <summary>
        ///      #000000.
        /// </summary>
        public static readonly ColorValue Black = new(TokenValue.Empty, 0, 0, 0);

        /// <summary>
        ///      #FFFFFF.
        /// </summary>
        public static readonly ColorValue White = new(TokenValue.Empty, 255, 255, 255);

        /// <summary>
        ///      #FF0000.
        /// </summary>
        public static readonly ColorValue Red = new(TokenValue.Empty, 255, 0, 0);

        /// <summary>
        ///      #FF00FF.
        /// </summary>
        public static readonly ColorValue Magenta = new(TokenValue.Empty, 255, 0, 255);

        /// <summary>
        ///      #008000.
        /// </summary>
        public static readonly ColorValue Green = new(TokenValue.Empty, 0, 128, 0);

        /// <summary>
        ///      #00FF00.
        /// </summary>
        public static readonly ColorValue PureGreen = new(TokenValue.Empty, 0, 255, 0);

        /// <summary>
        ///      #0000FF.
        /// </summary>
        public static readonly ColorValue Blue = new(TokenValue.Empty, 0, 0, 255);

        /// <summary>
        ///      #00000000.
        /// </summary>
        public static readonly ColorValue Transparent = new(TokenValue.Empty, 0, 0, 0, 0);

        #endregion

        public ColorValue(IEnumerable<Token> parsedValue, byte r, byte g, byte b) : base(parsedValue)
        {
            _alpha = 255;
            _red = r;
            _blue = b;
            _green = g;
        }

        public ColorValue(IEnumerable<Token> parsedValue, byte red, byte green, byte blue, byte alpha) : base(parsedValue)
        {
            _alpha = alpha;
            _red = red;
            _blue = blue;
            _green = green;
        }

        public static ColorValue FromRgba(TokenValue parsedValue, byte red, byte green, byte blue, float alpha)
        {
            return new(parsedValue, red, green, blue, Normalize(alpha));
        }

        public static ColorValue FromRgba(TokenValue parsedValue, float red, float green, float blue, float alpha)
        {
            return new(parsedValue, Normalize(red), Normalize(green), Normalize(blue), Normalize(alpha));
        }

        public static ColorValue FromGray(TokenValue parsedValue, byte number, float alpha = 1f)
        {
            return new(parsedValue, number, number, number, Normalize(alpha));
        }

        public static ColorValue FromGray(TokenValue parsedValue, float value, float alpha = 1f)
        {
            return FromGray(parsedValue, Normalize(value), alpha);
        }

        public static ColorValue FromName(TokenValue parsedValue, string name)
        {
            var namedColor = Colors.GetColor(name);

            if (namedColor == null)
                return null;

            return new ColorValue(parsedValue, namedColor.R, namedColor.G, namedColor.B);
        }

        public static ColorValue FromRgb(TokenValue parsedValue, byte red, byte green, byte blue)
        {
            return new(parsedValue, red, green, blue);
        }

        public static ColorValue FromHex(TokenValue parsedValue, string ColorValue)
        {
            int r = 0, g = 0, b = 0, a = 255;

            switch (ColorValue.Length)
            {
                case 4:
                    a = 17 * ColorValue[3].FromHex();
                    goto case 3;
                case 3:
                    r = 17 * ColorValue[0].FromHex();
                    g = 17 * ColorValue[1].FromHex();
                    b = 17 * ColorValue[2].FromHex();
                    break;
                case 8:
                    a = 16 * ColorValue[6].FromHex() + ColorValue[7].FromHex();
                    goto case 6;
                case 6:
                    r = 16 * ColorValue[0].FromHex() + ColorValue[1].FromHex();
                    g = 16 * ColorValue[2].FromHex() + ColorValue[3].FromHex();
                    b = 16 * ColorValue[4].FromHex() + ColorValue[5].FromHex();
                    break;
            }

            return new ColorValue(parsedValue, (byte)r, (byte)g, (byte)b, (byte)a);
        }

        public static bool TryFromHex(TokenValue parsedValue, string colorValue, out ColorValue value)
        {
            if (colorValue.Length == 6 || colorValue.Length == 3 || colorValue.Length == 8 || colorValue.Length == 4)
            {
                for (var i = 0; i < colorValue.Length; i++)
                    if (!colorValue[i].IsHex())
                        goto fail;

                value = FromHex(parsedValue, colorValue);
                return true;
            }

        fail:
            value = null;
            return false;
        }

        public static ColorValue FromFlexHex(TokenValue parsedValue, string colorValue)
        {
            var length = Math.Max(colorValue.Length, 3);
            var remaining = length % 3;

            if (remaining != 0) length += 3 - remaining;

            var n = length / 3;
            var d = Math.Min(2, n);
            var s = Math.Max(n - 8, 0);
            var chars = new char[length];

            for (var i = 0; i < colorValue.Length; i++) chars[i] = colorValue[i].IsHex() ? colorValue[i] : '0';

            for (var i = colorValue.Length; i < length; i++) chars[i] = '0';

            if (d == 1)
            {
                var r = chars[0 * n + s].FromHex();
                var g = chars[1 * n + s].FromHex();
                var b = chars[2 * n + s].FromHex();
                return new ColorValue(parsedValue, (byte)r, (byte)g, (byte)b);
            }
            else
            {
                var r = 16 * chars[0 * n + s].FromHex() + chars[0 * n + s + 1].FromHex();
                var g = 16 * chars[1 * n + s].FromHex() + chars[1 * n + s + 1].FromHex();
                var b = 16 * chars[2 * n + s].FromHex() + chars[2 * n + s + 1].FromHex();
                return new ColorValue(parsedValue, (byte)r, (byte)g, (byte)b);
            }
        }

        public static ColorValue FromHsl(TokenValue parsedValue, float hue, float saturation, float luminosity)
        {
            return FromHsla(parsedValue, hue, saturation, luminosity, 1f);
        }

        public static ColorValue FromHsla(TokenValue parsedValue, float hue, float saturation, float luminosity, float alpha)
        {
            const float third = 1f / 3f;

            var m2 = luminosity <= 0.5f
                ? luminosity * (saturation + 1f)
                : luminosity + saturation - luminosity * saturation;

            var m1 = 2f * luminosity - m2;
            var r = Convert(HueToRgb(m1, m2, hue + third));
            var g = Convert(HueToRgb(m1, m2, hue));
            var b = Convert(HueToRgb(m1, m2, hue - third));
            return new ColorValue(parsedValue, r, g, b, Normalize(alpha));
        }

        public static ColorValue FromHwb(TokenValue parsedValue, float hue, float whiteness, float blackness)
        {
            return FromHwba(parsedValue, hue, whiteness, blackness, 1f);
        }

        public static ColorValue FromHwba(TokenValue parsedValue, float hue, float whiteness, float blackness, float alpha)
        {
            var ratio = 1f / (whiteness + blackness);
            if (ratio < 1f)
            {
                whiteness *= ratio;
                blackness *= ratio;
            }

            var p = (int)(6 * hue);
            var f = 6 * hue - p;

            if ((p & 0x01) != 0) f = 1 - f;

            var v = 1 - blackness;
            var n = whiteness + f * (v - whiteness);

            float red;
            float green;
            float blue;
            switch (p)
            {
                default:
                case 6:
                case 0:
                    red = v;
                    green = n;
                    blue = whiteness;
                    break;
                case 1:
                    red = n;
                    green = v;
                    blue = whiteness;
                    break;
                case 2:
                    red = whiteness;
                    green = v;
                    blue = n;
                    break;
                case 3:
                    red = whiteness;
                    green = n;
                    blue = v;
                    break;
                case 4:
                    red = n;
                    green = whiteness;
                    blue = v;
                    break;
                case 5:
                    red = v;
                    green = whiteness;
                    blue = n;
                    break;
            }

            return FromRgba(parsedValue, red, green, blue, alpha);
        }

        public byte A => _alpha;
        public double Alpha => _alpha / 255.0;
        public byte R => _red;
        public byte G => _green;
        public byte B => _blue;
        public override ValueKind Kind => ValueKind.Color;

        public bool Equals(ColorValue other)
        {
            return GetHashCode() == other.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var other = obj as ColorValue;

            if (other != null) 
                return Equals(other);

            return false;
        }

        int IComparable<ColorValue>.CompareTo(ColorValue other)
        {
            return GetHashCode() - other.GetHashCode();
        }

        public override int GetHashCode()
            => new HashCode(_red, _green, _blue, _alpha).GetHashCode();

        public static ColorValue Mix(ColorValue above, ColorValue below)
        {
            return Mix(above.Alpha, above, below);
        }

        public static ColorValue Mix(double alpha, ColorValue above, ColorValue below)
        {
            var gamma = 1.0 - alpha;
            var r = gamma * below.R + alpha * above.R;
            var g = gamma * below.G + alpha * above.G;
            var b = gamma * below.B + alpha * above.B;
            return new ColorValue(TokenValue.Empty, (byte)r, (byte)g, (byte)b);
        }

        private static byte Normalize(float value)
        {
            return (byte)Math.Max(Math.Min(Math.Round(255 * value), 255), 0);
        }

        private static byte Convert(float value)
        {
            return (byte)Math.Round(255f * value);
        }

        private static float HueToRgb(float m1, float m2, float h)
        {
            const float oneSixth = 1f / 6f;
            const float twoThird = 2f / 3f;

            if (h < 0f)
                h += 1f;
            else if (h > 1f) h -= 1f;

            if (h < oneSixth) return m1 + (m2 - m1) * h * 6f;
            if (h < 0.5) return m2;
            if (h < twoThird) return m1 + (m2 - m1) * (twoThird - h) * 6f;

            return m1;
        }

        public override string ToString()
        {
            if (_alpha == 255)
            {
                var arguments = string.Join(", ", R.ToString(), G.ToString(), B.ToString());
                return FunctionNames.Rgb.StylesheetFunction(arguments);
            }
            else
            {
                var arguments = string.Join(", ", R.ToString(), G.ToString(), B.ToString(), Alpha.ToString());
                return FunctionNames.Rgba.StylesheetFunction(arguments);
            }
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (_alpha == 255)
            {
                var arguments = string.Join(", ", R.ToString(format, formatProvider),
                    G.ToString(format, formatProvider),
                    B.ToString(format, formatProvider));
                return FunctionNames.Rgb.StylesheetFunction(arguments);
            }
            else
            {
                var arguments = string.Join(", ", R.ToString(format, formatProvider),
                    G.ToString(format, formatProvider),
                    B.ToString(format, formatProvider), Alpha.ToString(format, formatProvider));
                return FunctionNames.Rgba.StylesheetFunction(arguments);
            }
        }
    }
}