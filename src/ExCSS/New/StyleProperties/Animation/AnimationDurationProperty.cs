using System.Collections.Generic;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationDurationProperty : Property
    {
        internal AnimationDurationProperty() : base(PropertyNames.AnimationDuration)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.Time, Converters.TimeList };
    }
}
