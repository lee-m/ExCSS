using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public abstract class BaseValue : IValue
    {
        private readonly IEnumerable<Token> _parsedValue;

        protected internal BaseValue(IEnumerable<Token> parsedValue)
        {
            _parsedValue = parsedValue;
        }

        public string Original => _parsedValue.ToText();
        public abstract ValueKind Kind { get; }
        public override string ToString() => Original;
    }
}
