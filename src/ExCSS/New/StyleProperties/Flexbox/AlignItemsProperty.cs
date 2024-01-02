using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignItemsProperty : Property
    {
        internal AlignItemsProperty()
            : base(PropertyNames.AlignItems)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
        {
            return new[]
            {
                new AllowedKeywordsValueConverter(Keywords.Normal, Keywords.Stretch),
                Converters.SelfPosition,
                Converters.BaselinePosition
            };
        }
    }
}