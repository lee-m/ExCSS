using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class SelfPositionValueConverter : IValueConverter2
    {
        private readonly Dictionary<string, SelfPositionKeyword> _keywordMapping = new()
        {
            { Keywords.Center, SelfPositionKeyword.Center },
            { Keywords.Start, SelfPositionKeyword.Start },
            { Keywords.End, SelfPositionKeyword.End },
            { Keywords.SelfStart, SelfPositionKeyword.SelfStart },
            { Keywords.SelfEnd, SelfPositionKeyword.SelfEnd },
            { Keywords.FlexStart, SelfPositionKeyword.FlexStart },
            { Keywords.FlexEnd, SelfPositionKeyword.FlexEnd },
        };

        public IValue Convert(TokenValue value)
        {
            if (value == null)
                return null;

            if (value.Count == 0)
                return null;

            var overflow = new OverflowPositionValue();
            var keyword = (SelfPositionKeyword?)null;

            foreach (var token in value)
            {
                if (token.Type == TokenType.Whitespace)
                    continue;

                //Additional invalid token(s) present
                if (keyword != null)
                    return null;

                if (token.Type == TokenType.Ident
                    && (token.Data == Keywords.Safe || token.Data == Keywords.Unsafe))
                {
                    //Can't specify safe or unsafe more than once
                    if (overflow.Safe != null || overflow.Unsafe != null)
                        return null;

                    overflow.Safe = token.Data == Keywords.Safe ? true : null;
                    overflow.Unsafe = token.Data == Keywords.Unsafe ? true : null;
                    continue;
                }

                if (token.Type == TokenType.Ident
                    && _keywordMapping.TryGetValue(token.Data, out var matchedKeyword))
                {
                    //Anything else after this is an error
                    keyword = matchedKeyword;
                }
            }

            if (keyword == null)
                return null;

            //If we didn't get an overflow position, don't store anything
            if (overflow.Safe == null && overflow.Unsafe == null)
                overflow = null;

            return new SelfPositionValue(value, overflow, keyword.Value);
        }
    }
}
