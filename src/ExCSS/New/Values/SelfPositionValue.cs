using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class SelfPositionValue : BaseValue
    {        
        internal SelfPositionValue(IEnumerable<Token> parsedValue,
                                   OverflowPositionValue overflow,
                                   SelfPositionKeyword keyword) 
            : base(parsedValue)
        {
            Overflow = overflow;
            Keyword = keyword;
        }

        public override ValueKind Kind => ValueKind.SelfPosition;
        public SelfPositionKeyword Keyword { get; }
        public OverflowPositionValue Overflow { get; }
    }
}
