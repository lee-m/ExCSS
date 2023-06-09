using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public abstract class PropertyValue<T> : IValue
    {
        private readonly IEnumerable<Token> _parsedValue;

        protected internal PropertyValue(IEnumerable<Token> parsedValue, T value)
        {
            _parsedValue = parsedValue;

            Value = value;
        }

        public string Original => _parsedValue.ToText();
        public T Value { get; }
        public abstract ValueKind Kind { get; }

        public static implicit operator T(PropertyValue<T> val) => val.Value;

        public override string ToString() => Original;
    }
}
