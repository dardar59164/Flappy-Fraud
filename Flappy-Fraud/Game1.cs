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
        public Bird Player;
        Texture2D backgroundTexture;
        private Vector2 _center;
        private Vector2 _position;
        private float _moveSpeed;
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
            _position = new Vector2(_center.X - 50, _center.Y);
            _moveSpeed = 10f;
            Player = new Bird(_position);
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            currentTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
            Player.animationFrame = Player.currentFrame;
            Player.position = _position;

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

            KeyboardState state = Keyboard.GetState();
            MouseState mState = Mouse.GetState();
            //Player Position Update

            if (state.IsKeyDown(Keys.Up) || mState.LeftButton == ButtonState.Pressed)
            {
                _position.Y -= _moveSpeed;
            }

            if (_position.Y + Player.texture.Height <= GraphicsDevice.Viewport.Height)
            {
                _position.Y += 5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture,new Vector2(0,0),Color.White);
            _spriteBatch.Draw(Player.texture, _position,Player.spriteAnimation[Player.animationFrame],Color.White);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}