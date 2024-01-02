using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationDirectionProperty : Property
    {
        internal AnimationDirectionProperty()
            : base(PropertyNames.AnimationDirection)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.AnimationDirections, new CombiListValueConverter(Converters.AnimationDirections) };
    }
}