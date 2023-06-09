using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class BackgroundColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.CurrentColorConverter.OrDefault();

        internal BackgroundColorProperty()
            : base(PropertyNames.BackgroundColor, PropertyFlags.Hashless | PropertyFlags.Animatable)
        { }

        internal override IValueConverter Converter => StyleConverter;

        internal override IValue CoerceValue(TokenValue newTokenValue)
        {
            var colorFunction = new ColorFunctionValueConverter();
            var wideKeywordConverter = new WideKeywordValueConverter();
            var specialColourKeywordsConverter = new AllowedKeywordsValueConverter(Keywords.CurrentColor);

            return newTokenValue.ToColorPropertyValue()
                   ?? colorFunction.Convert(newTokenValue)
                   ?? wideKeywordConverter.Convert(newTokenValue)
                   ?? specialColourKeywordsConverter.Convert(newTokenValue);
        }
    }
}