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
    class InputManager
    {
        private KeyboardState oldState;
        Player player;

        public InputManager(Player player)
        {
            this.player = player;
        }

        // na podstawie przykładu ze strony https://msdn.microsoft.com/en-us/library/bb203902.aspx - przykład czytania inputu gracza:

        public void Skok()
        {
            KeyboardState newState = Keyboard.GetState();

            // Czy wciśnięto dany przycisk?
            if (newState.IsKeyDown(Keys.Space) || newState.IsKeyDown(Keys.W))
            {
                this.player.position.Y -= 1;
            }
        }
    }
}
