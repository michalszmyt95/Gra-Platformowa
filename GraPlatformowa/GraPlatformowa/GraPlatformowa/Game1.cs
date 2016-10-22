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
        InputManager inputManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content"; // Katalog, w którym znajduj¹ siê zasoby gry.
        }

        protected override void Initialize() // Inicjalizacja zewnêtrznych zasobów gry (takich jak muzyka)
        {
            base.Initialize();
            inputManager = new InputManager(player, Keyboard.GetState());
        }

        protected override void LoadContent() // Pobieranie zewnêtrznych zasobów do projektu.
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

            player = new Player(playerTexture);

        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime) // Metoda wywo³uje siê 60 razy na sekundê - pêtla gry(input, kolizje, dŸwiêk).
        {
            player.Move();
            inputManager.Skok();
            // animacja bazuj¹ca na czasie
            base.Update(gameTime);
        }




        /// Metoda wywo³ywana tak czêsto jak to mo¿liwe, po metodzie Update(),
        /// S³u¿y do odœwie¿ania wyœwietlanych elementów
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightCyan);



            // Rozpoczynanie rysowania:
            spriteBatch.Begin();
            // Rysowanie elementów:
            spriteBatch.Draw(testBlock, a, Color.White);
            spriteBatch.Draw(testBlock, b, Color.White);
            spriteBatch.Draw(testBlock, c, Color.White);
            //RUCH:

            // spriteBatch.Draw(testBlock, gracz, col);
            player.Draw(spriteBatch);
            // Zamykanie rysowania:
            spriteBatch.End();



            base.Draw(gameTime);
        }
    }
}
