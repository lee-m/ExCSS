using System;
using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class ColorFunctionValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
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
                var item = i < items.Count ? new TokenValue(items[i]) : TokenValue.Empty;
                var convertedArg = arguments[i].Convert(item);

                if (convertedArg != null)
                    args.Add(convertedArg);
            }

            return GetColor(value, function.Data, args);
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

        private ColorValue GetColor(TokenValue parsedValue, string functionName, List<IValue> arguments)
        {
            if (arguments.Count < 3)
                return null;

            switch (functionName)
            {
                case FunctionNames.Rgb:
                case FunctionNames.Rgba:
                {
                    var r = (byte)arguments[0].As<NumberValue>().Value;
                    var g = (byte)arguments[1].As<NumberValue>().Value;
                    var b = (byte)arguments[2].As<NumberValue>().Value;
                    var a = 1f;

                    //Might have an alpha channel value that is a percentage or a number
                    if (arguments.Count == 4)
                    {
                        a = arguments[3].Kind == ValueKind.Number
                                ? arguments[3].As<NumberValue>().Value
                                : arguments[3].As<PercentValue>().Value / 100f;
                    }

                    return ColorValue.FromRgba(parsedValue, r, g, b, a);
                }

                case FunctionNames.Hsl:
                case FunctionNames.Hsla:
                case FunctionNames.Hwb:
                {
                    var h = arguments[0].As<AngleValue>().Value;
                    var saturation_whiteness = arguments[1].As<PercentValue>().Value;
                    var luminosity_blackness = arguments[2].As<PercentValue>().Value;
                    var a = 1f;

                    //Might have an alpha channel value that is a percentage or a number
                    if (arguments.Count == 4)
                    {
                        a = arguments[3].Kind == ValueKind.Number
                                ? arguments[3].As<NumberValue>().Value
                                : arguments[3].As<PercentValue>().Value / 100f;
                    }

                    if (functionName == FunctionNames.Hwb)
                        return ColorValue.FromHwb(parsedValue, h, saturation_whiteness, luminosity_blackness);
                    
                    return ColorValue.FromHsla(parsedValue, h, saturation_whiteness, luminosity_blackness, a);
                }

                default:
                    return null;
            }
        }
    }
}
