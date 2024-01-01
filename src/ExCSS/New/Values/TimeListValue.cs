using System.Collections.Generic;

namespace ExCSS.New.Values
{
    public sealed class TimeListValue : ListValue<TimeValue>
    {
        internal TimeListValue(IEnumerable<Token> parsedValue, IList<TimeValue> values)
            : base(parsedValue, values)
        { }
    }
}
