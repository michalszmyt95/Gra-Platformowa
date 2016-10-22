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

namespace GraPlatformowa
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.
        }

        protected override void Initialize() // Inicjalizacja zewn�trznych zasob�w gry (takich jak muzyka)
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        protected override void LoadContent() // Pobieranie zewn�trznych zasob�w do projektu.
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        protected override void Update(GameTime gameTime) // Metoda wywo�uje si� 60 razy na sekund� - p�tla gry.
        {

            base.Update(gameTime);
        }

        /// Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(),
        /// S�u�y do od�wie�ania wy�wietlanych element�w
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Chocolate);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
