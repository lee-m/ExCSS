using System;
using System.Collections.Generic;
using System.Linq;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class AlphaComponentValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            var enumerable = value as Token[] ?? value.ToArray();
            var element = enumerable.ToNaturalSingle();

            if (element.HasValue)
                return new NumberValue(enumerable, new Number(Math.Min(element.Value, 1f), Number.Unit.Float));

            var percent = enumerable.ToPercent();

            if (percent.HasValue)
                return new PercentValue(enumerable, percent.Value);

            return null;
        }
    }
}
