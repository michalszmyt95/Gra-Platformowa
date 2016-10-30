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
        Texture2D headTexture;
        Texture2D legsTexture;
        KeyboardState kbState;
        CollisionDetector collision;
        Vector2 lastPosition;

        private Vector2 headPositionDifference = new Vector2();

        private float speed = 6.5f;
        private float gravity = 2.5f;
        private float jumpSpeed = 9.5f;
        private float friction = 2.5f;
        private Vector2 velocity = new Vector2();
        private Rectangle rect;
        private bool standing = false;

        public delegate void PlayerEscapedFromBlockEventHandler(object source, EventArgs args);
        public event PlayerEscapedFromBlockEventHandler PlayerEscapedFromBlock;

        public delegate void PlayerGetOnBlockEventHandler(object source, EventArgs args);
        public event PlayerGetOnBlockEventHandler PlayerGetOnBlock;

        private Block lastBlockColided; // Blok z którym gracz poprzednio kolidował.

        public Player(Vector2 newPosition, Texture2D newLegsTexture, Texture2D newHeadTexture)
        {
            this.headTexture = newHeadTexture;
            this.legsTexture = newLegsTexture;
            this.position = newPosition;
            this.collision = new CollisionDetector(this);
            this.rect = new Rectangle(0,0, (int) this.legsTexture.Width, (int)this.legsTexture.Height);
            this.scale = new Vector2(this.legsTexture.Width, this.legsTexture.Height);
        }

        public void Update(GameTime gameTime) // Funkcja wywoływana w Update gry.
        {
            this.lastPosition = this.position;
            this.position += this.velocity;
            this.HeadMove();
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Gravity();
            this.Collision();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.legsTexture, this.position, this.rect, Color.White);
            Vector2 headPosition = this.position + headPositionDifference;
            spriteBatch.Draw(this.headTexture, headPosition, this.rect, Color.White);
        }

        public void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        public void Restart()
        {
            this.position.X = 10;
            this.position.Y = 10;
            this.velocity = new Vector2(0,0);
        }

        //Funkcja która dostaje referencje danej zmiennej liczbowej, 
        //która ma stać się wartością argumentu To, zwiększając się o wartość argumentu speed.
        private void valueTo(ref float value, float to, float speed){
            if (value < to)
                value += speed;
            else if (value > to)
                value -= speed;
            if (Math.Abs(value - to) < speed)
                value = to;
            }

        private void HeadMove()
        {
            if (this.velocity.Y > 0) valueTo(ref headPositionDifference.Y, -27 -this.velocity.Y, 0.7f);
            else if (this.velocity.Y < 0) valueTo(ref headPositionDifference.Y, -18, 2);
            else valueTo(ref headPositionDifference.Y, -22,4f);
            if (this.velocity.X != 0) valueTo(ref headPositionDifference.X, -this.velocity.X/3, 0.5f);
           // else if (this.velocity.X < 0) valueTo(ref headPositionDifference.X, 3, 0.5f);
            else valueTo(ref headPositionDifference.X, 0, 1);
        }

        public Vector2 GetLastPosition()
        {
            return this.lastPosition;
        }
        public Vector2 GetVelocity()
        {
            return this.velocity;
        }

        //Funkcje determinujące ruch postaci:
        private void Move()
        {
            if ((kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))) this.velocity.X = -this.speed;
            else if ((kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))) this.velocity.X = this.speed;
            else
            { //Tarcie (friction):
                if (!this.standing)
                {
                    if (this.velocity.X > this.friction)
                        this.velocity.X -= 0.4f * this.friction;
                    else if (this.velocity.X < -this.friction)
                        this.velocity.X += 0.4f * this.friction;
                    else this.velocity.X = 0;
                }
                else
                {
                    if (this.velocity.X > this.friction)
                        this.velocity.X -= 0.9f * this.friction;
                    else if (this.velocity.X < -this.friction)
                        this.velocity.X += 0.9f * this.friction;
                    else this.velocity.X = 0;
                }
            }
        }
        private void Jump()
        {
            if ((kbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Space) || kbState.IsKeyDown(Keys.Up)) && this.standing)
                this.velocity.Y = -jumpSpeed;
        }
        private void Gravity()
        {
            if (!this.standing) velocity.Y += 0.15f * gravity;
        }
        private void Collision()  //collision.IcyTowerLike() [0] <- blok z którym gracz aktuanie koliduje, [1] <- czy gracz na nim stoi
        {
            List<object> collisionList = new List<object>();
            collisionList = collision.IcyTowerLike(ref this.position.Y, ref this.velocity.Y);

            Block block = (Block) collisionList[0];
            this.standing = (bool) collisionList[1];

            if (this.standing)
            {   
                PlayerGetOnBlock(block, EventArgs.Empty); // <-- Gracz właśnie wszedł na blok.
                if (this.lastBlockColided != block)
                    PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty); //<-- dla warunku, że wciąż stoi na JAKIMŚ bloku.
                this.lastBlockColided = block;
            }
            else PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty); // <-- dla warunku, że gracz już na żadnym bloku nie stoi.
        }
        
    }
}
