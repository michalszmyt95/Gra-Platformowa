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
        private float jumpSpeed = 9.5f;
        private Vector2 velocity = new Vector2();
        private Rectangle rect;
        private int stairHeight = 15;
        private bool standing = false;
        private bool jumping = false;

        public delegate void PlayerEscapedFromBlockEventHandler(object source, EventArgs args);
        public event PlayerEscapedFromBlockEventHandler PlayerEscapedFromBlock;

        public delegate void PlayerGetOnBlockEventHandler(object source, EventArgs args);
        public event PlayerGetOnBlockEventHandler PlayerGetOnBlock;

        Block actualBlock; // Blok z którym aktualnie koliduje gracz.
        List<Block> disappearList = new List<Block>(); // Lista bloków gotowych do zniknięcia.

        public Player(Vector2 newPosition, Texture2D newTexture)
        {
            this.texture = newTexture;
            this.position = newPosition;
            this.collision = new CollisionDetector();
            this.rect = new Rectangle(0,0, (int) this.texture.Width, (int)this.texture.Height);
            this.scale = new Vector2(this.texture.Width, this.texture.Height);
        }

        public void Update(GameTime gameTime) // Funkcja wywoływana w Update gry.
        {
            this.position += this.velocity;
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Collision();
            this.Restart();
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
                    this.jumping = true;
            }
            
            if(!this.standing)
            {
                velocity.Y += 0.15f * gravity; // <------ Grawitacja
            }
            
        }
        private Block Collision()
        {
            //Jeśli funkcja collision.With() zwraca obiekt, znaczy ze gracz z danym obiektem aktualnie koliduje.
            //W przeciwnym wypadku, gdy funkcja zwraca null, znaczy, że gracz z niczym nie koliduje.
            Block block = collision.With(this.position, this.scale);
            
            if (block != null)
            {            /*  Przedzial wysokosci bloku, z ktorego gracz automatycznie zostanie podniesiony na góre bloku  -------VVVV   */
                if ((this.position.Y + this.scale.Y) >= block.getY() && (this.position.Y + this.scale.Y) <= block.getY() + this.stairHeight && this.velocity.Y >= 0)
                {
                    if (!this.jumping)
                    {
                        this.position.Y = block.getY() - this.scale.Y;
                        this.standing = true;
                    }
                    // Jeśli gracz skakał zamiast tylko spadać, to zależność wchodzenia po schodach nie powinna działać, dlatego by gracz sie utrzymał na bloku,
                    // Musi mieć dość dużą wartość spadania velocity.Y
                    // (chodzi o to, by gracz co skoczył na zbyt wysoki blok nie został automatycznie wciągnięty na górę gdy nie pokonał całej drogi by stanąć na bloku)
                    else if (this.jumping && this.velocity.Y > 3.1 )
                    {
                        this.position.Y = block.getY() - this.scale.Y;
                        this.standing = true;
                        this.jumping = false;
                    }
                }
                else
                {
                    this.standing = false; //<-- Ta linijka kodu poprawia błąd związany z utrzymywaniem
                    // stałej pozycji gracza po wejściu na kolejny blok, jeśli między zmianą bloku nie przerwała się kolizja.
                }
            }
            else
            {
                this.standing = false;
            }

            if (this.standing)
            {
                this.velocity.Y = 0;
                
                if(PlayerGetOnBlock != null)
                    PlayerGetOnBlock(block,EventArgs.Empty);
            }

            return block;
        }

        /*
        private void BlockDisappearingAfterCollision()
        {
            actualBlock = this.Collision();
            if (actualBlock != null && this.standing)
                disappearList.Add(actualBlock);
            if (disappearList != null)
                foreach (Block block in disappearList)
                    if (this.collision.With(this.position, this.scale) != block)
                        block.Disappear();
        }
        */

        //Tymczasowa funkcja u gracza, przydatna do testów:
        private void Restart()
        {
            if (this.position.Y >= 1000)
            {
                this.velocity = new Vector2(0, 0);
                this.position.Y = 10;
                this.position.X = 10;
            }
        }
    }
}
