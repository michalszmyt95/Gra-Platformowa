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

        }
        public Vector2 GetPosition() { return this.position; }

        KeyboardState stanKlawiatury = Keyboard.GetState();

        //Funkcje determinujące ruch:
        public void MoveLeft()
        {
            if (stanKlawiatury.IsKeyDown(Keys.Left))
            {
                //x -= 1;
            }
        }
        public void MoveRight()
        {
            if (stanKlawiatury.IsKeyDown(Keys.Right))
            {
                //x += 1;
            }
        }
        public void Jump()
        {
            if (stanKlawiatury.IsKeyDown(Keys.Up))
            {
                //y -= 5;
            }
        }
    }
}
