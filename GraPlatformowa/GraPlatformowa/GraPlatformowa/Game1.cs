using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
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
        RenderTarget2D target;

        public static Texture2D playerLegsAnimationTexture, blueBlockTexture, redBlockTexture, greenBlockTexture, playerHeadTexture;
        public static SpriteFont menuFont;
        public static SoundEffect footSteps, jump, landing, bgMusic, menuMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60.0); // Prêdkoœæ gry = 60 klatek na sekundê.
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.

        }

        // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        protected override void Initialize()
        {
            base.Initialize();
            sceneManager = new SceneManager(graphics);
            MediaPlayer.IsRepeating = true;
            target = new RenderTarget2D(GraphicsDevice, 1600, 900); //<-- Ustawienie rozdzielczoœci gry, któr¹ bêdzie mo¿na skalowaæ do docelowych rozdzielczoœci gracza.
        }

        // Pobieranie zewnêtrznych zasobów do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc¹ konstrukora new SpriteBatch(), który u¿ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //£adowanie zasobów:
            try {
                //Tekstury
                playerHeadTexture = Content.Load<Texture2D>("playerHead");
                playerLegsAnimationTexture = Content.Load<Texture2D>("playerLegsAnimation");
                blueBlockTexture = Content.Load<Texture2D>("blue2");
                redBlockTexture = Content.Load<Texture2D>("red2");
                greenBlockTexture = Content.Load<Texture2D>("green2");
                //Zasoby muzyczne
                bgMusic = Content.Load<SoundEffect>("BackgroundMusic");
                menuMusic = Content.Load<SoundEffect>("MenuMusic");
                footSteps = Content.Load<SoundEffect>("FootStep");
                jump = Content.Load<SoundEffect>("Jump");
                landing = Content.Load<SoundEffect>("Landing");
                //Czcionki
                menuFont = Content.Load<SpriteFont>("Menu");
            }
            catch
            {

                System.Windows.Forms.MessageBox.Show("Brak dostêpu do contentu gry (folder \"Content\").\nMo¿liwe, ¿e usuniêto jakieœ pliki, przemieszczono je, lub zmieniono nazwê folderu \"Content\" na inn¹.");

            }

        }

        protected override void UnloadContent(){}

        // Metoda wywo³uje siê 60 razy na sekundê - pêtla gry(input, kolizje, dŸwiêk):
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            sceneManager.Update(gameTime,this);
        }

        // Metoda wywo³ywana tak czêsto jak to mo¿liwe, po metodzie Update(), s³u¿y do odœwie¿ania wyœwietlanych elementów:
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
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
            //  spriteBatch.Draw(target, new Rectangle(0, (int) ((graphics.PreferredBackBufferHeight - (int) (graphics.PreferredBackBufferWidth * 9/16))/2.3f), graphics.PreferredBackBufferWidth, (int) (graphics.PreferredBackBufferWidth * 9/16)), Color.White);
            spriteBatch.Draw(target, new Rectangle(0, (int)((graphics.PreferredBackBufferHeight - (int)(graphics.PreferredBackBufferWidth * 9 / 16)) / 2.3f), graphics.PreferredBackBufferWidth, (int)(graphics.PreferredBackBufferWidth * 9 / 16)), Color.White);
            spriteBatch.End();

        }
    }
}
