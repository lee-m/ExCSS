using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Background
{
    public sealed class BackgroundColorProperty : Property
    {
        internal BackgroundColorProperty()
            : base(PropertyNames.BackgroundColor, PropertyFlags.Hashless | PropertyFlags.Animatable)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
        {
            return new[]
            {
                Converters.Color,
                Converters.ColorFunction,
                new AllowedKeywordsValueConverter(Keywords.CurrentColor)
            };
        }
    }
}