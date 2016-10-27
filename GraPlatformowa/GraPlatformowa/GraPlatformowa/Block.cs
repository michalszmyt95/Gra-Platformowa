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
    class Block : GameObject
    {
        protected Texture2D texture = Game1.blueBlockTexture;
        protected Rectangle rect;

        public Block(){}

        public Block(Vector2 newPosition, Texture2D newTexture)
        {
            this.rect.X = (int)newPosition.X;
            this.rect.Y = (int)newPosition.Y;
            this.rect.Width = (int)this.scale.X;
            this.rect.Height = (int)this.scale.Y;
            this.texture = newTexture;
            SceneManager.staticBlocks.Add(this);
        }

        public Block(Rectangle newRect, Texture2D newTexture)
        {
            this.rect = newRect;
            this.texture = newTexture;
            SceneManager.staticBlocks.Add(this);
        }

        public void Update(GameTime gameTime)
        {
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.rect, Color.White);
        }

        public void Disappear()
        {
            SceneManager.staticBlocks.Remove(this);
            this.rect.X = -1000;
        }

        public float getX()
        {
            return this.position.X;
        }
        public float getY()
        {
            return this.position.Y;
        }
        public int getWidth()
        {
            return this.rect.Width;
        }
        public int getHeight()
        {
            return this.rect.Height;
        }


    }
}
