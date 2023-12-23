using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class BorderTopColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(ColorValue.Transparent);

        internal BorderTopColorProperty()
            : base(PropertyNames.BorderTopColor)
        {
        }
    }
}