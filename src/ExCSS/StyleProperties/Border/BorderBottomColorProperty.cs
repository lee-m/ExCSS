using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class BorderBottomColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter =
            Converters.CurrentColorConverter.OrDefault(ColorValue.Transparent);

        internal BorderBottomColorProperty()
            : base(PropertyNames.BorderBottomColor)
        {
        }
    }
}