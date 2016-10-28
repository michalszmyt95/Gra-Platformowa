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
            graphics.IsFullScreen = true;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 720;
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.
        }

        // Inicjalizacja zewn�trznych zasob�w gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            player = new Player(new Vector2(800,10), playerTexture);
            sceneManager = new SceneManager(spriteBatch);
            sceneManager.Initialize();

            // Delegaty
            foreach (Block block in SceneManager.staticBlocks) {
                player.PlayerGetOnBlock += block.OnPlayerGetOnBlock;
                player.PlayerEscapedFromBlock += block.OnPlayerEscapedFromBlock;
            }

        }


        // Pobieranie zewn�trznych zasob�w do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc� konstrukora new SpriteBatch(), kt�ry u�ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //�adowanie zasob�w:
            playerTexture = Content.Load<Texture2D>("pl1");
            blueBlockTexture = Content.Load<Texture2D>("blue2");
            redBlockTexture = Content.Load<Texture2D>("red2");
            greenBlockTexture = Content.Load<Texture2D>("green2");
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
            // Rysowanie blok�w:
            sceneManager.Draw();
            for (int i = 0; i < SceneManager.staticBlocks.Count(); i++)
                SceneManager.staticBlocks[i].Update();
            // Rysowanie gracza:
            player.Draw(spriteBatch);
            // Zamykanie rysowania:
            spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
