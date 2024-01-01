using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public sealed class IdentifierListValue : ListValue<IdentifierValue>
    {
        internal IdentifierListValue(IEnumerable<Token> parsedValue, IList<IdentifierValue> identifiers)
            : base(parsedValue, identifiers)
        { }
    }
}
