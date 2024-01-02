using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class CombiListValueConverter : ListValueConverter<IValue>
    {
        public CombiListValueConverter(params IValueConverter2[] converters) : base(converters)
        { }

        protected override ListValue<IValue> CreateListValue(TokenValue parsedValue, IEnumerable<IValue> convertedValues)
        {
            return new ListValue<IValue>(parsedValue, convertedValues.ToList());
        }
    }
}
