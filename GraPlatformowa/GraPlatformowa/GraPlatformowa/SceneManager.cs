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
            drawLevel1();
        }

        private void level1()
        {
            staticBlocks.Add(new BlueBlock(new Vector2(0, 200)));
            staticBlocks.Add(new BlueBlock(new Vector2(200, 400)));
            staticBlocks.Add(new BlueBlock(new Vector2(300, 385)));
            staticBlocks.Add(new BlueBlock(new Vector2(400, 370)));
            staticBlocks.Add(new BlueBlock(new Vector2(800, 400)));
            staticBlocks.Add(new BlueBlock(new Vector2(720, 295)));
            staticBlocks.Add(new BlueBlock(new Vector2(930, 275)));
        }

        private void drawLevel1()
        {
            foreach(Block obj in staticBlocks)
            {
                    obj.Draw(spriteBatch);
            }
        }


    }
}
