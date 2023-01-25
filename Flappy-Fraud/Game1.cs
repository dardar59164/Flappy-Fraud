using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Flappy_Fraud
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        public Bird Player = new Bird();
        private Vector2 _position;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Player.position = new Vector2((GraphicsDevice.Viewport.Width / 2) - 100, GraphicsDevice.Viewport.Height / 2);
            Player.currentFrame = 0;


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Player.texture = Content.Load<Texture2D>("Flappy-Bird-Spritesheet");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Player.animationFrame = Player.currentFrame;

            if (Player.currentFrame >= Player.spriteAnimation.Length - 1)
                Player.currentFrame = 0;
            else
                Player.currentFrame++;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            _spriteBatch.Draw(Player.texture, Player.position,Player.spriteAnimation[Player.animationFrame],Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}