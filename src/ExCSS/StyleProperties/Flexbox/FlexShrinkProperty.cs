﻿namespace ExCSS
{
    internal sealed class FlexShrinkProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexGrowShrinkConverter;

        internal FlexShrinkProperty()
            : base(PropertyNames.FlexShrink)
        { }
    }
}
