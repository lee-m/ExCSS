using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class SelfPositionValue : EnumKeywordValue<SelfPositionKeyword>
    {        
        internal SelfPositionValue(IEnumerable<Token> parsedValue,
                                   OverflowPositionValue overflow,
                                   SelfPositionKeyword keyword) 
            : base(parsedValue, ValueKind.SelfPosition, keyword)
        {
            Overflow = overflow;
        }

        public OverflowPositionValue Overflow { get; }
    }
}
