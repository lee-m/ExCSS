using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class IdentifierListValue : ListValue<IdentifierValue>
    {
        internal IdentifierListValue(IEnumerable<Token> parsedValue,
                                     IList<IdentifierValue> identifiers)
            : base(parsedValue, ValueKind.List, identifiers)
        { }
    }
}
