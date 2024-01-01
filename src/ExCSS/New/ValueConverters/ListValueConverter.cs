using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal abstract class ListValueConverter<TValue> : IValueConverter2 where TValue : IValue
    {
        private readonly IEnumerable<IValueConverter2> _converters;

        protected ListValueConverter(params IValueConverter2[] converters)
        {
            _converters = converters;
        }

        public IValue Convert(TokenValue value)
        {
            var tokenList = value.ToList();
            var values = new List<IValue>();

            foreach(var token in tokenList)
            {
                var convertedValue = TryConvertValue(new TokenValue(token));

                if (convertedValue == null)
                    return null;

                values.Add(convertedValue);
            }

            return CreateListValue(value, values);
        }

        private IValue TryConvertValue(TokenValue value)
        {
            foreach(var converter in _converters)
            {
                var convertedValue = converter.Convert(value);

                if (convertedValue != null)
                    return convertedValue;
            }

            return null;
        }

        protected abstract ListValue<TValue> CreateListValue(TokenValue parsedValue, IEnumerable<IValue> convertedValues);
    }
}
