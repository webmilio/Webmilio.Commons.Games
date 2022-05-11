using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Webmilio.Commons.Games.Assets;

public class Textures
{
    public Textures(GraphicsDevice device)
    {
        Pixel = new(device, 1, 1);
        Pixel.SetData(new Color[] { Color.White });
    }

    public static Texture2D Pixel { get; private set; }
}