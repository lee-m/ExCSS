using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class BaselinePositionValue : BaseValue
    {
        internal BaselinePositionValue(IEnumerable<Token> parsedValue, bool? first, bool? last)
            : base(parsedValue)
        {
            First = first;
            Last = last;
        }

        public bool? First { get; }
        public bool? Last { get; }

        public override ValueKind Kind => ValueKind.BaselinePosition;
    }
}
