using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class ColumnRuleColorProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.ColorConverter.OrDefault(ColorValue.Transparent);

        internal ColumnRuleColorProperty()
            : base(PropertyNames.ColumnRuleColor, PropertyFlags.Animatable)
        {
        }

        internal override IValueConverter Converter => StyleConverter;
    }
}