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

        public static Texture2D playerLegsAnimationTexture, blueBlockTexture, redBlockTexture, yellowBlockTexture, playerHeadTexture;
        public static SpriteFont menuFont;
        public static SoundEffect footSteps, jump, landing, bgMusic, menuMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1600;
            graphics.PreferredBackBufferHeight = 900;
            graphics.IsFullScreen = false;
            TargetElapsedTime = TimeSpan.FromSeconds(1 / 60.0); // Pr�dko�� gry = 60 klatek na sekund�.
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.

        }

        // Inicjalizacja zewn�trznych zasob�w gry
        protected override void Initialize()
        {
            base.Initialize();
            sceneManager = new SceneManager(graphics);
            target = new RenderTarget2D(GraphicsDevice, 1600, 900); //<-- Ustawienie rozdzielczo�ci gry, kt�r� b�dzie mo�na skalowa� do docelowych rozdzielczo�ci gracza.
        }

        // Pobieranie zewn�trznych zasob�w do projektu.
        protected override void LoadContent()
        {
            // Stworzono obiekt za pomoc� konstrukora new SpriteBatch(), kt�ry u�ywany jest do renderowania tekstur.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //�adowanie zasob�w:
            try {
                //Tekstury
                playerHeadTexture = Content.Load<Texture2D>("playerHead");
                playerLegsAnimationTexture = Content.Load<Texture2D>("playerLegsAnimation");
                blueBlockTexture = Content.Load<Texture2D>("blue2");
                redBlockTexture = Content.Load<Texture2D>("red2");
                yellowBlockTexture = Content.Load<Texture2D>("yellow2");
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
                System.Windows.Forms.MessageBox.Show("Brak dost�pu do contentu gry (folder \"Content\").\nMo�liwe, �e usuni�to jakie� pliki, przemieszczono je, lub zmieniono nazw� folderu \"Content\" na inn�.");
            }
        }

        protected override void UnloadContent(){}

        // Metoda wywo�uje si� 60 razy na sekund� - p�tla gry(input, kolizje, d�wi�k):
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            sceneManager.Update(gameTime,this);
        }

        // Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(), s�u�y do od�wie�ania wy�wietlanych element�w:
        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            //Renderowanie do targeta:         
            GraphicsDevice.SetRenderTarget(target);

            //Rysowanie gry do targetBatch:
            GraphicsDevice.Clear(new Color(33, 22, 35)); //<-- T�o gry.
            spriteBatch.Begin();
            sceneManager.Draw(spriteBatch);
            spriteBatch.End();

            //Renderowanie spowrotem do buffera:
            GraphicsDevice.SetRenderTarget(null);

            GraphicsDevice.Clear(new Color(0, 0, 0)); //<-- T�o za renderowan� gr�.
            //Renderowanie tego co by�o renderowane do target w g��wnym bufferze, skaluj�c rozdzielczo�� do tej kt�r� ustawi� sobie gracz:
            spriteBatch.Begin();        //Domyslnie rozdzielczosc gry 1600x900, dlatego skalowanie zawsze do prostok�ta w proporcji 16/9 - VVV
            //  spriteBatch.Draw(target, new Rectangle(0, (int) ((graphics.PreferredBackBufferHeight - (int) (graphics.PreferredBackBufferWidth * 9/16))/2.3f), graphics.PreferredBackBufferWidth, (int) (graphics.PreferredBackBufferWidth * 9/16)), Color.White);
            spriteBatch.Draw(target, new Rectangle(0, (int)((graphics.PreferredBackBufferHeight - (int)(graphics.PreferredBackBufferWidth * 9 / 16)) / 2.3f), graphics.PreferredBackBufferWidth, (int)(graphics.PreferredBackBufferWidth * 9 / 16)), Color.White);
            spriteBatch.End();

        }
    }
}
