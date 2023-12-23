﻿namespace ExCSS
{
    internal sealed class FlexWrapProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexWrapConverter;

        internal FlexWrapProperty()
            : base(PropertyNames.FlexWrap)
        { }
    }
}
