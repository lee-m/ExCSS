using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class BoundedNumericValueConverter : IValueConverter2
    {
        private readonly IValueConverter2 _converter;
        private readonly float _lowerBound;
        private readonly float _upperBound;

        public BoundedNumericValueConverter(IValueConverter2 converter, float lowerBound, float upperBound)
        {
            _converter = converter;
            _lowerBound = lowerBound;
            _upperBound = upperBound;
        }

        public IValue Convert(TokenValue value)
        {
            var baseValue = _converter.Convert(value);

            if (baseValue == null)
                return null;

            var numberVal = baseValue.As<NumberValue>().Value;

            if (numberVal < _lowerBound || numberVal > _upperBound)
                return null;

            return baseValue;
        }
    }
}
