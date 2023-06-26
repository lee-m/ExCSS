using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class ContentPositionValue : EnumKeywordValue<ContentPositionKeyword>
    {
        internal ContentPositionValue(IEnumerable<Token> parsedValue, 
                                      OverflowPositionValue overflow, 
                                      ContentPositionKeyword keyword) 
            : base(parsedValue, ValueKind.ContentPosition, keyword)
        {
            Overflow = overflow;
        }

        public OverflowPositionValue Overflow { get; }
    }
}
