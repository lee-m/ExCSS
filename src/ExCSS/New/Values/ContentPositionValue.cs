using System.Collections.Generic;
using ExCSS.Values;

namespace ExCSS.New.Values
{
    public class ContentPositionValue : PropertyValue<ContentPosition>
    {
        internal ContentPositionValue(IEnumerable<Token> parsedValue, ContentPosition value)
            : base(parsedValue, value)
        { }

        public override ValueKind Kind
            => ValueKind.ContentPosition;
    }
}
