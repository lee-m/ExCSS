using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    internal sealed class PercentValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            var element = value.OnlyOrDefault();

            if (element != null && element.Type == TokenType.Percentage)
                return new PercentValue(value, new Percent(((UnitToken)element).Value));

            return null;
        }
    }
}
