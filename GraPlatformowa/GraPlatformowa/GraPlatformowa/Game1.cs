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
        RenderTarget2D target;

        public static Texture2D playerLegsAnimationTexture, blueBlockTexture, redBlockTexture, greenBlockTexture, playerTexture, playerLegsTexture, playerHeadTexture;
        public static SpriteFont menuFont;

       // Song bgMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            screenManager = new ScreenManager(graphics);
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60.0); // Prêdkoœæ gry = 60 klatek na sekundê.
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.

        }

        // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            sceneManager = new SceneManager();
            target = new RenderTarget2D(GraphicsDevice, 1600, 900); //<-- Ustawienie rozdzielczoœci gry, któr¹ bêdzie mo¿na skalowaæ do docelowych rozdzielczoœci gracza.
        }

        // Pobieranie zewnêtrznych zasobów do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc¹ konstrukora new SpriteBatch(), który u¿ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);
          //  targetBatch = new SpriteBatch(GraphicsDevice); // - do renderowania wszystkiego w jednym konkretnym pakiecie.

            //£adowanie zasobów:
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

            menuFont = Content.Load<SpriteFont>("Menu");

        }

        protected override void UnloadContent(){}

        // Metoda wywo³uje siê 60 razy na sekundê - pêtla gry(input, kolizje, dŸwiêk):
        protected override void Update(GameTime gameTime)
        {
            sceneManager.Update(gameTime,this);
            for (int i = 0; i < SceneManager.staticBlocks.Count(); i++)
            {
                SceneManager.staticBlocks[i].Update();
            }

            

            screenManager.Update(gameTime);
            
            base.Update(gameTime);
        }

        // Metoda wywo³ywana tak czêsto jak to mo¿liwe, po metodzie Update(), s³u¿y do odœwie¿ania wyœwietlanych elementów:
        protected override void Draw(GameTime gameTime)
        {
            //Renderowanie do targeta:         
            GraphicsDevice.SetRenderTarget(target);

            //Rysowanie gry do targetBatch:
            GraphicsDevice.Clear(new Color(33, 22, 35)); //<-- T³o gry.
            spriteBatch.Begin();
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();

            //Renderowanie spowrotem do buffera:
            GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(new Color(0, 0, 0)); //<-- T³o za renderowan¹ gr¹.
            //Renderowanie tego co by³o renderowane do target w g³ównym bufferze, skaluj¹c rozdzielczoœæ do tej któr¹ ustawi³ sobie gracz:
            spriteBatch.Begin();        //Domyslnie rozdzielczosc gry 1600x900, dlatego skalowanie zawsze do prostok¹ta w proporcji 16/9 - VVV
            spriteBatch.Draw(target, new Rectangle(0, (int) ((graphics.PreferredBackBufferHeight - (int) (graphics.PreferredBackBufferWidth * 9/16))/2.3f), graphics.PreferredBackBufferWidth, (int) (graphics.PreferredBackBufferWidth * 9/16)), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
