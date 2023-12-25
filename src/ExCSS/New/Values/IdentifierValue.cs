using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class IdentifierValue : BaseValue
    {
        internal IdentifierValue(IEnumerable<Token> parsedValue) : base(parsedValue)
        { }

        public override ValueKind Kind => ValueKind.Identifier;
        public string Identifier => Original;
    }
}
