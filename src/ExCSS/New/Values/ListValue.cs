using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public abstract class ListValue<TValue> : BaseValue where TValue : IValue
    {
        protected ListValue(IEnumerable<Token> parsedValue,
                            ValueKind kind,
                            IList<TValue> values)
            : base(parsedValue)
        {
            Kind = kind;
            Values = values;
        }

        public IList<TValue> Values { get; }
        public override ValueKind Kind { get; }
    }
}
