using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignItemsProperty : Property
    {
        internal class AlignItemsAllowedKeywordsValueConverter : AllowedKeywordsValueConverter
        {
            public AlignItemsAllowedKeywordsValueConverter()
                : base(Keywords.Normal, Keywords.Stretch)
            { }
        }

        internal AlignItemsProperty()
            : base(PropertyNames.AlignItems)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            return TryConvert<AlignItemsAllowedKeywordsValueConverter>(newTokenValue)
                   ?? TryConvert<SelfPositionValueConverter>(newTokenValue)
                   ?? TryConvert<BaselinePositionValueConverter>(newTokenValue)
                   ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }
    }
}