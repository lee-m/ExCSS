using System;
using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class ColorFunctionValueConverter : IValueConverter2
    {
        internal ColorFunctionValueConverter()
        { }

        public IValue Convert(IEnumerable<Token> value)
        {
            if (value == null)
                return null;

            var function = value.FirstOrDefault() as FunctionToken;

            if (function == null || !function.IsColorFunction)
                return null;

            var items = function.ArgumentTokens.ToList();
            var arguments = GetArgumentConverters(function.Data);
            var args = new List<IValue>();

            for (var i = 0; i < arguments.Length; i++)
            {
                var item = i < items.Count ? items[i] : Enumerable.Empty<Token>();
                var convertedArg = arguments[i].Convert(item);

                if (convertedArg != null)
                    args.Add(convertedArg);
            }

            var color = GetColor(function.Data, args);

            return color == null ? null : new ColorValue(value, color.Value);
        }

        private IValueConverter2[] GetArgumentConverters(string functionName)
        {
            var rgbConverter = new RBGComponentValueConverter();
            var alphaConverter = new AlphaComponentValueConverter();

            var hue = new AngleValueConverter();
            var percent = new PercentValueConverter();

            switch (functionName)
            {
                case FunctionNames.Rgb:
                case FunctionNames.Rgba:
                    return new IValueConverter2[] { rgbConverter, rgbConverter, rgbConverter, alphaConverter };

                case FunctionNames.Hsl:
                case FunctionNames.Hsla:
                case FunctionNames.Hwb:
                    return new IValueConverter2[] { hue, percent, percent, alphaConverter };

                default:
                    throw new ArgumentException();
            }
        }

        private Color? GetColor(string functionName, List<IValue> arguments)
        {
            if (arguments.Count < 3)
                return null;

            switch (functionName)
            {
                case FunctionNames.Rgb:
                case FunctionNames.Rgba:
                {
                    var r = (byte)arguments[0].As<Number>().Value;
                    var g = (byte)arguments[1].As<Number>().Value;
                    var b = (byte)arguments[2].As<Number>().Value;
                    var a = 1f;

                    //Might have an alpha channel value that is a percentage or a number
                    if (arguments.Count == 4)
                    {
                        a = arguments[3].Kind == ValueKind.Number
                                ? arguments[3].As<Number>().Value
                                : arguments[3].As<Percent>().Value / 100f;
                    }

                    return Color.FromRgba(r, g, b, a);
                }

                case FunctionNames.Hsl:
                case FunctionNames.Hsla:
                case FunctionNames.Hwb:
                {
                    var h = arguments[0].As<Angle>().Value;
                    var saturation_whiteness = arguments[1].As<Percent>().Value;
                    var luminosity_blackness = arguments[2].As<Percent>().Value;
                    var a = 1f;

                    //Might have an alpha channel value that is a percentage or a number
                    if (arguments.Count == 4)
                    {
                        a = arguments[3].Kind == ValueKind.Number
                                ? arguments[3].As<Number>().Value
                                : arguments[3].As<Percent>().Value / 100f;
                    }

                    if (functionName == FunctionNames.Hwb)
                        return Color.FromHwb(h, saturation_whiteness, luminosity_blackness);
                    
                    return Color.FromHsla(h, saturation_whiteness, luminosity_blackness, a);
                }

                default:
                    return null;
            }
        }
    }
}
