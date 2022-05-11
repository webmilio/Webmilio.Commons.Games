using System.Diagnostics.CodeAnalysis;

namespace Webmilio.Commons.Games;

public struct Bounds
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public Dimensions X, Y, Width, Height;

    public Bounds(Dimensions x, Dimensions y, Dimensions width, Dimensions height)
    {
        X = x;
        Y = y;

        Width = width;
        Height = height;
    }

    public (float x, float y, float width, float height) Calculate(float containerWidth, float containerHeight)
    {
        return new(
            X.Calculate(containerWidth), Y.Calculate(containerHeight),
            Width.Calculate(containerWidth), Y.Calculate(containerHeight));
    }
}

public struct Dimensions
{
    public static readonly Dimensions
        Empty = new(0, 0),
        Fill = new(0, 1);

    public float pixels, percentage;

    public Dimensions(float pixels, float percentage)
    {
        this.pixels = pixels;
        this.percentage = percentage;
    }

    public float Calculate(float parentSize) => pixels + percentage * parentSize;
}