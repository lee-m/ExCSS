using System.Collections.Generic;

using ExCSS.New.Values;

namespace ExCSS.New
{
    internal interface IValueConverter2
    {
        IValue Convert(IEnumerable<Token> value);
    }
}
