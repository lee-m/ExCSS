using System.Collections.Generic;

using ExCSS.New.Enumerations;
using ExCSS.New.Values;

namespace ExCSS.New.ValueConverters
{
    public class ContentPositionValueConverter : IValueConverter2
    {
        private readonly Dictionary<string, ContentPositionKeyword> _keywordMapping;

        public ContentPositionValueConverter()
        {
            _keywordMapping = new Dictionary<string, ContentPositionKeyword>
            {
                { Keywords.Center, ContentPositionKeyword.Center },
                { Keywords.Start, ContentPositionKeyword.Start },
                { Keywords.End, ContentPositionKeyword.End },
                { Keywords.FlexStart, ContentPositionKeyword.FlexStart },
                { Keywords.FlexEnd, ContentPositionKeyword.FlexEnd }
            };
        }

        public IValue Convert(TokenValue value)
        {
            if (value == null)
                return null;

            if (value.Count == 0)
                return null;

            var overflow = new OverflowPositionValue();
            var keyword = (ContentPositionKeyword?)null;

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
                    && (token.Data == Keywords.Center
                        || token.Data == Keywords.Start
                        || token.Data == Keywords.End
                        || token.Data == Keywords.FlexStart
                        || token.Data == Keywords.FlexEnd))
                {
                    //Anything else after this is an error
                    keyword = _keywordMapping[token.Data];
                }
            }

            if (keyword == null)
                return null;

            //If we didn't get an overflow position, don't store anything
            if (overflow.Safe == null && overflow.Unsafe == null)
                overflow = null;

            return new ContentPositionValue(value, overflow, keyword.Value);
        }
    }
}
