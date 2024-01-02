using System.Collections.Generic;

namespace ExCSS.New.StyleProperties.Animation
{
    public sealed class AnimationTimingFunctionProperty : Property
    {
        internal AnimationTimingFunctionProperty()
            : base(PropertyNames.AnimationTimingFunction)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.TimingFunction };
    }
}