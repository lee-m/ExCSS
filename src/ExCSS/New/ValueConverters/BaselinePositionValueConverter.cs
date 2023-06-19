using System.Collections.Generic;
using System.Linq;

using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class BaselinePositionValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            if (value == null)
                return null;

            var tokens = new List<Token>(value);

            if (tokens.Count == 0)
                return null;

            var baselinePosition = new BaselinePosition();
            var completed = false;

            foreach(var token in tokens)
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
                    if (baselinePosition.First != null|| baselinePosition.Last != null)
                        return null;

                    baselinePosition.First = token.Data == Keywords.First ? true : null;
                    baselinePosition.Last = token.Data == Keywords.Last ? true : null;
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

            return new BaselinePositionValue(tokens, baselinePosition);
        }
    }
}
