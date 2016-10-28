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
        SpriteBatch spriteBatch;

        public static List<Block> staticBlocks = new List<Block>();
       
        public SceneManager(SpriteBatch newSpriteBatch)
        {
            this.spriteBatch = newSpriteBatch;
        }

        public void Initialize()
        {
            this.level1();
        }

        public void Draw()
        {
            DrawLevel1();
        }

        private void level1()
        {
            new BlueBlock(new Vector2(0, 200));
            new BlueBlock(new Vector2(200, 400));
            new BlueBlock(new Vector2(260, 400));
            new BlueBlock(new Vector2(320, 385));
            new BlueBlock(new Vector2(380, 385));
            new RedBlock(new Vector2(450, 375));
            new BlueBlock(new Vector2(800, 400));
            new BlueBlock(new Vector2(720, 295));
            new GreenBlock(new Vector2(930, 275));
        }

        public void Update(GameTime gameTime)
        {
            if (staticBlocks.Count() == 0)
            {
                level1();
            }

        }

        private void DrawLevel1()
        {
            foreach(Block block in staticBlocks)
            {
                    block.Draw(spriteBatch);
            }
        }


    }
}
