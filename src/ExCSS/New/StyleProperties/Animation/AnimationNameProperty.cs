using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationNameProperty : Property
    {
        private static readonly IValueConverter ListConverter =
            Converters.IdentifierConverter.FromList().OrNone().OrDefault();

        internal AnimationNameProperty() : base(PropertyNames.AnimationName)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<NoneKeywordValueConverter>(newTokenValue)
                ?? TryConvert<WideKeywordValueConverter>(newTokenValue)
                ?? TryConvert<ValueConverters.IdentifierValueConverter>(newTokenValue)
                ?? TryConvert<IdentifierListValueConverter>(newTokenValue);
        }
    }
}