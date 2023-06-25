using System;
using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class RBGComponentValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.ToNaturalInteger();

            if (element.HasValue)
                return new NumberValue(value, Math.Min(element.Value, 255), NumberUnit.Integer);

            var percent = value.ToPercent();

            if (percent == null)
                return null;

            return new NumberValue(value, 255f * percent.NormalizedValue, NumberUnit.Integer);
        }
    }
}
