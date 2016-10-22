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
    class Player : GameObject
    {
        Texture2D texture;
        int currentFrame; //Potrzebne do animacji
        int speed = 2;
        double velocity = 0;
        const int FRAMES = 6;
        public Player(Texture2D texturePlayer)
        {
            this.texture = texturePlayer;
        }
        public void Update() // Funkcja wywoływana w Update gry.
        {

        }
        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, new Rectangle((int)this.position.X,(int)this.position.Y,(int)this.scale.X,(int)this.scale.Y), Color.White);   
        }
        public Vector2 GetPosition() { return this.position; }

        KeyboardState kbState = Keyboard.GetState();

        //Funkcje determinujące ruch:
        public void MoveLeft()
        {
            this.position.X -= this.speed;
        }
        public void MoveRight()
        {
            this.position.X += this.speed;
        }
        public void Jump()
        {
            this.position.Y -= this.speed;
        }

        public void Move()
        {

        }
    }
}
