using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // variables for three sprites
        Texture2D sprite0;
        Texture2D sprite1;
        Texture2D sprite2;

        // variables for x and y speeds
        int xSpeed;
        int ySpeed;

        // used to handle generating random values
        Random rand = new Random();
        const int CHANGE_DELAY_TIME = 1000;
        int elapsedTime = 0;

        // used to keep track of current sprite and location
        Texture2D currentSprite;
        Rectangle drawRectangle = new Rectangle();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT; ;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // load the sprite images here
            sprite0 = Content.Load<Texture2D>("sprite0");
            sprite1 = Content.Load<Texture2D>("sprite1");
            sprite2 = Content.Load<Texture2D>("sprite2");

            // set the currentSprite variable to one of your sprite variables
            currentSprite = sprite0;

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime > CHANGE_DELAY_TIME)
            {
                elapsedTime = 0;

                // generate a random number between 0 and 2 inclusive
                int spriteNumber = rand.Next(3);

                 //sets current sprite
                if (spriteNumber == 0)
                {
                    currentSprite = sprite0;
                }
                else if (spriteNumber == 1)
                {
                    currentSprite = sprite1;
                }
                else if (spriteNumber == 2)
                {
                    currentSprite = sprite2;
                }

                // set the drawRectangle.Width and drawRectangle.Height to match the width 
                // and height of currentSprite
                drawRectangle.Width = currentSprite.Width;
                drawRectangle.Height = currentSprite.Height;

                // center the draw rectangle in the window.
                drawRectangle.X = WINDOW_WIDTH / 2 - drawRectangle.Width / 2;
                drawRectangle.Y = WINDOW_HEIGHT / 2 - drawRectangle.Height / 2;

                // generate random numbers  between -4 and 4 inclusive for the x and y speed 
                xSpeed = rand.Next(-4, 5);
                ySpeed = rand.Next(-4, 5);

            }

            // move the drawRectangle by the x speed and the y speed
            drawRectangle.X += xSpeed;
            drawRectangle.Y += ySpeed;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw current sprite
            spriteBatch.Begin();
            spriteBatch.Draw(currentSprite, drawRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
