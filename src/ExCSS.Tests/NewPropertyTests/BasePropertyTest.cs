using System;
using System.Collections.Generic;
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

        protected void TestAcceptsEnumKeyword<TEnum, TValue>(string value, ValueKind expectedValueKind, TEnum expected) where TEnum: unmanaged where TValue: EnumKeywordValue<TEnum>
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(expectedValueKind, prop.Value.Kind);

                var keyword = prop.Value.As<TValue>();

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

        protected void TestAcceptsBaselineValue(string value, bool? first, bool? last)
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(prop.Value.Kind, ValueKind.BaselinePosition);

                var baselinePosition = prop.Value.As<BaselinePositionValue>();

                Assert.Equal(first, baselinePosition.First);
                Assert.Equal(last, baselinePosition.Last);
            });
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

        public static IEnumerable<object[]> ValidBaselinePropertyValues
        {
            get
            {
                return new[]
                {
                    new object[] { "first baseline", true, null },
                    new object[] { "last baseline", null, true },
                    new object[] { "baseline", null, null }
                };
            }
        }

        public static IEnumerable<object[]> InvalidBaselinePropertyValues
        {
            get
            {
                return new[]
                {
                    new object[] { "" },
                    new object[] { "first first baseline" },
                    new object[] { "last last baseline" },
                    new object[] { "baseline baseline" },
                    new object[] { "first baseline last" },
                    new object[] { "last baseline first" }
                };
            }
        }
    }
}
