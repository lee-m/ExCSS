﻿namespace ExCSS
{
    internal sealed class FillProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.PaintConverter;

        internal FillProperty()
            : base(PropertyNames.Fill, PropertyFlags.Animatable)
        {
        }
    }
}