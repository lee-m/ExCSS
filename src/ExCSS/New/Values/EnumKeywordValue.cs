using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public class EnumKeywordValue<T> : BaseValue where T : unmanaged
    {
        internal EnumKeywordValue(IEnumerable<Token> parsedValue, T enumKeyword) : base(parsedValue)
        {
            Keyword = enumKeyword;
        }

        public T Keyword { get; }
        public override ValueKind Kind => ValueKind.EnumKeyword;
    }
}
