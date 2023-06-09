using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class PercentValue : PropertyValue<Percent>
    {
        public PercentValue(IEnumerable<Token> parsedValue, Percent percent) : base(parsedValue, percent)
        { }

        public override ValueKind Kind
            => ValueKind.Percent;
    }
}
