using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

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

    public Rectangle Calculate(Rectangle container)
    {
        return new(
            X.Calculate(container.Width) + container.X, 
            Y.Calculate(container.Height) + container.Y,
            Width.Calculate(container.Width), 
            Height.Calculate(container.Height));
    }
}

public struct Dimensions
{
    public static readonly Dimensions
        Empty = new(0, 0),
        Fill = new(0, 1);

    public int pixels;
    public float percentage;

    public Dimensions(int pixels, float percentage)
    {
        this.pixels = pixels;
        this.percentage = percentage;
    }

    public int Calculate(float parentSize) => pixels + (int) (percentage * parentSize);
}