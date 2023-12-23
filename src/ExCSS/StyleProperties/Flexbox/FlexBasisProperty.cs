﻿namespace ExCSS
{
    internal sealed class FlexBasisProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.FlexBasisConverter;

        internal FlexBasisProperty()
            : base(PropertyNames.FlexBasis)
        { }
    }
}