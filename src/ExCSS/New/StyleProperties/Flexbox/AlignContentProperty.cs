using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignContentProperty : Property
    {
        internal AlignContentProperty()
            : base(PropertyNames.AlignContent)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var normalConverter = new AllowedKeywordsValueConverter(Keywords.Normal);
            var contentDistributionConverter = new ContentDistributionValueConverter();
            var baselinePositionConverter = new BaselinePositionValueConverter();
            var contentPositionConverter = new ContentPositionValueConverter();
            var wideKeywordConverter = new WideKeywordValueConverter();

            return normalConverter.Convert(newTokenValue)
                   ?? contentDistributionConverter.Convert(newTokenValue)
                   ?? contentPositionConverter.Convert(newTokenValue)
                   ?? baselinePositionConverter.Convert(newTokenValue)
                   ?? wideKeywordConverter.Convert(newTokenValue);
        }

        internal override IValueConverter Converter => null;
    }
}