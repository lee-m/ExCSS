using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class TimeValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.OnlyOrDefault();

            if (element == null || element.Type != TokenType.Dimension)
                return null;

            var token = (UnitToken)element;
            var unit = TimeValue.GetUnit(token.Unit);

            if (unit != TimeUnit.None)
                return new TimeValue(value, token.Value, unit);

            return null;
        }
    }

    internal sealed class TimeListValueConverter : ListValueConverter<TimeValueConverter, TimeValue>
    {
        protected override ListValue<TimeValue> CreateListValue(TokenValue parsedValue, IEnumerable<IValue> convertedValues)
            => new TimeListValue(parsedValue, convertedValues.Cast<TimeValue>().ToList());
    }
}
