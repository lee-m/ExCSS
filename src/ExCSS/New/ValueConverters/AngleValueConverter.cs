using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class AngleValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            var enumerable = value as Token[] ?? value.ToArray();
            var angle = enumerable.ToAngle();

            if (angle.HasValue)
                return new AngleValue(value, angle.Value);

            var number = enumerable.ToSingle();

            if (!number.HasValue)
                return null;

            return new AngleValue(value, new Angle(number.Value, Angle.Unit.Deg));
        }
    }
}
