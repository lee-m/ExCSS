using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignSelfProperty : Property
    {
        internal class AlignSelfAllowedKeywordsValueConverter : AllowedKeywordsValueConverter
        {
            public AlignSelfAllowedKeywordsValueConverter()
                : base(Keywords.Auto, Keywords.Normal, Keywords.Stretch)
            { }
        }

        internal AlignSelfProperty()
            : base(PropertyNames.AlignSelf)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<AlignSelfAllowedKeywordsValueConverter>(newTokenValue)
                   ?? TryConvert<SelfPositionValueConverter>(newTokenValue)
                   ?? TryConvert<BaselinePositionValueConverter>(newTokenValue)
                   ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }

        internal override IValueConverter Converter => null;
    }
}
