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

    public class IdentListValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var idents = new List<string>();

            for(var i = 0; i < value.Count; i++)
            {
                if (value[i].Type != TokenType.Ident)
                    return null;

                idents.Add(value[i].Data);


            }
        }
    }
    public class IdentListPropertyValue : BaseValue
    {
        internal IdentListPropertyValue(IEnumerable<Token> parsedValue) : base(parsedValue)
        { }

        public IList<string> Identifiers { get; }

        public override ValueKind Kind => ValueKind.IdentList;
    }
}