using System.Collections.Generic;
using ExCSS.New.Values;
using ExCSS.Values;

namespace ExCSS.New.ValueConverters
{
    public class ContentPositionValueConverter : IValueConverter2
    {
        public IValue Convert(IEnumerable<Token> value)
        {
            if (value == null)
                return null;

            var tokens = new List<Token>(value);

            if (tokens.Count == 0)
                return null;

            var completed = false;
            var contentPosition = new ContentPosition
            {
                Overflow = new OverflowPosition()
            };

            foreach (var token in tokens)
            {
                if (token.Type == TokenType.Whitespace)
                    continue;

                //Additional invalid token(s) present
                if (completed)
                    return null;

                if (token.Type == TokenType.Ident
                    && (token.Data == Keywords.Safe || token.Data == Keywords.Unsafe))
                {
                    //Can't specify safe or unsafe more than once
                    if (contentPosition.Overflow.Safe != null || contentPosition.Overflow.Unsafe != null)
                        return null;

                    contentPosition.Overflow.Safe = token.Data == Keywords.Safe ? true : null;
                    contentPosition.Overflow.Unsafe = token.Data == Keywords.Unsafe ? true : null;
                    continue;
                }

                //center | start | end | flex-start | flex-end
                if (token.Type == TokenType.Ident
                    && (token.Data == Keywords.Center
                        || token.Data == Keywords.Start
                        || token.Data == Keywords.End
                        || token.Data == Keywords.FlexStart
                        || token.Data == Keywords.FlexEnd))
                {
                    //Anything else after this is an error
                    completed = true;
                    contentPosition.Value = token.Data;
                }
            }

            if (!completed)
                return null;

            //If we didn't get an overflow position, don't store anything
            if (contentPosition.Overflow.Safe == null && contentPosition.Overflow.Unsafe == null)
                contentPosition.Overflow = null;

            return new ContentPositionValue(tokens, contentPosition);
        }
    }
}
