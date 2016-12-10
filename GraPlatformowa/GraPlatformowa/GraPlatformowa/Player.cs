﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GraPlatformowa
{
    class Player : GameObject
    {
        #region ZMIENNE POSTACI
        //Zmienne dla animacji/rysowania:
        private Texture2D headTexture;
        private Texture2D legsTexture;
        private SpriteEffects flip;
        private int timeElapsed = 0;
        private int delay = 47;
        private int frames = 0;
        private Rectangle frameRect;
        private bool animateJump = false;
        private bool animateWalk = false;
        private Vector2 headPositionDifference;
        int timeElapsedForWalking = 0;
        bool jumping = false;
        bool hasLanded = false;

        //Zmienne logiki postaci:
        private KeyboardState kbState;
        private CollisionDetector collision;
        private Vector2 startPosition;
        private Vector2 lastPosition;
        private Vector2 velocity;
        private float speed = 6.5f;
        private float gravity = 2.5f;
        private float jumpSpeed = 9.5f;
        private float friction = 2f;
        private bool standing = false;

        private bool soundState = true;

        #endregion

        // Delegaci dla eventów określających kiedy gracz wskoczył na blok i kiedy z niego zeskoczył:
        public delegate void PlayerEscapedFromBlockEventHandler(object source, EventArgs args);
        public event PlayerEscapedFromBlockEventHandler PlayerEscapedFromBlock;

        public delegate void PlayerGetOnBlockEventHandler(object source, EventArgs args);
        public event PlayerGetOnBlockEventHandler PlayerGetOnBlock;

        private Block lastBlockColided;

        public Player(Vector2 newStartPosition, Texture2D newLegsTexture, Texture2D newHeadTexture)
        {
            this.headTexture = newHeadTexture;
            this.legsTexture = newLegsTexture;
            this.position = this.startPosition = newStartPosition;
            this.collision = new CollisionDetector(this);
            this.frameRect = new Rectangle(0,0, (int)this.legsTexture.Width / 4, (int)this.legsTexture.Height / 3);
            this.scale = new Vector2(this.legsTexture.Width/4, this.legsTexture.Height/3);
        }

        //Funkcja wywoływana w Update gry:
        public void Update(GameTime gameTime)
        {
            this.lastPosition = this.position;
            this.position += this.velocity;
            this.HeadMove();
            this.UpdateKeyboardState();
            this.Move();
            this.Jump();
            this.Gravity();
            this.Collision();
            this.Animation(gameTime);
            if (this.soundState)
                this.MakeSound(gameTime);
        }

        //Funkcja wywoływana w Draw gry:
        public void Draw(SpriteBatch spriteBatch)
        {
            Vector2 headPosition = this.position + headPositionDifference;
            spriteBatch.Draw(this.legsTexture, this.position, this.frameRect, Color.White, 0, new Vector2(0,0), new Vector2(1,1), flip, 0);
            spriteBatch.Draw(this.headTexture, headPosition, null, Color.White, 0, new Vector2(0,0), new Vector2(1, 1), flip, 0);
        }

        #region DODATKOWE FUNKCJE

        //Input:
        private void UpdateKeyboardState()
        {
            this.kbState = Keyboard.GetState();
        }

        public void Restart()
        {
            this.position = startPosition;
            this.velocity = new Vector2(0, 0);
            this.flip = SpriteEffects.None;
        }

        //Funkcja która dostaje referencje danej zmiennej liczbowej, 
        //która ma stać się wartością argumentu 'To', zwiększając się o wartość argumentu speed.
        private void valueTo(ref float value, float to, float speed)
        {
            if (value < to) value += speed;
            else if (value > to) value -= speed;
            if (Math.Abs(value - to) < speed) value = to;
        }

        #endregion

        #region DŹWIĘK

        public void SetSoundState(bool newState)
        {
            this.soundState = newState;
        }

        private void MakeSound(GameTime gameTime)
        {
            SoundEffectInstance footStep = Game1.footSteps.CreateInstance();
            SoundEffectInstance jump = Game1.jump.CreateInstance();
            SoundEffectInstance land = Game1.landing.CreateInstance();
            land.Volume = 0.3f;

            timeElapsedForWalking += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (this.animateWalk && this.standing)
            {
                if (timeElapsedForWalking >= 130)
                {
                    if (land.State != SoundState.Playing) {
                        footStep.Play();
                        timeElapsedForWalking = 0;
                    }
                }
            }
            
            if (this.animateJump)
            {
                if (!jumping){
                    jump.Play();
                    footStep.Stop();
                    land.Stop();
                    jumping = true;
                }

            }
            
            if ( this.standing && !this.hasLanded ) {
                land.Play();
                footStep.Stop();
                hasLanded = true;
                this.jumping = false;
            }
            if (!this.standing) hasLanded = false;
        }

        #endregion

        #region ANIMACJA
        //Animacja:
        private void Animation(GameTime gameTime)
        {
            this.timeElapsed += (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (this.timeElapsed >= this.delay){
                if (this.animateWalk && this.standing) WalkAnimation(ref timeElapsed);
                else if (this.animateJump) JumpAnimation(ref timeElapsed);
                else StandAnimation(ref timeElapsed);
            }
        }
        private void StandAnimation(ref int timeElapsed)
        {
            this.frameRect = new Rectangle(36 * this.frames, 0, (int)this.legsTexture.Width / 4, (int)this.legsTexture.Height / 3);
            if (this.timeElapsed >= this.delay*15){
                this.frameRect = new Rectangle(36 * this.frames, 0, (int)this.legsTexture.Width / 4, (int)this.legsTexture.Height / 3);
                if (frames >= 3) frames = 0;
                else frames++;
                timeElapsed = 0;
            }
        }
        private void JumpAnimation(ref int timeElapsed)
        {
            this.frameRect = new Rectangle(36 * this.frames, 48, (int)this.legsTexture.Width / 4, (int)this.legsTexture.Height / 3);
            if (this.velocity.Y < 0){
                if (frames < 3) frames++;
                timeElapsed = 0;
            }
            else if (this.velocity.Y > 0){
                if (frames > 0) frames--;
                timeElapsed = 0;
            }
        }
        private void WalkAnimation(ref int timeElapsed){
            this.frameRect = new Rectangle(36 * this.frames, 24, (int)this.legsTexture.Width / 4, (int)this.legsTexture.Height / 3);
            if (frames >= 3) frames = 0;
            else frames++;
            timeElapsed = 0;
        }

        private void HeadMove(){
            if (this.velocity.Y > 0) valueTo(ref headPositionDifference.Y, -22 -this.velocity.Y, 0.7f);
            else if (this.velocity.Y < 0) valueTo(ref headPositionDifference.Y, -15, 2 );
            else valueTo(ref headPositionDifference.Y, -20, 5f);
            if (this.velocity.X != 0) valueTo(ref headPositionDifference.X, -this.velocity.X/2f, 0.4f);
            else valueTo(ref headPositionDifference.X, 0, 0.6f);
        }

        #endregion

        #region RUCH POSTACI I POZYCJA

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
            if ((kbState.IsKeyDown(Keys.A) || kbState.IsKeyDown(Keys.Left))) {
                this.velocity.X = -this.speed;
                flip = SpriteEffects.FlipHorizontally;
                this.animateWalk = true;
            }
            else if ((kbState.IsKeyDown(Keys.D) || kbState.IsKeyDown(Keys.Right))) {
                this.velocity.X = this.speed;
                flip = SpriteEffects.None;
                this.animateWalk = true;
            }
            else
            {
                this.animateWalk = false;
                //Tarcie (friction):
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
            {
                this.velocity.Y = -jumpSpeed;
                this.animateJump = true;
                this.animateWalk = false;
            }
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
                    this.animateJump = false;
                    PlayerGetOnBlock(block, EventArgs.Empty); // <-- Gracz właśnie wszedł na blok.
                    if (this.lastBlockColided != block)
                        PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty); //<-- dla warunku, że wciąż stoi na JAKIMŚ bloku.
                    this.lastBlockColided = block;
                }
                else PlayerEscapedFromBlock(lastBlockColided, EventArgs.Empty); // <-- dla warunku, że gracz już na żadnym bloku nie stoi.
        }
        
    }
    #endregion
}
