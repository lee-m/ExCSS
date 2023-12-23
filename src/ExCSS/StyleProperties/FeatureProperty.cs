namespace ExCSS
{
    internal sealed class FeatureProperty : Property
    {
        internal FeatureProperty(MediaFeature feature)
            : base(feature.Name)
        {
            Feature = feature;
        }

        internal MediaFeature Feature { get; }
    }
}