﻿namespace ExCSS
{
    internal sealed class AnimationDurationProperty : Property
    {
        private static readonly IValueConverter
            ListConverter = Converters.TimeConverter.FromList().OrDefault(Time.Zero);

        internal AnimationDurationProperty() : base(PropertyNames.AnimationDuration)
        {
        }
    }
}