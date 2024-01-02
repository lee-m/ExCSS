using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationNameProperty : Property
    {
        internal AnimationNameProperty() : base(PropertyNames.AnimationName)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
        {
            return new[]
            {
                new AllowedKeywordsValueConverter(Keywords.None),
                Converters.Identifier,
                Converters.IdentifierList
            };
        }
    }
}