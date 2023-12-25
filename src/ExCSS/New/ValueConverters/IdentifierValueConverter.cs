using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class IdentifierValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var element = value.OnlyOrDefault();

            if (element != null && element.Type == TokenType.Ident)
                return new IdentifierValue(value);

            return null;
        }
    }
}
