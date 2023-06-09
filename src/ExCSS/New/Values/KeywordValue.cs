using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public class KeywordValue : PropertyValue<string>
    {
        internal KeywordValue(IEnumerable<Token> parsedValue, string value) : base(parsedValue, value)
        { }

        public override ValueKind Kind => ValueKind.Keyword;
    }
}
