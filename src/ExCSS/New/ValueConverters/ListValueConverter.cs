using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal abstract class ListValueConverter<TValueConverter, TValue> : IValueConverter2 
        where TValueConverter: IValueConverter2, new()
        where TValue : IValue
    {
        public IValue Convert(TokenValue value)
        {
            var tokenList = value.ToList();
            var values = new List<IValue>();
            var valueConverter = new TValueConverter();

            foreach(var token in tokenList)
            {
                var convertedValue = valueConverter.Convert(new TokenValue(token));

                if (convertedValue == null)
                    return null;

                values.Add(convertedValue);
            }

            return CreateListValue(value, values);
        }

        protected abstract ListValue<TValue> CreateListValue(TokenValue parsedValue, IEnumerable<IValue> convertedValues);
    }
}
