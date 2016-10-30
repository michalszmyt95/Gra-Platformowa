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
        Vector2 lastPosition = new Vector2();

        private float speed = 6.5f;
        private float gravity = 2.5f;
        private float jumpSpeed = 9.5f;
        private float friction = 1.5f;
        private Vector2 velocity = new Vector2();
        private Rectangle rect;
        private bool standing = false;

        public delegate void PlayerEscapedFromBlockEventHandler(object source, EventArgs args);
        public event PlayerEscapedFromBlockEventHandler PlayerEscapedFromBlock;

        public delegate void PlayerGetOnBlockEventHandler(object source, EventArgs args);
        public event PlayerGetOnBlockEventHandler PlayerGetOnBlock;

        private Block lastBlockColided; // Blok z którym gracz poprzednio kolidował.

        public Player(Vector2 newPosition, Texture2D newTexture)
        {
            this.texture = newTexture;
            this.position = newPosition;
            this.collision = new CollisionDetector(this);
            this.rect = new Rectangle(0,0, (int) this.texture.Width, (int)this.texture.Height);
            this.scale = new Vector2(this.texture.Width, this.texture.Height);
        }

        public void Update(GameTime gameTime) // Funkcja wywoływana w Update gry.
        {
            this.lastPosition = this.position;
            this.position += this.velocity;
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Gravity();
            this.Collision();
        }

        public void Draw(SpriteBatch spriteBatch) //Funkcja wywoływana w Draw gry.
        {
            spriteBatch.Draw(this.texture, this.position, this.rect, Color.White);
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

        public Vector2 GetLastPosition()
        {
            return this.lastPosition;
        }
        public Vector2 GetVelocity()
        {
            return this.velocity;
        }


        //Funkcje determinujące ruch:
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
        /*
        private void Collision()
        {
            //Jeśli funkcja collision.In() zwraca obiekt, znaczy ze pozycja i skala gracza ma część wspólną z danym obiektem.
            //W przeciwnym wypadku, gdy funkcja zwraca null, znaczy, że gracz z niczym aktualnie nie koliduje.
            Block block = collision.On();
            if (block != null)
            {
                if (this.lastPosition.Y == this.position.Y && this.standing) //<-- Ten blok kodu odpowiada za możliwość chodzenia po schodkach.
                    this.position.Y = block.GetPosition().Y - this.scale.Y;

                if (this.velocity.Y >= 0 && this.lastPosition.Y + this.scale.Y <= block.GetPosition().Y) //<-- Ten blok kodu odpowiada za warunek stania na bloku gdy gracz był w ruchu Y.
                {
                    this.position.Y = block.GetPosition().Y - this.scale.Y;
                    this.standing = true;
                }
                else this.standing = false; //<-- Ta linijka kodu jest potrzebna, by gracz mógł skakać stojąc na bloku.
            }
            else //Gdy blok z którym gracz koliduje to null, czyli gracz z niczym nie koliduje:
            {
                this.standing = false; 
                PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty);
            }
            if (this.standing)
            {


                this.velocity.Y = 0;
               //Emitowanie Eventu, że gracz właśnie wszedł na bok.
                PlayerGetOnBlock(block, EventArgs.Empty);
               //Emitowanie Eventu, że gracz właśnie wyszedł z bloku (dla warunku, że wciąż stoi na JAKIMŚ bloku - innym niż poprzednio).
                if (this.lastBlockColided != block)
                    PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty);
                this.lastBlockColided = block;
            }
        }
        */


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
