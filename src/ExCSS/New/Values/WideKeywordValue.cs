using System.Collections.Generic;
using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class WideKeywordValue : BaseValue
    {
        internal WideKeywordValue(IEnumerable<Token> parsedValue, WideKeyword keyword) 
            : base(parsedValue)
        {
            Keyword = keyword;
        }

        public WideKeyword Keyword { get; }
        public override ValueKind Kind => ValueKind.WideKeyword;
    }
}
