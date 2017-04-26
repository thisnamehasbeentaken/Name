  using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Week3
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class SpaceInvaders : Game
    {
        static Scene currentScene;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        static GameScene gameScene;
        static TitleScene titleScene;
        static bool gameLost = false;
        
        public SpaceInvaders()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            gameScene = new GameScene(Content);
            titleScene = new TitleScene(Content);

            currentScene = titleScene;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Content.Load<Texture2D>("player");
            Content.Load<Texture2D>("enemy");
            Content.Load<SpriteFont>("spriteFont");

            gameScene.LoadContent(Window);
            titleScene.LoadContent(Window);
        }

        internal static void StartGame()
        {
            currentScene = gameScene;
        }

        internal static void LoseGame()
        {
            gameLost = true;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if(gameLost)
            {
                Exit();
            }

            currentScene.Update(gameTime);
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            currentScene.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
