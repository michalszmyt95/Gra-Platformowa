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
        ScreenManager screenManager;
        SpriteBatch targetBatch;
        RenderTarget2D target;

        public static Texture2D playerLegsAnimationTexture, blueBlockTexture, redBlockTexture, greenBlockTexture, playerTexture, playerLegsTexture, playerHeadTexture;

       // Song bgMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            screenManager = new ScreenManager(graphics);
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
            screenManager.Update(gameTime);

            if (graphics.IsFullScreen)
            {
                graphics.PreferredBackBufferWidth = GraphicsDevice.DisplayMode.Width;
                graphics.PreferredBackBufferHeight = GraphicsDevice.DisplayMode.Height;
            }

            base.Update(gameTime);
        }

        // Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(), s�u�y do od�wie�ania wy�wietlanych element�w:
        protected override void Draw(GameTime gameTime)
        {

            // TargetBatch - do renderowania wszystkiego w jednym konkretnym pakiecie.
            targetBatch = new SpriteBatch(GraphicsDevice);
            target = new RenderTarget2D(GraphicsDevice, 1600, 900); //<-- Ustawienie rozdzielczo�ci gry, kt�r� b�dzie mo�na skalowa� do docelowych rozdzielczo�ci gracza.
            GraphicsDevice.SetRenderTarget(target);

            //Rysowanie gry do targetBatch:
            GraphicsDevice.Clear(new Color(33, 22, 35)); //<-- T�o.
            targetBatch.Begin();
            sceneManager.Draw(targetBatch);
            targetBatch.End();

            //Renderowanie spowrotem do buffera:
            GraphicsDevice.SetRenderTarget(null);

            //Renderowanie tego co by�o renderowane do target w g��wnym bufferze, skaluj�c rozdzielczo�� do tej kt�r� ustawi� sobie gracz:
            targetBatch.Begin();
            targetBatch.Draw(target, new Rectangle(0, 0, graphics.PreferredBackBufferWidth, graphics.PreferredBackBufferHeight), Color.White);
            targetBatch.End();

            base.Draw(gameTime);
        }
    }
}
