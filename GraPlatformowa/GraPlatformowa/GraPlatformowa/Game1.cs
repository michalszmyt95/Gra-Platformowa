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
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.
        }

        protected override void Initialize() // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        protected override void LoadContent() // Pobieranie zewnêtrznych zasobów do projektu.
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
        protected override void Update(GameTime gameTime) // Metoda wywo³uje siê 60 razy na sekundê - pêtla gry.
        {

            base.Update(gameTime);
        }

        /// Metoda wywo³ywana tak czêsto jak to mo¿liwe, po metodzie Update(),
        /// S³u¿y do odœwie¿ania wyœwietlanych elementów
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Chocolate);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
