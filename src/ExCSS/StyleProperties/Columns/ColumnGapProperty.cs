﻿namespace ExCSS
{
    internal sealed class ColumnGapProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.LengthOrPercentConverter
                      .OrGlobalValue()
                      .OrDefault(new Length(1f, Length.Unit.Em));

        internal ColumnGapProperty()
            : base(PropertyNames.ColumnGap, PropertyFlags.Animatable)
        {
        }
    }
}