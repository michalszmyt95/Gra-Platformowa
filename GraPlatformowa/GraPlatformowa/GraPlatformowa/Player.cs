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
        KeyboardState kbState;

        int currentFrame; //Potrzebne do animacji
        int speed = 2;
        public double gravity = 0;
        public double velocity = 0.1;
        const int FRAMES = 6;
        public Rectangle rectangle;

        private void UpdateRectangle()
        {
            this.rectangle.X = (int)this.position.X;
            this.rectangle.Y = (int)this.position.Y;
            this.rectangle.Width = (int)this.scale.X;
            this.rectangle.Height = (int)this.scale.Y;
        }

        public Player(int X,int Y,Texture2D texturePlayer)
        {
            this.texture = texturePlayer;
            this.position.X = X;
            this.position.Y = Y;
            this.UpdateRectangle();
        }
        public void Update() // Funkcja wywoływana w Update gry.
        {
            this.UpdateKeyboardState();
            this.MoveLeft();
            this.MoveRight();
            this.Jump();
            this.Gravity();
            this.UpdateRectangle();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, rectangle, Color.White);
        }


        public Vector2 GetPosition() { return this.position; }

        public void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        //Funkcje determinujące ruch:
        public void MoveLeft()
        {
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))
                this.position.X -= this.speed;
        }
        public void MoveRight()
        {
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))
                this.position.X += this.speed;
        }
        public void Jump()
        {
            if (kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Space))
                this.position.Y -= this.speed;
        }
        private void Gravity()
        {
            this.position.Y += (int)this.gravity;
            gravity += velocity;
        }


    }
}
