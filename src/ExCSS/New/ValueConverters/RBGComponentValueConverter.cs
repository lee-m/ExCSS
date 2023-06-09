using System;
using System.Collections.Generic;
using System.Linq;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class RBGComponentValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            var enumerable = value as Token[] ?? value.ToArray();
            var element = enumerable.ToNaturalInteger();

            if (element.HasValue)
                return new NumberValue(enumerable, new Number(Math.Min(element.Value, 255), Number.Unit.Integer));

            var percent = enumerable.ToPercent();

            if (!percent.HasValue)
                return null;

            return new NumberValue(enumerable, new Number(255f * percent.Value.NormalizedValue, Number.Unit.Integer));
        }
    }
}
