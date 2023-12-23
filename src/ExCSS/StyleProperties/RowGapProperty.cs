﻿namespace ExCSS
{
    internal sealed class RowGapProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.LengthOrPercentConverter
                                                                           .OrGlobalValue()
                                                                           .OrDefault(0);

        internal RowGapProperty()
            : base(PropertyNames.RowGap, PropertyFlags.Animatable)
        { }
    }
}
