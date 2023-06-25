using System.Collections.Generic;
using System.Linq;
using ExCSS.New.Values;

namespace ExCSS
{
    public sealed class LinearGradient : IGradient
    {
        public LinearGradient(AngleValue angle, GradientStop[] stops, bool repeating = false)
        {
            _stops = stops;
            Angle = angle;
            IsRepeating = repeating;
        }

        private readonly GradientStop[] _stops;

        public AngleValue Angle { get; }
        public IEnumerable<GradientStop> Stops => _stops.AsEnumerable();
        public bool IsRepeating { get; }
    }
}