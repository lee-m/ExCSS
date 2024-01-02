using System;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class NumericValueConverter : IValueConverter2
    {
        private readonly Func<TokenValue, float?> _innerConverter;
        private readonly NumberUnit _unit;

        public NumericValueConverter(Func<TokenValue, float?> innerConverter, NumberUnit unit)
        {
            _innerConverter = innerConverter;
            _unit = unit;
        }

        public virtual IValue Convert(TokenValue value)
        {
            var x = new NumericValueConverter(ValueExtensions.ToSingle, NumberUnit.Float);

            var element = _innerConverter(value); //value.ToSingle();

            if (element.HasValue)
                return new NumberValue(value, element.Value, _unit);

            return null;
        }
    }
}
