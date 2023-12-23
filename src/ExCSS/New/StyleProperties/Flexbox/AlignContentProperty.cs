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
            return TryConvert<NormalKeywordValueConverter>(newTokenValue)
                   ?? TryConvert<ContentDistributionValueConverter>(newTokenValue)
                   ?? TryConvert<BaselinePositionValueConverter>(newTokenValue)
                   ?? TryConvert<ContentPositionValueConverter>(newTokenValue)
                   ?? TryConvert<WideKeywordValueConverter>(newTokenValue);
        }
    }
}