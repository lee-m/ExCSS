using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class BorderLeftColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(ColorValue.Transparent);

        internal BorderLeftColorProperty()
            : base(PropertyNames.BorderLeftColor)
        {
        }
    }
}