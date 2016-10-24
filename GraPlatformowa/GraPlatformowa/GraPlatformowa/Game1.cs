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
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.
        }

        // Inicjalizacja zewn�trznych zasob�w gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            SceneManager.ObiektyStatyczne.Add(a);
            SceneManager.ObiektyStatyczne.Add(b);
            SceneManager.ObiektyStatyczne.Add(c);
            SceneManager.ObiektyStatyczne.Add(d);

            player = new Player(new Vector2(10,10), playerTexture);
        }


        // Pobieranie zewn�trznych zasob�w do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc� konstrukora new SpriteBatch(), kt�ry u�ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //�adowanie zasob�w:
            testBlock = Content.Load<Texture2D>("blue2");
            playerTexture = Content.Load<Texture2D>("pl1");
            //bgMusic = Content.Load<Song>("bgMusic1");
            // Odtwarzanie muzyki przy starcie aplikacji
            //MediaPlayer.Play(bgMusic);
            // Zap�tlanie muzyki
            MediaPlayer.IsRepeating = true;

        }

        protected override void UnloadContent(){}


        // Metoda wywo�uje si� 60 razy na sekund� - p�tla gry(input, kolizje, d�wi�k):
        protected override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            // animacja bazuj�ca na czasie
            base.Update(gameTime);
        }

        /// Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(),
        /// S�u�y do od�wie�ania wy�wietlanych element�w
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightCyan); //Pierwsze wy�wietla si� t�o.

            // Rozpoczynanie rysowania:
            spriteBatch.Begin();
            // Rysowanie element�w:
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
