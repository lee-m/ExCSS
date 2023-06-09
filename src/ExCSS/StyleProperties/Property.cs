using System.IO;
using ExCSS.New;
using ExCSS.New.Values;

// ReSharper disable UnusedMember.Global

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

        internal virtual IValue CoerceValue(TokenValue newTokenValue)
            => null;

        public string ValueText => DeclaredValue != null ? DeclaredValue.CssText : Keywords.Initial;

        public string Original => DeclaredValue != null ? DeclaredValue.Original.Text : Keywords.Initial;

        public bool IsInherited => (_flags & PropertyFlags.Inherited) == PropertyFlags.Inherited && IsInitial ||
                                   DeclaredValue != null && DeclaredValue.CssText.Is(Keywords.Inherit);

        public bool IsAnimatable => (_flags & PropertyFlags.Animatable) == PropertyFlags.Animatable;

        public bool IsInitial => DeclaredValue == null || DeclaredValue.CssText.Is(Keywords.Initial);

        internal bool HasValue => DeclaredValue != null;

        internal bool CanBeHashless => (_flags & PropertyFlags.Hashless) == PropertyFlags.Hashless;

        internal bool CanBeUnitless => (_flags & PropertyFlags.Unitless) == PropertyFlags.Unitless;

        public bool CanBeInherited => (_flags & PropertyFlags.Inherited) == PropertyFlags.Inherited;

        internal bool IsShorthand => (_flags & PropertyFlags.Shorthand) == PropertyFlags.Shorthand;

        public string Name { get; }

        public bool IsImportant { get; set; }
        public IValue Value { get; protected set; }

        public string CssText => this.ToCss();

        internal abstract IValueConverter Converter { get; }

        internal IPropertyValue DeclaredValue { get; set; }
    }
}