using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class AngleValue : PropertyValue<Angle>
    {
        internal AngleValue(IEnumerable<Token> parsedValue, Angle value) : base(parsedValue, value)
        { }

        public override ValueKind Kind => ValueKind.Angle;
    }
}
