using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class ContentDistributionValue : BaseValue
    {        
        internal ContentDistributionValue(IEnumerable<Token> parsedValue, ContentDistributionKeyword keyword) 
            : base(parsedValue)
        {
            Keyword = keyword;
        }

        public ContentDistributionKeyword Keyword { get; }

        public override ValueKind Kind => ValueKind.ContentDistribution;
    }
}
