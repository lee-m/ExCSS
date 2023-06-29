﻿using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignItemsProperty : Property
    {
        internal AlignItemsProperty()
            : base(PropertyNames.AlignItems)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var normalStretchConverter = new AllowedKeywordsValueConverter(Keywords.Normal, Keywords.Stretch);
            var selfPositionConverter = new SelfPositionValueConverter();
            var baselinePositionConverter = new BaselinePositionValueConverter();
            var wideKeywordConverter = new WideKeywordValueConverter();

            return normalStretchConverter.Convert(newTokenValue)
                   ?? selfPositionConverter.Convert(newTokenValue)
                   ?? baselinePositionConverter.Convert(newTokenValue)
                   ?? wideKeywordConverter.Convert(newTokenValue);
        }

        internal override IValueConverter Converter => null;
    }
}