using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Webmilio.Commons.Extensions;
using Webmilio.Commons.Games.Assets;
using Webmilio.Commons.Games.Showcase.UI;
using Webmilio.Commons.Games.UI;

namespace Webmilio.Commons.Games.Showcase;

public class ShowcaseGame : Games.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    public List<Layer> layers = new();
    public List<ILayer> activeLayers = new();

    public ShowcaseGame()
    {
        Instance = this;

        _graphics = new(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        layers.Add(new Layer(new Dialog())
        {
            Visible = true
        });

        base.Initialize();
    }

    protected override void LoadContent()
    {
        Textures = new(GraphicsDevice);
        _spriteBatch = new(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        activeLayers.Do(l => l.Update(gameTime));
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        activeLayers.Clear();
        layers.Do(l => l.ModifyLayers(activeLayers));

        GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin();
        activeLayers.Do(e => e.Draw(_spriteBatch));
        _spriteBatch.End();

        base.Draw(gameTime);
    }

    public Textures Textures { get; private set; }

    public static ShowcaseGame Instance { get; private set; }
}