using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class ContentPositionValue : BaseValue
    {
        internal ContentPositionValue(IEnumerable<Token> parsedValue, 
                                      OverflowPositionValue overflow, 
                                      ContentPositionKeyword keyword) : base(parsedValue)
        {
            Overflow = overflow;
            Keyword = keyword;
        }

        public OverflowPositionValue Overflow { get; }
        public ContentPositionKeyword Keyword { get; }

        public override ValueKind Kind => ValueKind.ContentPosition;
    }
}
