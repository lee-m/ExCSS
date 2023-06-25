using System;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class AlphaComponentValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.ToNaturalSingle();

            if (element.HasValue)
                return new NumberValue(value, Math.Min(element.Value, 1f), NumberUnit.Float);

            return value.ToPercent();
        }
    }
}
