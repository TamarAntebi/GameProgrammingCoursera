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

namespace ProgrammingAssignment3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        const int WINDOW_WIDTH = 800;
        const int WINDOW_HEIGHT = 600;

        Random rand = new Random();
        Vector2 centerLocation = new Vector2(
            WINDOW_WIDTH / 2, WINDOW_HEIGHT / 2);

        //variables for 3 rock sprites
        Texture2D sprite0;
        Texture2D sprite1;
        Texture2D sprite2;

        //variables for 3 rocks
        Rock rock0 = null;
        Rock rock1 = null;
        Rock rock2 = null;

        // delay support
        const int TOTAL_DELAY_MILLISECONDS = 1000;
        int elapsedDelayMilliseconds = 0;

        // random velocity support
        const float BASE_SPEED = 0.15f;
        Vector2 upLeft = new Vector2(-BASE_SPEED, -BASE_SPEED);
        Vector2 upRight = new Vector2(BASE_SPEED, -BASE_SPEED);
        Vector2 downRight = new Vector2(BASE_SPEED, BASE_SPEED);
        Vector2 downLeft = new Vector2(-BASE_SPEED, BASE_SPEED);

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // change resolution
            graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
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

            // Load content for 3 sprites
            sprite0 = Content.Load<Texture2D>("greenrock");
            sprite1 = Content.Load<Texture2D>("magentarock");
            sprite2 = Content.Load<Texture2D>("whiterock");

            // Create a new random rock by calling the GetRandomRock method
            rock0 = GetRandomRock();

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

            // Update rocks
            if (rock0 != null)
            {
                rock0.Update(gameTime);
            }
            if (rock1 != null)
            {
                rock1.Update(gameTime);
            }
            if (rock2 != null)
            {
                rock2.Update(gameTime);
            } 

            // update timer
            elapsedDelayMilliseconds += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedDelayMilliseconds >= TOTAL_DELAY_MILLISECONDS)
            {
                // timer expired, so spawn new rock if fewer than 3 rocks in window
                if (rock0 == null)
                {
                    rock0 = GetRandomRock();    
                }
                else if (rock1 == null)
                {
                    rock1 = GetRandomRock();  
                }
                else if (rock2 == null)
                {
                    rock2 = GetRandomRock();
                }
                // restart timer
                elapsedDelayMilliseconds = 0;
            }

            // Check each rock to see if it's outside the window. If so
            // spawn a new random rock for it by calling the GetRandomRock method
            if (rock0 != null && rock0.OutsideWindow)
            {
                rock0 = GetRandomRock();
            }
            if (rock1 != null && rock1.OutsideWindow)
            {
                rock1 = GetRandomRock();
            }
            if (rock2 != null && rock2.OutsideWindow)
            {
                rock2 = GetRandomRock();
            } 

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // draw rocks
            spriteBatch.Begin();
            if (rock0 != null)
            {
                // Draw rock0
                rock0.Draw(spriteBatch);
            }
            if (rock1 != null)
            {
                // Draw rock1
                rock1.Draw(spriteBatch);
            }
            if (rock2 != null)
            {
                // Draw rock2
                rock2.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Gets a rock with a random sprite and velocity
        /// </summary>
        /// <returns>the rock</returns>
        private Rock GetRandomRock()
        {
            // Randomly pick a rock sprite by calling the GetRandomSprite method
            Texture2D sprite = GetRandomSprite();

            // Randomly pick a velocity by calling the GetRandomVelocity method
            Vector2 velocity = GetRandomVelocity();

            // return a new rock, centered in the window, with the random sprite and velocity
            return new Rock(sprite, centerLocation, velocity, WINDOW_WIDTH, WINDOW_HEIGHT);
        }

        /// <summary>
        /// Gets a random sprite
        /// </summary>
        /// <returns>the sprite</returns>
        private Texture2D GetRandomSprite()
        {
            // return a random sprite
            // generate a random number between 0 and 2 inclusive
            int spriteNumber = rand.Next(3);
            if (spriteNumber == 0)
            {
                return sprite0;
            }
            else if (spriteNumber == 1)
            {
                return sprite1;
            }
            else
            {
                return sprite2;
            }
        }

        /// <summary>
        /// Gets a random velocity
        /// </summary>
        /// <returns>the velocity</returns>
        private Vector2 GetRandomVelocity()
        {
            // return a random velocity
            // generate a random number between 0 and 3 inclusive
            int velocityNumber = rand.Next(4);
            if (velocityNumber == 0)
            {
                return upLeft;
            }
            else if (velocityNumber == 1)
            {
                return upRight;
            }
            else if (velocityNumber == 2)
            {
                return downRight;
            }
            else
            {
                return downLeft;
            }
        }
    }
}
