using ExCSS.New.ValueConverters;
using ExCSS.New.Values;

namespace ExCSS.New.StyleProperties
{
    public sealed class AllProperty : Property
    {
        internal AllProperty()
            : base(PropertyNames.All)
        { }

        protected override IValue CoerceValue(TokenValue newTokenValue)
        {
            var converter = new WideKeywordValueConverter();
            return converter.Convert(newTokenValue);
        }
    }
}
