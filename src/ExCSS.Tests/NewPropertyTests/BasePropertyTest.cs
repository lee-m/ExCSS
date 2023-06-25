using System;
using System.Collections.Generic;

using ExCSS.New;
using ExCSS.New.Enumerations;
using ExCSS.New.Values;

using Xunit;

namespace ExCSS.Tests.NewPropertyTests
{
    public class BasePropertyTest<TProp> where TProp : Property
    {
        private readonly string _propertyName;

        protected BasePropertyTest(string propertyName)
        {
            _propertyName = propertyName;
        }

        protected Property ParseDeclaration(string source,
                                                  bool includeUnknownRules = false,
                                                  bool includeUnknownDeclarations = false,
                                                  bool tolerateInvalidSelectors = false,
                                                  bool tolerateInvalidValues = false,
                                                  bool tolerateInvalidConstraints = false,
                                                  bool preserveComments = false)
        {
            var parser = new StylesheetParser(includeUnknownRules,
                                              includeUnknownDeclarations,
                                              tolerateInvalidSelectors,
                                              tolerateInvalidValues,
                                              tolerateInvalidConstraints,
                                              preserveComments);
            return parser.ParseDeclaration(source);
        }

        protected void TestAcceptsKeyword(string value)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.Keyword, prop.Value.Kind);

                var keyword = prop.Value.As<KeywordValue>();

                Assert.NotNull(keyword);
                Assert.Equal(value, keyword.Keyword);
                Assert.Equal(value, keyword.Original);
            });
        }

        protected void TestAcceptsWideKeyword(string value, WideKeyword expected)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.WideKeyword, prop.Value.Kind);

                var keyword = prop.Value.As<WideKeywordValue>();

                Assert.NotNull(keyword);
                Assert.Equal(expected, keyword.Keyword);
                Assert.Equal(value, keyword.Original);
            });
        }

        protected void TestAcceptsColor(string value, ColorValue expected)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.Color, prop.Value.Kind);

                var color = prop.Value.As<ColorValue>();
                Assert.True(expected.Equals(color));
                Assert.Equal(value, color.Original);
            });
        }

        protected void TestAcceptsValue(string value, Action<TProp> verify)
        {
            var property = ParseDeclaration($"{_propertyName}: {value}");

            Assert.Equal(_propertyName, property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<TProp>(property);
            Assert.False(property.IsInherited);

            verify((TProp)property);
        }

        protected void TestInvalidValue(string value)
        {
            var property = ParseDeclaration($"{_propertyName}: {value}");

            Assert.Equal(_propertyName, property.Name);
            Assert.False(property.IsImportant);
            Assert.IsType<TProp>(property);

            var concrete = (TProp)property;

            Assert.False(concrete.IsInherited);
            Assert.Null(concrete.Value);
        }

        public static IEnumerable<object[]> WideKeywordTestValues
        {
            get
            {
                return new[]
                {
                    new object[] { Keywords.Inherit, WideKeyword.Inherit },
                    new object[] { Keywords.Initial, WideKeyword.Initial },
                    new object[] { Keywords.Revert, WideKeyword.Revert },
                    new object[] { Keywords.RevertLayer, WideKeyword.RevertLayer },
                    new object[] { Keywords.Unset, WideKeyword.Unset }
                };
            }
        }
    }
}
