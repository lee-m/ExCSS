using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class AngleValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var angle = value.ToAngle();

            if (angle != null)
                return angle;

            var number = value.ToSingle();

            if (!number.HasValue)
                return null;

            return new AngleValue(value, number.Value, AngleUnit.Deg);
        }
    }
}
