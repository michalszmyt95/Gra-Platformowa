using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GraPlatformowa
{
    class YellowBlock : Block
    {
        public YellowBlock(Vector2 newPosition)
        {
            this.position.X = newPosition.X;
            this.position.Y = newPosition.Y;
            this.texture = Game1.yellowBlockTexture;
            this.rect.X = (int)newPosition.X;
            this.rect.Y = (int)newPosition.Y;
            this.rect.Width = (int)this.scale.X;
            this.rect.Height = (int)this.scale.Y;
            this.disappearSpeed = 1f;
            SceneManager.staticBlocks.Add(this);
        }
        public override void OnPlayerGetOnBlock(object source, EventArgs e){}
    }
}
