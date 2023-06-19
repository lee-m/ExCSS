﻿using ExCSS.New.StyleProperties;
using Xunit;

namespace ExCSS.Tests.NewPropertyTests
{
    public class AllPropertyTests : BasePropertyTest<AllProperty>
    {
        public AllPropertyTests() : base(PropertyNames.All)
        { }

        [Theory]
        [MemberData(nameof(WideKeywordTestValues))]
        public void AllPropertyAcceptsWideKeywords(string value)
            => TestAcceptsKeyword(value);

        [Theory]
        [InlineData("")]
        [InlineData("random value")]
        public void AllPropertyInvalidValue(string value)
            => TestInvalidValue(value);
    }
}
