using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Background
{
    public sealed class BackgroundColorProperty : Property
    {
        internal BackgroundColorProperty()
            : base(PropertyNames.BackgroundColor, PropertyFlags.Hashless | PropertyFlags.Animatable)
        { }

        internal override IValueConverter Converter => null;

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return newTokenValue.ToColor()
                   ?? TryConvert<ColorFunctionValueConverter>(newTokenValue)
                   ?? TryConvert<WideKeywordValueConverter>(newTokenValue)
                   ?? TryConvert<CurrentColorKeywordValueConverter>(newTokenValue);
        }
    }
}