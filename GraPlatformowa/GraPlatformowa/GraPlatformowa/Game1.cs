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

        Rectangle a = new Rectangle(100, 300, (int)(50),50);
        Rectangle b = new Rectangle(152, 300, (int)(50), 50);
        Rectangle c = new Rectangle(204, 300, (int)(50),50);

        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // Katalog, w kt�rym znajduj� si� zasoby gry.
        }

        protected override void Initialize() // Inicjalizacja zewn�trznych zasob�w gry (takich jak muzyka)
        {
            base.Initialize();
        }
        protected override void LoadContent() // Pobieranie zewn�trznych zasob�w do projektu.
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

            player = new Player(playerTexture);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) // Metoda wywo�uje si� 60 razy na sekund� - p�tla gry(input, kolizje, d�wi�k).
        {
            //Sterowanie:
            KeyboardState stan = Keyboard.GetState();
            if (stan.IsKeyDown(Keys.Down))
            {
                //y += 1;
            }
            else if (stan.IsKeyDown(Keys.Up))
            {
                //y -= 5;
            }
            else if (stan.IsKeyDown(Keys.Left))
            {
                //x -= 1;
            }
            else if (stan.IsKeyDown(Keys.Right))
            {
                //x += 1;
            }
            

            // animacja bazuj�ca na czasie
            base.Update(gameTime);
        }

        /// Metoda wywo�ywana tak cz�sto jak to mo�liwe, po metodzie Update(),
        /// S�u�y do od�wie�ania wy�wietlanych element�w
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightCyan);



            // Rozpoczynanie rysowania:
            spriteBatch.Begin();
            // Rysowanie element�w:
            spriteBatch.Draw(testBlock, a, Color.White);
            spriteBatch.Draw(testBlock, b, Color.White);
            spriteBatch.Draw(testBlock, c, Color.White);
            //RUCH:

             // spriteBatch.Draw(testBlock, gracz, col);

            // Zamykanie rysowania:
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
