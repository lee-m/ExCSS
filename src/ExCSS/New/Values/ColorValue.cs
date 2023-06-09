using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class ColorValue : PropertyValue<Color>
    {
        public ColorValue(IEnumerable<Token> parsedValue, Color color) : base(parsedValue, color)
        { }

        public override ValueKind Kind
            => ValueKind.Color;
    }
}
