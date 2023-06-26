using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class ContentDistributionValue : EnumKeywordValue<ContentDistributionKeyword>
    {        
        internal ContentDistributionValue(IEnumerable<Token> parsedValue, ContentDistributionKeyword keyword) 
            : base(parsedValue, ValueKind.ContentDistribution, keyword)
        { }
    }
}
