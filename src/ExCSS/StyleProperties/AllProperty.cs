using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS
{
    internal sealed class AllProperty : Property
    {
        internal AllProperty()
            : base(PropertyNames.All)
        { }

        internal override IValueConverter Converter => null;

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var converter = new WideKeywordValueConverter();
            return converter.Convert(newTokenValue);
        }
    }
}
