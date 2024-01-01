using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class ListValue<TValue> : IValue where TValue : IValue
    {
        public ListValue(IEnumerable<Token> parsedValue, IList<TValue> values)
        {
            Values = values;
            Original = parsedValue.ToText();
        }

        public override string ToString() => Original;

        public IList<TValue> Values { get; }
        public ValueKind Kind => ValueKind.List;
        public string Original { get; }
    }
}
