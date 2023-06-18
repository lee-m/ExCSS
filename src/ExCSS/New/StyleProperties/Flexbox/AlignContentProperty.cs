using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignContentProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.AlignContentConverter;

        internal AlignContentProperty()
            : base(PropertyNames.AlignContent)
        { }


        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var normalConverter = new AllowedKeywordsValueConverter(Keywords.Normal);
            var contentDistributionConverter = new AllowedKeywordsValueConverter(Keywords.SpaceBetween, Keywords.SpaceAround, Keywords.SpaceEvenly, Keywords.Stretch);
            var contentPositionConverter = new AllowedKeywordsValueConverter(Keywords.Center, Keywords.Start, Keywords.End, Keywords.FlexStart, Keywords.FlexEnd);
            var baselinePositionConverter = new BaselinePositionValueConverter();

            return normalConverter.Convert(newTokenValue)
                   ?? contentDistributionConverter.Convert(newTokenValue)
                   ?? contentPositionConverter.Convert(newTokenValue)
                   ?? baselinePositionConverter.Convert(newTokenValue);
        }

        internal override IValueConverter Converter => StyleConverter;
    }
}