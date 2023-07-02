using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties
{
    public sealed class AnimationNameProperty : Property
    {
        internal AnimationNameProperty()
            : base(PropertyNames.AnimationName)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<NoneKeywordValueConverter>(newTokenValue)
                   ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }

        internal override IValueConverter Converter => null;
    }

    public class IdentListPropertyValue : BaseValue
    {
        internal IdentListPropertyValue(IEnumerable<Token> parsedValue) : base(parsedValue)
        { }

        public IList<string> Identifiers { get; }

        public override ValueKind Kind => ValueKind.IdentList;
    }
}