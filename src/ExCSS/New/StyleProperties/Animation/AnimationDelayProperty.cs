using System.Collections.Generic;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationDelayProperty : Property
    {
        internal AnimationDelayProperty() : base(PropertyNames.AnimationDelay)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.Time, Converters.TimeList };
    }
}
