using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class NumberValue : PropertyValue<Number>
    {
        public NumberValue(IEnumerable<Token> parsedValue, Number num) : base(parsedValue, num)
        { }

        public override ValueKind Kind
            => ValueKind.Number;
    }
}
