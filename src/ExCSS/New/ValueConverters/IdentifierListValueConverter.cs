using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class IdentifierListValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            var tokenList = value.ToList();
            var identifiers = new List<IdentifierValue>();
            var identifierConverter = new IdentifierValueConverter();

            foreach(var token in tokenList)
            {
                var identifier = identifierConverter.Convert(new TokenValue(token));

                if (identifier == null)
                    return null;

                identifiers.Add((IdentifierValue)identifier);
            }

            return new IdentifierListValue(value, identifiers);
        }
    }
}
