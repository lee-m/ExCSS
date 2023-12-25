using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class IdentifierListValue : BaseValue
    {
        internal IdentifierListValue(IEnumerable<Token> parsedValue,
                                     IList<IdentifierValue> identifiers)
            : base(parsedValue)
        {
            Identifiers = identifiers;
        }

        public override ValueKind Kind => ValueKind.IdentifierList;
        public IList<IdentifierValue> Identifiers { get; }
    }
}
