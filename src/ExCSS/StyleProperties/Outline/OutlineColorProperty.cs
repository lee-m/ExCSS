using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class OutlineColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.InvertedColorConverter.OrDefault(ColorValue.Transparent);

        internal OutlineColorProperty()
            : base(PropertyNames.OutlineColor, PropertyFlags.Animatable)
        {
        }

        internal override IValueConverter Converter => StyleConverter;
    }
}