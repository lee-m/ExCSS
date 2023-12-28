using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class IntegerValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.ToInteger();

            if (element.HasValue)
                return new NumberValue(value, element.Value, NumberUnit.Integer);

            return null;
        }
    }
}
