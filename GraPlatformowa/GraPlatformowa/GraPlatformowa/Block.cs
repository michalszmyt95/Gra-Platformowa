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

        public virtual void OnPlayerGetOnBlock(object source, EventArgs e)
        {
            if (source == this)
                this.disappearing = true;
        }

        public virtual void OnPlayerEscapedFromBlock(object source, EventArgs e)
        {
            if (source == this)
                this.disappearing = true;
        }

        protected Texture2D texture = Game1.blueBlockTexture;
        protected Rectangle rect;
        protected float alpha = 1;
        protected float disappearSpeed = 1;
        protected bool disappearing = false;

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

        public void Update()
        {
            if (this.disappearing)
                Disappear();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.rect, Color.White * this.alpha);
        }

        public void Disappear()
        {
            if (this.alpha > 0)
                this.alpha -= 0.005f * disappearSpeed;
            else {
                SceneManager.staticBlocks.Remove(this);
            }
        }
    }
}
