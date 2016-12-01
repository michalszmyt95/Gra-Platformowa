using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GraPlatformowa
{
    class SceneManager
    {
        Player player = new Player(new Vector2(300,250), Game1.playerLegsAnimationTexture, Game1.playerHeadTexture);
        Menu menu = new Menu();
        SoundEffectInstance menuMusic = Game1.menuMusic.CreateInstance();
        SoundEffectInstance bgMusic = Game1.bgMusic.CreateInstance();
        List<SoundEffectInstance> AllMusic = new List<SoundEffectInstance>();
        MusicManager music;
        GraphicsDeviceManager graphics;

        public static List<Block> staticBlocks = new List<Block>();
        private int level = 1;

        public SceneManager(GraphicsDeviceManager newGraphics)
        {
            this.graphics = newGraphics;
            Delegates();
            AllMusic.Add(menuMusic);
            AllMusic.Add(bgMusic);
            music = new MusicManager(ref this.AllMusic);
        }

        public void Draw(SpriteBatch spriteBatch) //DRAW GRY
        {
            if (menu.GetVisibility())
                menu.Draw(spriteBatch);
            else if(!menu.GetVisibility())
            {
                DrawLevels(spriteBatch);
                if (!menu.GetVisibility())
                    player.Draw(spriteBatch);
            } 
        }

        private void DrawLevels(SpriteBatch spriteBatch)
        {
            foreach (Block block in staticBlocks)
            {
                block.Draw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime,Game1 game) //UPDATE GRY
        {
            ManageResolution();
            ManageSounds();

            if (menu.GetNewGameState())
                NewGame(1); // <-------------------- Ustalenie od którego poziomu startuje gra

            if (menu.GetVisibility())
                menu.Update(gameTime, game);
            else
                ManageGameplay(gameTime);
        }

        private void ManageSounds()
        {
            if (menu.GetSoundsState())
                player.SetSoundState(true);
            else
                player.SetSoundState(false);

            if (menu.GetMusicState())
            {
                switch (menu.GetVisibility())
                {
                    case true: music.PlayOnlyThis(ref menuMusic); break;
                    case false: music.PlayOnlyThis(ref bgMusic); break;
                }
            }
            else
            {
                music.StopAllMusic();
            }
        }

        private void ManageGameplay(GameTime gameTime) {
            for (int i = 0; i < staticBlocks.Count(); i++)
                staticBlocks[i].Update();

            if (staticBlocks.Count() == 0)
            {
                this.level += 1;
                SwitchLevel(this.level);
            }

            RestartLogic();
            Delegates();
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                menu.SetVisibility(true);
            if (!menu.GetVisibility())
                player.Update(gameTime);
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
                default: break;
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

        private void Delegates()
        {
            foreach (Block block in SceneManager.staticBlocks)
            {
                player.PlayerGetOnBlock += block.OnPlayerGetOnBlock;
                player.PlayerEscapedFromBlock += block.OnPlayerEscapedFromBlock;
            }
        }

        private void RestartLogic()
        {
            if (player.GetPosition().Y > 1000 && !CheckIfEveryBlockIsDisappearing())
            {
                player.Restart();
                staticBlocks.RemoveRange(0, staticBlocks.Count());
                this.level -= 1;
            }
        }

        private bool CheckIfEveryBlockIsDisappearing()
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

        private void NewGame(int lvl)
        {
            if (staticBlocks.Count != 0)
                staticBlocks.Clear();
            this.level = lvl;
            SwitchLevel(lvl);
            menu.SetNewGameState(false);
            menu.Refresh();
        }

        private void SwitchLevel(int lvl)
        {
            switch (lvl) //Wybór wyświetlania poziomu:
            {
                case 1: this.Level1(); player.Restart(); break;
                case 2: this.Level2(); player.Restart(); break;
                case 3: this.Level3(); player.Restart(); break;
                case 4: this.Level4(); player.Restart(); break;
                case 5: this.Level5(); player.Restart(); break;
                case 6: this.Level6(); player.Restart(); break;
                case 7: this.Level7(); player.Restart(); break;
                case 8: this.Level8(); player.Restart(); break;
                case 9: this.Level9(); player.Restart(); break;
                case 10: this.Level10(); player.Restart(); break;
                default: menu.SetIfPlayerWon(true); menu.DisplayWin(); menu.SetVisibility(true); break;
            }
        }

        /// <summary>
        /// Poniżej znajdują się poziomy gry:
        /// </summary>
        /// 
        #region POZIOMY GRY REGION
        private void Level1()
        {
            new BlueBlock(new Vector2(293, 280));

            new BlueBlock(new Vector2(600, 440));
            new BlueBlock(new Vector2(680, 420));
            new BlueBlock(new Vector2(760, 400));
            new BlueBlock(new Vector2(840, 380));
            new BlueBlock(new Vector2(920, 360));

            new RedBlock(new Vector2(1240, 520));
        }
        private void Level2()
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
            new BlueBlock(new Vector2(435, 425));
            new BlueBlock(new Vector2(705, 525));
            new BlueBlock(new Vector2(975, 425));

            new BlueBlock(new Vector2(1260, 335));
            new RedBlock(new Vector2(1340, 440));
            new RedBlock(new Vector2(1420, 275));
        }
        private void Level3()
        {
            for (int i = 0; i < 3; i++)
            {
                new BlueBlock(new Vector2(293 + i * 400, 280));
                new BlueBlock(new Vector2(353 + i * 400, 280));
                new BlueBlock(new Vector2(413 + i * 400, 280));
                new BlueBlock(new Vector2(473 + i * 400, 280));
            }

            new GreenBlock(new Vector2(583, 500));
            new GreenBlock(new Vector2(983, 500));

            new BlueBlock(new Vector2(293, 600));
            new BlueBlock(new Vector2(1273, 600));
            new RedBlock(new Vector2(783, 700));
        }
        private void Level4()
        {
            new BlueBlock(new Vector2(293, 280));
            new BlueBlock(new Vector2(353, 280));
            for (int i = 0; i < 11; i++)
            {
                if (i < 3 || i > 7)
                {
                    new RedBlock(new Vector2(150 + (120 * i), 600 - (15 * i)));
                    new RedBlock(new Vector2(210 + (120 * i), 600 - (15 * i)));
                }
            }
            new RedBlock(new Vector2(800, 400));
            new RedBlock(new Vector2(720, 300));
            new RedBlock(new Vector2(640, 200));
        }
        private void Level5()
        {
            new BlueBlock(new Vector2(293, 280));
            new BlueBlock(new Vector2(353, 260));
            new BlueBlock(new Vector2(413, 240));
            new BlueBlock(new Vector2(473, 220));

            new BlueBlock(new Vector2(693, 340));
            new BlueBlock(new Vector2(753, 320));
            new BlueBlock(new Vector2(813, 300));
            new BlueBlock(new Vector2(873, 280));

            new BlueBlock(new Vector2(1093, 400));
            new BlueBlock(new Vector2(1153, 380));
            new BlueBlock(new Vector2(1213, 360));
            new BlueBlock(new Vector2(1273, 340));

            new BlueBlock(new Vector2(393-30, 680));
            new BlueBlock(new Vector2(453 - 30, 700));
            new BlueBlock(new Vector2(513 - 30, 720));
            new BlueBlock(new Vector2(573 - 30, 740));

            new BlueBlock(new Vector2(893+50, 700));
            new BlueBlock(new Vector2(953+50, 680));
            new BlueBlock(new Vector2(1013+50, 660));
            new BlueBlock(new Vector2(1073 + 50, 640));

                new RedBlock(new Vector2(510, 515));
            new RedBlock(new Vector2(990, 515));

            new RedBlock(new Vector2(150, 800));
            new RedBlock(new Vector2(750, 800));
            new RedBlock(new Vector2(1400, 800));
        }
        private void Level6()
        {

            new BlueBlock(new Vector2(293, 280));
            new BlueBlock(new Vector2(650, 220));
            new GreenBlock(new Vector2(600+400, 240));
            new BlueBlock(new Vector2(900 + 400, 140));
            new RedBlock(new Vector2(1050 + 400, 220));
            new RedBlock(new Vector2(80, 740));
            new RedBlock(new Vector2(170, 740));
            new RedBlock(new Vector2(260, 740));
            new RedBlock(new Vector2(350, 740));
            new RedBlock(new Vector2(440, 740));
        }
        private void Level7()
        {
            for (int i = 0; i < 3; i++) //5 bloków przy sobie
                new BlueBlock(new Vector2(300 + 50 * i, 320));
            for (int i = 0; i < 3; i++)
                new BlueBlock(new Vector2(300 + 50 * i, 170));
            for (int i = 0; i < 5; i++)
                new RedBlock(new Vector2(550 + 50 * i, 320 - i * 15));
            for (int i = 0; i < 3; i++)
                new RedBlock(new Vector2(300 + 50 * i, 470));
            new RedBlock(new Vector2(1000, 270));
            new BlueBlock(new Vector2(1250, 270));
            new GreenBlock(new Vector2(700, 545));
            for (int i = 0; i < 6; i++)
                new RedBlock(new Vector2(1000 + 50 * i, 670));
            new GreenBlock(new Vector2(550, 670));
            new BlueBlock(new Vector2(300, 670));
            for (int i = 0; i < 6; i++)
                new RedBlock(new Vector2(1000 + 50 * i, 470));
        }
        private void Level8()
        {
            new BlueBlock(new Vector2(293, 280));
            new RedBlock(new Vector2(400, 100));
            new RedBlock(new Vector2(400, 850));
            new RedBlock(new Vector2(540, 700));
            new GreenBlock(new Vector2(860, 660));
            new RedBlock(new Vector2(1220, 700));
            new RedBlock(new Vector2(1000, 550));
            new RedBlock(new Vector2(680, 550));
            new RedBlock(new Vector2(820, 400));
            new RedBlock(new Vector2(1220, 450));
            new RedBlock(new Vector2(1440, 350));
            new GreenBlock(new Vector2(1220, 250));
            new RedBlock(new Vector2(1440, 150));
            new RedBlock(new Vector2(900, 200));
            new RedBlock(new Vector2(700, 150));
            new RedBlock(new Vector2(150, 700));
        }
        private void Level9()
        {
            new BlueBlock(new Vector2(293, 280));
            new RedBlock(new Vector2(740, 460));
            new GreenBlock(new Vector2(1000, 340));
            new RedBlock(new Vector2(1260, 440));
            new RedBlock(new Vector2(1340, 460));
            new RedBlock(new Vector2(400, 560));
            new RedBlock(new Vector2(1100, 300));
            new BlueBlock(new Vector2(740, 220));
            new RedBlock(new Vector2(920, 170));
            new RedBlock(new Vector2(460, 140));
            new BlueBlock(new Vector2(740, 720));
            new RedBlock(new Vector2(900, 800));
            new RedBlock(new Vector2(1000, 620));
            new RedBlock(new Vector2(1360, 800));
        }
        private void Level10()
        {
            new BlueBlock(new Vector2(293, 280));
            new RedBlock(new Vector2(323, 305));
            new RedBlock(new Vector2(353, 330));
            new RedBlock(new Vector2(383, 355));
            new RedBlock(new Vector2(413, 330));
            new RedBlock(new Vector2(443, 305));
            new RedBlock(new Vector2(473, 280));
            new RedBlock(new Vector2(383, 380));
            new RedBlock(new Vector2(383, 405));
           
            for (int i = 0; i<6; i++)
            {
                if (i != 0 && i != 5)
                {
                    new RedBlock(new Vector2(550, 280 + 25 * i));
                    new RedBlock(new Vector2(650, 280 + 25 * i));
                }
                if ( i == 0 || i == 5)
                    new RedBlock(new Vector2(600, 280 + 25 * i));
                if (i != 5)
                {
                    new RedBlock(new Vector2(750, 280 + 25 * i));
                    new RedBlock(new Vector2(850, 280 + 25 * i));
                }
                new RedBlock(new Vector2(550, 550 + 25 * i));
                new RedBlock(new Vector2(750, 550 + 25 * i)); 
                new RedBlock(new Vector2(850, 550 + 25 * i));
                new RedBlock(new Vector2(950, 550 + 25 * i));
                new RedBlock(new Vector2(1100, 550 + 25 * i));

            }
            new RedBlock(new Vector2(800, 405));
            new RedBlock(new Vector2(600, 650));
            new RedBlock(new Vector2(650, 625));
            new RedBlock(new Vector2(700, 650));
            new RedBlock(new Vector2(1050, 600));
            new RedBlock(new Vector2(1000, 575));
        }
        #endregion
    }
}
