using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class FloatNumericValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.ToSingle();

            if (element.HasValue)
                return new NumberValue(value, element.Value, NumberUnit.Float);

            return null;
        }
    }
}
