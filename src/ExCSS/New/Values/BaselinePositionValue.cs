using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class BaselinePositionValue : PropertyValue<BaselinePosition>
    {
        public BaselinePositionValue(IEnumerable<Token> parsedValue, 
                                     BaselinePosition value) 
            : base(parsedValue, value)
        { }

        public override ValueKind Kind => ValueKind.BaselinePosition;
    }
}
