using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using ExCSS.New;
using ExCSS.New.Values;

namespace ExCSS
{
    public abstract class Property : StylesheetNode, IProperty
    {
        private readonly PropertyFlags _flags;

        internal Property(string name, PropertyFlags flags = PropertyFlags.None)
        {
            Name = name;
            _flags = flags;
        }

        public override void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            writer.Write(formatter.Declaration(Name, ValueText, IsImportant));
        }

        internal bool TrySetValue(TokenValue newTokenValue)
        {
            Value = CoerceValue(newTokenValue);
            return Value != null;
        }

        private IValue CoerceValue(TokenValue newTokenValue)
        {
            var converters = new List<IValueConverter2> { New.Converters.WideKeyword };
            converters.AddRange(GetValueConverters() ?? Enumerable.Empty<IValueConverter2>());

            foreach(var converter in converters)
            {
                var value = converter.Convert(newTokenValue);

                if (value != null)
                    return value;
            }

            return null;
        }
        
        internal virtual IEnumerable<IValueConverter2> GetValueConverters()
            => null;

        public string ValueText => Value?.ToString();

        public string Original => Value?.Original;

        public bool IsInherited => (_flags & PropertyFlags.Inherited) == PropertyFlags.Inherited && IsInitial ||
                                   DeclaredValue != null && DeclaredValue.CssText.Is(Keywords.Inherit);

        public bool IsAnimatable => (_flags & PropertyFlags.Animatable) == PropertyFlags.Animatable;

        public bool IsInitial
            => Value.As<KeywordValue>()?.Keyword == Keywords.Initial;

        internal bool HasValue => Value != null;

        internal bool CanBeHashless => (_flags & PropertyFlags.Hashless) == PropertyFlags.Hashless;

        internal bool CanBeUnitless => (_flags & PropertyFlags.Unitless) == PropertyFlags.Unitless;

        public bool CanBeInherited => (_flags & PropertyFlags.Inherited) == PropertyFlags.Inherited;

        internal bool IsShorthand => (_flags & PropertyFlags.Shorthand) == PropertyFlags.Shorthand;

        public string Name { get; }

        public bool IsImportant { get; set; }
        public IValue Value { get; protected set; }

        public string CssText => this.ToCss();

        internal IPropertyValue DeclaredValue { get; set; }
    }
}