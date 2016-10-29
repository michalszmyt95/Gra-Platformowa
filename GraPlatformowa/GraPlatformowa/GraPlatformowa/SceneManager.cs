﻿using System;
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
        Player player = new Player(new Vector2(10,10), Game1.playerTexture);
        public static List<Block> staticBlocks = new List<Block>();
        private int level = 1;

        public void Initialize()
        {
            this.Level5();
            Delegaty();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawLevels(spriteBatch);
            player.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            if (staticBlocks.Count() == 0)
            {
                this.level += 1;
                switch (level)
                {
                    case 1: this.Level1(); player.Restart(); break;
                    case 2: this.Level2(); player.Restart(); break;
                    case 3: this.Level3(); player.Restart(); break;
                    case 4: this.Level4(); player.Restart(); break;
                    case 5: this.Level5(); player.Restart(); break;
                    default: this.Level5(); player.Restart(); break;
                }
            }
            Restart();
            Delegaty();
        }

        private void DrawLevels(SpriteBatch spriteBatch)
        {
            foreach(Block block in staticBlocks)
            {
                    block.Draw(spriteBatch);
            }
        }

        private void Delegaty()
        {
            foreach (Block block in SceneManager.staticBlocks)
            {
                player.PlayerGetOnBlock += block.OnPlayerGetOnBlock;
                player.PlayerEscapedFromBlock += block.OnPlayerEscapedFromBlock;
            }
        }

        private void Restart()
        {
            if (player.GetPosition().Y > 1000)
            {
                player.Restart();

                staticBlocks.RemoveRange(0, staticBlocks.Count());
                this.level -= 1;
            }

        }




        /// <summary>
        /// Poniżej znajdują się poziomy gry:
        /// </summary>
        private void Level1()
        {
            for (int i = 10; i<1400; i+=340)
                new BlueBlock(new Vector2(i, 180));

            for (int i = 1200; i >= 10; i -= 150)
            {
                if(i>250) new BlueBlock(new Vector2(i, 600 - i / 4));
                else new RedBlock(new Vector2(i, 600 - i / 4));

            }

        }
        private void Level2()
        {
            for (int i = 2; i < 9; i += 2)
            {
                if (i != 6)
                    new BlueBlock(new Vector2(30, 80 * i));
                else
                    new GreenBlock(new Vector2(30, 80 * i));
                new BlueBlock(new Vector2(10, 80 * (i-1)));
            }

            new BlueBlock(new Vector2(300, 385));
            new BlueBlock(new Vector2(380, 385));
            new BlueBlock(new Vector2(460, 385));
            new BlueBlock(new Vector2(540 + 300, 385));
            new BlueBlock(new Vector2(800 + 300, 400));
            new BlueBlock(new Vector2(720 + 300, 295));
            new RedBlock(new Vector2(930+300, 275));
        }
        private void Level3()
        {
            new BlueBlock(new Vector2(10, 200));
            for (int i = 1; i < 10; i++)
                new RedBlock(new Vector2(200 + (100 * i), 400));
            new BlueBlock(new Vector2(600, 250));
            new BlueBlock(new Vector2(700, 300));
            new BlueBlock(new Vector2(500, 300));
        }
        private void Level4()
        {
            new BlueBlock(new Vector2(10, 200));
            for (int i = 0; i < 11; i++)
            {
                new RedBlock(new Vector2(60 + (120 * i), 600 - (15 * i)));
                new RedBlock(new Vector2(120 + (120 * i), 600 - (15 * i)));
            }
            new RedBlock(new Vector2(800, 400));
            new RedBlock(new Vector2(720, 300));
            new RedBlock(new Vector2(640, 200));
        }
        private void Level5()
        {
            new BlueBlock(new Vector2(10, 100));
            new BlueBlock(new Vector2(80, 100));
            new BlueBlock(new Vector2(150, 100));
            new BlueBlock(new Vector2(220, 100));
            new BlueBlock(new Vector2(290, 100));
            new BlueBlock(new Vector2(500, 200));
            new GreenBlock(new Vector2(580+330, 200));
            new BlueBlock(new Vector2(900 + 330, 100));
            new BlueBlock(new Vector2(1050 + 330, 180));
            new RedBlock(new Vector2(100, 600));
            new RedBlock(new Vector2(200, 600));
            new RedBlock(new Vector2(300, 600));
            new RedBlock(new Vector2(400, 600));
        }

    }
}
