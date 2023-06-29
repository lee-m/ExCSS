using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignSelfProperty : Property
    {
        internal AlignSelfProperty()
            : base(PropertyNames.AlignSelf)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var keywordsConverter = new AllowedKeywordsValueConverter(Keywords.Auto, Keywords.Normal, Keywords.Stretch);
            var selfPositionConverter = new SelfPositionValueConverter();
            var baselinePositionConverter = new BaselinePositionValueConverter();
            var wideKeywordConverter = new WideKeywordValueConverter();

            return keywordsConverter.Convert(newTokenValue)
                   ?? selfPositionConverter.Convert(newTokenValue)
                   ?? baselinePositionConverter.Convert(newTokenValue)
                   ?? wideKeywordConverter.Convert(newTokenValue);
        }

        internal override IValueConverter Converter => null;
    }
}
