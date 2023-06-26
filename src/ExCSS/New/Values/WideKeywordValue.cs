using System.Collections.Generic;
using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class WideKeywordValue : EnumKeywordValue<WideKeyword>
    {
        internal WideKeywordValue(IEnumerable<Token> parsedValue, WideKeyword keyword) 
            : base(parsedValue, ValueKind.WideKeyword, keyword)
        { }
    }
}
