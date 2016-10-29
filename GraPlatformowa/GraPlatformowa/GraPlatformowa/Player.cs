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
            
            //Jeśli funkcja collision.In() zwraca obiekt, znaczy ze pozycja i skala gracza ma część wspólną z danym obiektem.
            //W przeciwnym wypadku, gdy funkcja zwraca null, znaczy, że gracz z niczym aktualnie nie koliduje.
            Block block = collision.In();

            if (block != null)
            {            /*  Przedzial wysokosci bloku, z ktorego gracz automatycznie zostanie podniesiony na góre bloku  -------VVVV   */
                if ((this.position.Y + this.scale.Y) >= block.getY() && (this.position.Y + this.scale.Y) <= block.getY() + this.stairHeight && this.velocity.Y >= 0)
                {
                    // Kod sprawdzający czy gracz zmienił blok z którym kolidował poprzednio wiedząc, że poprzedni nie był null:
                    if (this.lastBlockColided != block)
                        PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty);
                    this.lastBlockColided = block;

                    if (!this.jumping)
                    {
                        this.position.Y = block.getY() - this.scale.Y;
                        this.standing = true;
                    }
                    // Jeśli gracz skakał zamiast tylko spadać, to zależność wchodzenia po schodach nie powinna działać, dlatego by gracz sie utrzymał na bloku,
                    // Musi mieć dość dużą wartość spadania velocity.Y
                    // (chodzi o to, by gracz co skoczył na zbyt wysoki blok nie został automatycznie wciągnięty na górę gdy nie pokonał całej drogi by stanąć na bloku)
                    else if (this.jumping && this.velocity.Y >= 3.1f)
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
                //Gdy poprzedni blok z którym gracz kolidował był null:
                this.standing = false;
                PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty);
            }

            if (this.standing)
            {
                this.velocity.Y = 0;
                PlayerGetOnBlock(block,EventArgs.Empty);
            }

            return block;
        }
        public void Restart()
        {
            this.position.X = 10;
            this.position.Y = 10;
            this.velocity.Y = 0;
        }

    }
}
