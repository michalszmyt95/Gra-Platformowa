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

        private float speed = 6.5f;
        private float gravity = 2.5f;
        private float jumpSpeed = 13f;
        private Vector2 velocity = new Vector2();
        private Rectangle rect;
        private bool standing = false;

        //Konstruktor gracza(położenie X,Y, lista obiektów z którymi gracz koliduje, tekstura gracza:
        public Player(Vector2 newPosition, Texture2D newTexture)
        {
            this.texture = newTexture;
            this.position = newPosition;
            //this.scale.X = newTexture.Width;
            //this.scale.Y = newTexture.Height;
            this.collision = new CollisionDetector();
            this.rect = new Rectangle(0,0, (int) this.scale.X, (int)this.scale.Y);
        }

        public void Update(GameTime gameTime) // Funkcja wywoływana w Update gry.
        {
            this.position += this.velocity;
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Collision();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.position, this.rect, Color.White);
        }


        public Vector2 GetPosition() { return this.position; }

        public void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        //Funkcje determinujące ruch:
        private void Move()
        {
            if ((kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left)))
            {
                    this.velocity.X = -this.speed;
            }
            else if ((kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right)))
            {
                    this.velocity.X = this.speed;
            }
            else
                this.velocity.X = 0;
        }
        private void Jump()
        {
            if ((kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Space) || kbState.IsKeyDown(Keys.Up)) && this.standing)
            {
                    this.velocity.Y = -jumpSpeed;
                    this.standing = false;
            }
            
            if(!this.standing)
            {
                velocity.Y += 0.15f * gravity; // <------ Grawitacja
            }
            
        }
        private void Collision()
        {
            //Jeśli funkcja collision.With() zwraca obiekt, znaczy ze gracz z danym obiektem aktualnie koliduje.
            //W przeciwnym wypadku, gdy funkcja zwraca null, znaczy, że gracz z niczym nie koliduje.
            Rectangle? obj = collision.With(this.position, this.scale);
            if (obj != null)
            {                                              /*  wysokosc momentu podniesienia gracza na platformie   ----VVVV   */
                if ((this.position.Y + this.scale.Y) >= obj.Value.Y && (this.position.Y + this.scale.Y) <= obj.Value.Y + 16 && this.velocity.Y > 0)
                {
                    this.position.Y = obj.Value.Y - this.scale.Y;
                    this.standing = true;
                }
            }
            else
            {
                this.standing = false;
            }

            if (this.standing)
            {
                this.velocity.Y = 0;
            }
            
        }
    }
}
