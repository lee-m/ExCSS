using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public abstract class EnumKeywordValue<T> : BaseValue where T: unmanaged
    {
        protected EnumKeywordValue(IEnumerable<Token> parsedValue, ValueKind valueKind, T enumKeyword) : base(parsedValue)
        {
            Keyword = enumKeyword;
            Kind = valueKind;
        }
        public T Keyword { get; }
        public override ValueKind Kind { get; }
    }
}
