using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Flexbox
{
    public sealed class AlignContentProperty : Property
    {
        internal AlignContentProperty()
            : base(PropertyNames.AlignContent)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
        {
            return new[]
            {
                new AllowedKeywordsValueConverter(Keywords.Normal),
                Converters.ContentDistribution,
                Converters.BaselinePosition,
                Converters.ContentPosition,
                Converters.WideKeyword
            };
        }
    }
}