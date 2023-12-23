﻿namespace ExCSS
{
    internal sealed class FlexDirectionProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexDirectionConverter;

        internal FlexDirectionProperty()
            : base(PropertyNames.FlexDirection)
        { }
    }
}