using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Parts_1_5___Animation
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Texture2D dvdLogoTexture;
        Rectangle dvdLogoRect;
        Vector2 dvdLogoSpeed;
        MouseState mouseState;

        SpriteFont continueFont;

        enum Screen
        {
            Intro,
            MainAnimation,
            Outro
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            screen = Screen.Intro;
            // TODO: Add your initialization logic here

            _graphics.PreferredBackBufferWidth = 1280;
            _graphics.PreferredBackBufferHeight = 720;
            _graphics.ApplyChanges();
            dvdLogoSpeed = new Vector2(15, 15);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            dvdLogoTexture = Content.Load<Texture2D>("DVDLogo");
            dvdLogoRect = new Rectangle(340, 60, 600, 600);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.MainAnimation;
            }
            else if (screen == Screen.MainAnimation)
            {
                dvdLogoRect.X += (int)dvdLogoSpeed.X;
                dvdLogoRect.Y += (int)dvdLogoSpeed.Y;

                if (dvdLogoRect.Right > _graphics.PreferredBackBufferWidth || dvdLogoRect.X < 0)
                {
                    dvdLogoSpeed.X *= -1;

                }
                if (dvdLogoRect.Top < 0 || dvdLogoRect.Bottom > _graphics.PreferredBackBufferHeight)
                {
                    dvdLogoSpeed.Y *= -1;
                }
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _spriteBatch.Draw(dvdLogoTexture, dvdLogoRect, Color.White);


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
