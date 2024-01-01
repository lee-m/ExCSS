using System.Collections.Generic;

namespace ExCSS.New.StyleProperties
{
    public sealed class AllProperty : Property
    {
        internal AllProperty()
            : base(PropertyNames.All)
        { }

        internal override IEnumerable<IValueConverter2> GetValueConverters()
            => new[] { Converters.WideKeyword };
    }
}
