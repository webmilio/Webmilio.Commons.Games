using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Webmilio.Commons.Games;

public class Game : Microsoft.Xna.Framework.Game
{
    public GameTime updateGameTime, drawGameTime;

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        updateGameTime = gameTime;
    }

    protected override void Draw(GameTime gameTime)
    {
        base.Draw(gameTime);
        var screenSize = GraphicsDevice.Viewport.Bounds.Size.ToVector2();

        if (ScreenSize != screenSize)
        {
            ScreenSize = screenSize;
            OnResize();
        }

        drawGameTime = gameTime;
    }

    public void OnResize()
    {
        Resize?.Invoke(ScreenSize);
    }

    public static Vector2 ScreenSize { get; private set; }

    public event Action<Vector2> Resize;
}