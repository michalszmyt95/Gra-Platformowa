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
        CollisionDetector collision;

        private float speed = 3f;
        private float gravity = 3f;
        private Vector2 velocity = new Vector2();
        private bool jumping = true;

        //Konstruktor gracza(położenie X,Y, lista obiektów z którymi gracz koliduje, tekstura gracza:
        public Player(Vector2 newPosition, Texture2D newTexture)
        {
            this.texture = newTexture;
            this.position = newPosition;
            this.scale.X = newTexture.Width;
            this.scale.Y = newTexture.Height;
            this.collision = new CollisionDetector();
        }

        public void Update(GameTime gameTime) // Funkcja wywoływana w Update gry.
        {
            this.position += this.velocity;
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Gravity();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.position, Color.White);
        }


        public Vector2 GetPosition() { return this.position; }

        public void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        //Funkcje determinujące ruch:
        private void Move()
        {
            if (kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))
                this.velocity.X = -this.speed;
            else if (kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))
                this.velocity.X = this.speed;
            else
                this.velocity.X = 0;
        }
        private void Jump()
        {
            if ((kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Space) || kbState.IsKeyDown(Keys.Space)) && !this.jumping)
            {
                this.velocity.Y = -10f;
                this.position.Y -= 5;
                this.jumping = true;
            }
            
            if(this.jumping)
            {
                velocity.Y += 0.1f * gravity;
            }
            
        }
        private void Gravity()
        {
            //foreach (Rectangle obj in SceneManager.ObiektyStatyczne)
            //{
            Rectangle? obj = collision.With(this.position, this.scale);

            if (obj != null)
            {
                this.jumping = false;
                this.position.Y = obj.Value.Y - this.scale.Y;
            }
            else
            {
                this.jumping = true;
            }
            //}
            if (!this.jumping)
            {
                this.velocity.Y = 0;
            }
            
        }
    }
}
