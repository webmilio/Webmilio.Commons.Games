using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Webmilio.Commons.Games.UI;

public class Layer : IUpdateable, IDrawable
{
    public Layer([NotNull] Element root)
    {
        Root = root;
    }

    public virtual void ModifyLayers(List<ILayer> layers) { }

    public void Update(GameTime gameTime)
    {
        if (!Visible && !UpdateIfInvisible)
            return;

        Root.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        if (Visible)
            Root.Draw(spriteBatch);
    }

    public Element Root { get; }

    public bool Visible { get; set; } = false;
    public bool UpdateIfInvisible { get; set; } = false;
}