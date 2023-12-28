using System;
using System.Collections.Generic;
using System.Text;

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

        protected void TestAcceptsEnumKeyword<TEnum>(string value, TEnum expected) where TEnum : unmanaged
        {
            TestAcceptsValue(value, prop =>
            {
                Assert.Equal(ValueKind.EnumKeyword, prop.Value.Kind);

                var keyword = prop.Value.As<EnumKeywordValue<TEnum>>();

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

        protected static string GetUppercasePermutations(string value)
        {
            var output = new StringBuilder();
            var rnd = new Random();

            foreach (var ch in value)
            {
                if (ch.IsLetter())
                    output.Append(rnd.NextDouble() >= 0.5f ? char.ToUpper(ch) : ch);
                else
                    output.Append(ch);
            }

            return output.ToString();
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

        public static IEnumerable<object[]> SelfPositionKeywordValues
        {
            get
            {
                return new[]
                {
                    new object[] { "center", SelfPositionKeyword.Center },
                    new object[] { "start", SelfPositionKeyword.Start },
                    new object[] { "end", SelfPositionKeyword.End },
                    new object[] { "self-start", SelfPositionKeyword.SelfStart },
                    new object[] { "self-end", SelfPositionKeyword.SelfEnd },
                    new object[] { "flex-start", SelfPositionKeyword.FlexStart },
                    new object[] { "flex-end", SelfPositionKeyword.FlexEnd }
                };
            }
        }

        public static IEnumerable<object[]> OverflowSelfPositionKeywordValues
        {
            get
            {
                return new[]
                {
                    new object[] { "safe center", SelfPositionKeyword.Center, true, null },
                    new object[] { "safe start", SelfPositionKeyword.Start, true, null },
                    new object[] { "safe end", SelfPositionKeyword.End, true, null },
                    new object[] { "safe self-start", SelfPositionKeyword.SelfStart, true, null },
                    new object[] { "safe self-end", SelfPositionKeyword.SelfEnd, true, null },
                    new object[] { "safe flex-start", SelfPositionKeyword.FlexStart, true, null },
                    new object[] { "safe flex-end", SelfPositionKeyword.FlexEnd, true, null },
                    new object[] { "unsafe center", SelfPositionKeyword.Center, null, true },
                    new object[] { "unsafe start", SelfPositionKeyword.Start, null, true },
                    new object[] { "unsafe end", SelfPositionKeyword.End, null, true },
                    new object[] { "unsafe self-start", SelfPositionKeyword.SelfStart, null, true },
                    new object[] { "unsafe self-end", SelfPositionKeyword.SelfEnd, null, true },
                    new object[] { "unsafe flex-start", SelfPositionKeyword.FlexStart, null, true },
                    new object[] { "unsafe flex-end", SelfPositionKeyword.FlexEnd, null, true }
                };
            }
        }
    }
}
