using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationFillModeProperty : Property
    {
        internal AnimationFillModeProperty()
            : base(PropertyNames.AnimationFillMode)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.AnimationFillModes, new CombiListValueConverter(Converters.AnimationFillModes) };
    }
}