using System.Collections.Generic;

using ExCSS.New.ValueConverters;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationPlayStateProperty : Property
    {
        internal AnimationPlayStateProperty()
            : base(PropertyNames.AnimationPlayState)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.AnimationPlayStates, new CombiListValueConverter(Converters.AnimationPlayStates) };
    }
}