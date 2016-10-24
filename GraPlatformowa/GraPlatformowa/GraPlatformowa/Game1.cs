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

        Texture2D testBlock, playerTexture;
        //Song bgMusic;

        Player player;
        Block block1;
        Block block2;
        Block block3;
        Block block4;
        Block block5;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.
        }

        // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();

            player = new Player(new Vector2(10,10), playerTexture);
            block1 = new Block(new Vector2(0, 200), testBlock);
            block2 = new Block(new Vector2(200, 400), testBlock);
            block3 = new Block(new Vector2(300, 600), testBlock);
            block4 = new Block(new Vector2(500, 200), testBlock);
            block5 = new Block(new Vector2(800, 400), testBlock);
        }


        // Pobieranie zewnêtrznych zasobów do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc¹ konstrukora new SpriteBatch(), który u¿ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //£adowanie zasobów:
            testBlock = Content.Load<Texture2D>("blue2");
            playerTexture = Content.Load<Texture2D>("pl1");
            //bgMusic = Content.Load<Song>("bgMusic1");
            // Odtwarzanie muzyki przy starcie aplikacji
            //MediaPlayer.Play(bgMusic);
            // Zapêtlanie muzyki
            MediaPlayer.IsRepeating = true;

        }

        protected override void UnloadContent(){}


        // Metoda wywo³uje siê 60 razy na sekundê - pêtla gry(input, kolizje, dŸwiêk):
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            // animacja bazuj¹ca na czasie
            base.Update(gameTime);
        }

        /// Metoda wywo³ywana tak czêsto jak to mo¿liwe, po metodzie Update(),
        /// S³u¿y do odœwie¿ania wyœwietlanych elementów
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightCyan); //Pierwsze wyœwietla siê t³o.

            // Rozpoczynanie rysowania:
            spriteBatch.Begin();
            // Rysowanie bloków:
            block1.Draw(spriteBatch);
            block2.Draw(spriteBatch);
            block3.Draw(spriteBatch);
            block4.Draw(spriteBatch);
            block5.Draw(spriteBatch);
            // Rysowanie gracza:
            player.Draw(spriteBatch);
            // Zamykanie rysowania:
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
