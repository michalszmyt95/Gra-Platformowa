using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GraPlatformowa
{
    class SceneManager
    {
        Player player = new Player(new Vector2(300,250), Game1.playerLegsAnimationTexture, Game1.playerHeadTexture);
        Menu menu = new Menu();
        GraphicsDeviceManager graphics;

        public static List<Block> staticBlocks = new List<Block>();
        private int level = 1;
        private bool displayMenu = true;
        private bool gameMusicStarted = false;
        private bool menuMusicStarted = false;

        public SceneManager(GraphicsDeviceManager newGraphics)
        {
            this.graphics = newGraphics;
            this.Level1();
            Delegates();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (displayMenu)
                menu.Draw(spriteBatch);
            else
            {
                DrawLevels(spriteBatch);
                if (!menu.GetVisibility())
                    player.Draw(spriteBatch);
            } 
        }

        public void Update(GameTime gameTime,Game1 game)
        {
            if (menu.GetSoundsState()) player.SetSoundState(true);
            else player.SetSoundState(false);

            ManageResolution();
            if (menu.GetVisibility() == false) displayMenu = false;
            else displayMenu = true;

            if (menu.GetNewGameState())
            {
                this.level = 1;
                player.Restart();
                staticBlocks.Clear();
                this.Level1();
                menu.SetNewGameState(false);
                menu.Clear();
            }

            if (!displayMenu)
            {
                if (!this.gameMusicStarted)
                {
                    if (menu.GetMusicState())
                    {
                        this.menuMusicStarted = false;
                        MediaPlayer.Play(Game1.bgMusic);
                        this.gameMusicStarted = true;
                    }
                    else MediaPlayer.Stop();
                }

                for (int i = 0; i < staticBlocks.Count(); i++)
                    staticBlocks[i].Update();

                if (staticBlocks.Count() == 0)
                {
                    this.level += 1;
                    switch (level) //Wybór wyświetlania poziomu:
                    {
                        case 1: this.Level1(); player.Restart(); break;
                        case 2: this.Level2(); player.Restart(); break;
                        case 3: this.Level3(); player.Restart(); break;
                        case 4: this.Level4(); player.Restart(); break;
                        case 5: this.Level5(); player.Restart(); break;
                        default: menu.SetIfPlayerWon(true); menu.DisplayWin(); menu.SetVisibility(true); break;
                    }
                }
                Restart();
                Delegates();

                if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                    menu.SetVisibility(true);
                if (!menu.GetVisibility())
                    player.Update(gameTime);
            }
            else
            {
                if (!this.menuMusicStarted)
                {
                    if (menu.GetMusicState())
                    {
                        MediaPlayer.Play(Game1.menuMusic);
                        this.menuMusicStarted = true;
                        this.gameMusicStarted = false;
                    }
                    else MediaPlayer.Stop();
                }

                
                menu.Update(gameTime,game);
            }

        }

        private void ApplyGraphicsChanges()
        {
            if (!menu.GetGraphicsChangesState())
                graphics.ApplyChanges();
            menu.SetGraphicsChangesState(true);
        }

        private void ManageResolution()
        {
            switch (menu.GetResolution())
            {
                case "800x600": ChangeResolution(800,600); break;
                case "1024x768": ChangeResolution(1024,768); break;
                case "1366x768": ChangeResolution(1366,768); break;
                case "1600x900": ChangeResolution(1600,900); break;
                case "1920x1080": ChangeResolution(1920,1080); break;
            }
            switch (menu.GetFullscreenState())
            {
                case true: graphics.IsFullScreen = true; ApplyGraphicsChanges(); break;
                case false: graphics.IsFullScreen = false; ApplyGraphicsChanges(); break;
            }
        }

        private void ChangeResolution(int width,int height)
        {
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            ApplyGraphicsChanges();
        }

        private void DrawLevels(SpriteBatch spriteBatch)
        {
            foreach(Block block in staticBlocks)
            {
                    block.Draw(spriteBatch);
            }
        }

        private void Delegates()
        {
            foreach (Block block in SceneManager.staticBlocks)
            {
                player.PlayerGetOnBlock += block.OnPlayerGetOnBlock;
                player.PlayerEscapedFromBlock += block.OnPlayerEscapedFromBlock;
            }
        }

        private void Restart()
        {
            if (player.GetPosition().Y > 1000 && !everyBlockIsDisappearing())
            {
                player.Restart();

                staticBlocks.RemoveRange(0, staticBlocks.Count());
                this.level -= 1;
            }
        }

        private bool everyBlockIsDisappearing()
        {
            int j = 0;
            for (int i = 0; i < staticBlocks.Count(); i++)
            {
                if (staticBlocks[i].GetDisappearing())
                {
                    j++;
                }
                else return false;
            }
            if (j == staticBlocks.Count())
                return true;
            return false;
        }




        /// <summary>
        /// Poniżej znajdują się poziomy gry:
        /// </summary>
        private void Level1()
        {
            for (int i = 2; i < 8; i += 2)
            {
                if (i != 4)
                    new BlueBlock(new Vector2(140, 120+80 * i));
                else
                    new GreenBlock(new Vector2(160, 120 + 80 * i));
                if(i != 2)
                    new BlueBlock(new Vector2(120, 120 + 80 * (i-1)));
            }
            new BlueBlock(new Vector2(293, 280));
            new BlueBlock(new Vector2(535, 425));
            new BlueBlock(new Vector2(925, 425));

            new BlueBlock(new Vector2(1260, 335));
            new RedBlock(new Vector2(1340, 440));
            new RedBlock(new Vector2(1420, 275));
        }
        private void Level2()
        {
            // new BlueBlock(new Vector2(10, 200));
            for (int i = 0; i < 11; i++)
            {
                new RedBlock(new Vector2(60 + (120 * i), 600 - (15 * i)));
                new RedBlock(new Vector2(120 + (120 * i), 600 - (15 * i)));
            }
            new RedBlock(new Vector2(800, 400));
            new RedBlock(new Vector2(720, 300));
            new RedBlock(new Vector2(640, 200));
        }
        private void Level3()
        {
          //  new BlueBlock(new Vector2(10, 200));
            for (int i = 1; i < 10; i++)
                new RedBlock(new Vector2(200 + (100 * i), 400));
            new BlueBlock(new Vector2(600, 250));
            new BlueBlock(new Vector2(700, 300));
            new BlueBlock(new Vector2(500, 300));
        }
        private void Level4()
        {
         //   new BlueBlock(new Vector2(10, 100));
            new BlueBlock(new Vector2(300, 320));
            new BlueBlock(new Vector2(390, 300));
           // new BlueBlock(new Vector2(280, 100));
           // new BlueBlock(new Vector2(370, 100));
            new BlueBlock(new Vector2(580, 200));
            new GreenBlock(new Vector2(600+330, 200));
            new BlueBlock(new Vector2(900 + 330, 100));
            new RedBlock(new Vector2(1050 + 330, 180));
            new RedBlock(new Vector2(10, 600));
            new RedBlock(new Vector2(100, 600));
            new RedBlock(new Vector2(190, 600));
            new RedBlock(new Vector2(280, 600));
            new RedBlock(new Vector2(370, 600));
        }
        private void Level5()
        {
            for (int i = 0; i < 3; i++) //5 bloków przy sobie
                new BlueBlock(new Vector2(300 + 50 * i, 350));
            for (int i = 0; i < 3; i++)
                new BlueBlock(new Vector2(300 + 50 * i, 200));
            for (int i = 0; i < 5; i++)
                new RedBlock(new Vector2(550 + 50 * i, 350 - i * 15));
            for (int i = 0; i < 3; i++)
                new RedBlock(new Vector2(300 + 50 * i, 500));
            new RedBlock(new Vector2(1000, 300));
            new BlueBlock(new Vector2(1250, 300));

            new GreenBlock(new Vector2(700, 575));
            for (int i = 0; i < 6; i++)
                new RedBlock(new Vector2(1000 + 50 * i, 700));
            new GreenBlock(new Vector2(550, 700));
            new BlueBlock(new Vector2(300, 700));
            for (int i = 0; i < 6; i++)
                new RedBlock(new Vector2(1000 + 50 * i, 500));
        }

    }
}
