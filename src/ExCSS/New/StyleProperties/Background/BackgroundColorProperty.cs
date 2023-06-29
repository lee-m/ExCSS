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
            var colorFunction = new ColorFunctionValueConverter();
            var wideKeywordConverter = new WideKeywordValueConverter();
            var specialColourKeywordsConverter = new AllowedKeywordsValueConverter(Keywords.CurrentColor);

            return newTokenValue.ToColor()
                   ?? colorFunction.Convert(newTokenValue)
                   ?? wideKeywordConverter.Convert(newTokenValue)
                   ?? specialColourKeywordsConverter.Convert(newTokenValue);
        }
    }
}