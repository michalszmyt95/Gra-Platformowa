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
    class Player : GameObject
    {
        Texture2D texture;
        KeyboardState kbState;

        int speed = 3;
        public double gravity = 0;
        public double velocity = 0.1;
        private double vx;
        private double vy;

        //Konstruktor gracza(położenie X,Y, lista obiektów z którymi gracz koliduje, tekstura gracza:
        public Player(int X, int Y, Texture2D texturePlayer)
        {
            this.texture = texturePlayer;
            this.position.X = X;
            this.position.Y = Y;
        }

        public void Update() // Funkcja wywoływana w Update gry.
        {
            this.UpdateKeyboardState();
            this.MoveLeft();
            this.MoveRight();
            this.Jump();
            this.Gravity();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
            /*
            Spritebatch.Draw(myTexture, // Texture
    myPosition,             // Position
    sourceRect,             // Source rectangle
    Color.White, // If you don't want to add tinting use white
    0,                      // Rotation
    null,                   // Origin
    Scale,                  // You guessed it
    SpriteEffects.None,     // Mirroring effects
    depth);                 // Layer depth
    */
        }


        public Vector2 GetPosition() { return this.position; }

        public void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        //Funkcje determinujące ruch:
        private void MoveLeft()
        {
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))
                this.position.X -= this.speed;
        }
        private void MoveRight()
        {
            if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))
                this.position.X += this.speed;
        }
        private void Jump()
        {
            if ((kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Space) || kbState.IsKeyDown(Keys.Space)))
            {
                this.position.Y -= this.speed;
            }
        }
        private void Gravity()
        {
                this.position.Y += (int)this.gravity;
                this.gravity += 0.1; 
        }
    }
}
