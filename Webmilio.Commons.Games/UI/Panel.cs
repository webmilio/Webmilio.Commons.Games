using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Webmilio.Commons.Games.Assets;
using Webmilio.Commons.Games.Extensions;

namespace Webmilio.Commons.Games.UI;

public class Panel : Element
{
    public Color 
        BackgroundColor = Color.Black, 
        BorderColor = Color.White;

    protected override void DrawSelf(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawRectangle(Textures.Pixel, );

        base.DrawSelf(spriteBatch);
    }
}