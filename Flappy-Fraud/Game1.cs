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
        Texture2D backgroundTexture;
        private Vector2 _center;
        private float animationSpeed = 1 / 5f;
        private float currentTime = 0;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            //Resize Screen
            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = 288;
            _graphics.PreferredBackBufferHeight = 512;
            _graphics.ApplyChanges();

            //Get the center of the screen
            _center = new Vector2((GraphicsDevice.Viewport.Width / 2), GraphicsDevice.Viewport.Height / 2);

            //Initialize Player Animation Frame
            Player.currentFrame = 0;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            Player.texture = Content.Load<Texture2D>("Flappy-Bird-Spritesheet");
            backgroundTexture = Content.Load<Texture2D>("background-day");
        }

        protected override void Update(GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Player.animationFrame = Player.currentFrame;

            //Player Animation Update
            if (currentTime >= animationSpeed)
            {
                if (Player.currentFrame >= Player.spriteAnimation.Length - 1)
                {
                    Player.currentFrame = 0;
                    currentTime = 0;
                }
                else
                {
                    Player.currentFrame++;
                    currentTime = 0;
                }
            }

            //Player Position Update
            if (state.IsKeyDown(Keys.Left))
                Player.position = new Vector2(Player.position.X - Player.speed, Player.position.Y);
            if (state.IsKeyDown(Keys.Right))
                Player.position = new Vector2(Player.position.X + Player.speed, Player.position.Y);

            if (state.IsKeyDown(Keys.Up))
                Player.position = new Vector2(Player.position.X, Player.position.Y - Player.speed);

            if (state.IsKeyDown(Keys.Down))
                Player.position = new Vector2(Player.position.X, Player.position.Y + Player.speed);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture,new Vector2(0,0),Color.White);
            _spriteBatch.Draw(Player.texture, Player.position,Player.spriteAnimation[Player.animationFrame],Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}