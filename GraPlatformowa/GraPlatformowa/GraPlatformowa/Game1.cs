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
        public static Texture2D playerLegsAnimationTexture, blueBlockTexture, redBlockTexture, greenBlockTexture, playerTexture, playerLegsTexture, playerHeadTexture;

       // Song bgMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferWidth = 1440;
            graphics.PreferredBackBufferHeight = 720;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60.0); // Pr�dko�� gry = 60 klatek na sekund�.
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.

        }

        // Inicjalizacja zewn�trznych zasob�w gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            sceneManager = new SceneManager();
            sceneManager.Initialize();
        }

        // Pobieranie zewn�trznych zasob�w do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc� konstrukora new SpriteBatch(), kt�ry u�ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //�adowanie zasob�w:
            playerTexture = Content.Load<Texture2D>("pl1");
            playerLegsTexture = Content.Load<Texture2D>("playerLegs");
            playerHeadTexture = Content.Load<Texture2D>("playerHead");
            playerLegsAnimationTexture = Content.Load<Texture2D>("playerLegsAnimation");
            blueBlockTexture = Content.Load<Texture2D>("blue2");
            redBlockTexture = Content.Load<Texture2D>("red2");
            greenBlockTexture = Content.Load<Texture2D>("green2");

            // bgMusic = Content.Load<Song>("bgMusic1");
            // Odtwarzanie muzyki przy starcie aplikacji:
            // MediaPlayer.Play(bgMusic);
            // MediaPlayer.IsRepeating = true;
        }

        protected override void UnloadContent(){}


        // Metoda wywo�uje si� 60 razy na sekund� - p�tla gry(input, kolizje, d�wi�k):
        protected override void Update(GameTime gameTime)
        {
            sceneManager.Update(gameTime);

            for (int i = 0; i < SceneManager.staticBlocks.Count(); i++)
            {
                SceneManager.staticBlocks[i].Update();
            }

            // animacja bazuj�ca na czasie
            base.Update(gameTime);
        }

        // Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(), s�u�y do od�wie�ania wy�wietlanych element�w:
        protected override void Draw(GameTime gameTime)
        {
            //Pierwsze wy�wietla si� t�o.
            GraphicsDevice.Clear(new Color(33,22,35));

            spriteBatch.Begin();
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
