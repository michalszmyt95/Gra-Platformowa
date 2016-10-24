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

        Rectangle a = new Rectangle(0, 300, 100, 100);
        Rectangle b = new Rectangle(110, 300, 100, 100);
        Rectangle c = new Rectangle(220, 300, 100, 100);
        Rectangle d = new Rectangle(550, 300, 100, 100);

        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.
        }

        // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            SceneManager.ObiektyStatyczne.Add(a);
            SceneManager.ObiektyStatyczne.Add(b);
            SceneManager.ObiektyStatyczne.Add(c);
            SceneManager.ObiektyStatyczne.Add(d);

            player = new Player(new Vector2(10,10), playerTexture);
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
            // Rysowanie elementów:
            spriteBatch.Draw(testBlock, a, Color.White);
            spriteBatch.Draw(testBlock, b, Color.White);
            spriteBatch.Draw(testBlock, c, Color.White);
            spriteBatch.Draw(testBlock, d, Color.White);

            player.Draw(spriteBatch);
            spriteBatch.End();// Zamykanie rysowania:


            base.Draw(gameTime);
        }
    }
}
