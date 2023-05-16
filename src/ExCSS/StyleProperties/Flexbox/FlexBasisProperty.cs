﻿using System.Collections.Generic;
using System.Linq;

namespace ExCSS
{
    internal sealed class FlexBasisProperty : Property
    {
        private static readonly IValueConverter StyleConverter = Converters.AutoLengthOrPercentConverter
                                                                           .Or(Converters.IntrinsicSizingConverter)
                                                                           .OrGlobalValue()
                                                                           .OrDefault(Keywords.Auto);

        internal FlexBasisProperty()
            : base(PropertyNames.FlexBasis)
        { }

        internal override IValueConverter Converter => StyleConverter;
    }
}