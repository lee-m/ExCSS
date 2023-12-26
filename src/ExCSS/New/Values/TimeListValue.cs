using System.Collections.Generic;

using ExCSS.New.Enumerations;

namespace ExCSS.New.Values
{
    public sealed class TimeListValue : ListValue<TimeValue>
    {
        internal TimeListValue(IEnumerable<Token> parsedValue,
                               IList<TimeValue> values)
            : base(parsedValue, ValueKind.List, values)
        { }
    }
}
