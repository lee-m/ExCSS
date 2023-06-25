using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class KeywordValue : BaseValue
    {
        internal KeywordValue(IEnumerable<Token> parsedValue, string value) : base(parsedValue)
        {
            Keyword = value;
        }

        public string Keyword { get; }
        public override ValueKind Kind => ValueKind.Keyword;
    }
}
