using System.Collections.Generic;
using System.IO;
using ExCSS.New.Values;

namespace ExCSS
{
    public sealed class KeyframeSelector : StylesheetNode
    {
        private readonly List<PercentValue> _stops;

        public KeyframeSelector(IEnumerable<PercentValue> stops)
        {
            _stops = new List<PercentValue>(stops);
        }

        public override void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            if (_stops.Count <= 0) return;

            writer.Write(_stops[0].ToString());
            for (var i = 1; i < _stops.Count; i++)
            {
                writer.Write(", ");
                writer.Write(_stops[i].ToString());
            }
        }

        public IEnumerable<PercentValue> Stops => _stops;
        public string Text => this.ToCss();
    }

    public sealed class PageSelector : StylesheetNode, ISelector
    {
        private readonly string _name;

        public PageSelector(string name)
        {
            _name = name;
        }

        public PageSelector() : this(string.Empty)
        {
        }

        public override void ToCss(TextWriter writer, IStyleFormatter formatter)
        {
            var pseudo = _name == string.Empty ? "" : ":";
            writer.Write($"{pseudo}{_name}");
        }

        public Priority Specificity => Priority.Inline;
        public string Text => this.ToCss();
    }
}