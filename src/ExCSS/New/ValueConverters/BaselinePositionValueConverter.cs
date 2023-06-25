using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class BaselinePositionValueConverter : IValueConverter2
    {
        public IValue Convert(TokenValue value)
        {
            if (value == null)
                return null;

            if (value.Count == 0)
                return null;

            bool? first = null;
            bool? last = null;
            var completed = false;

            foreach(var token in value)
            {
                if (token.Type == TokenType.Whitespace)
                    continue;

                //Additional invalid token(s) present
                if (completed)
                    return null;

                if(token.Type == TokenType.Ident 
                   && (token.Data == Keywords.First || token.Data == Keywords.Last))
                {
                    //Can't specify first or last more than once
                    if (first != null|| last != null)
                        return null;

                    first = token.Data == Keywords.First ? true : null;
                    last = token.Data == Keywords.Last ? true : null;
                    continue;
                }

                if (token.Type == TokenType.Ident
                    && token.Data == Keywords.Baseline)
                {
                    //Anything else after this is an error
                    completed = true;
                }
            }

            if (!completed)
                return null;

            return new BaselinePositionValue(value, first, last);
        }
    }
}
