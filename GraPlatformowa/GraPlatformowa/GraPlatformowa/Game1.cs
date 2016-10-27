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
        SceneManager sceneManager;

        public static Texture2D blueBlockTexture, redBlockTexture, greenBlockTexture, playerTexture;
        //Song bgMusic;

        Player player;

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
            player = new Player(new Vector2(800,10), playerTexture);
            sceneManager = new SceneManager(spriteBatch);
            sceneManager.Initialize();
        }


        // Pobieranie zewnêtrznych zasobów do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc¹ konstrukora new SpriteBatch(), który u¿ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //£adowanie zasobów:
            playerTexture = Content.Load<Texture2D>("pl1");
            blueBlockTexture = Content.Load<Texture2D>("blue2");
            redBlockTexture = Content.Load<Texture2D>("red2");
            greenBlockTexture = Content.Load<Texture2D>("green2");
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
            sceneManager.Draw();
            // Rysowanie gracza:
            player.Draw(spriteBatch);
            // Zamykanie rysowania:
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
