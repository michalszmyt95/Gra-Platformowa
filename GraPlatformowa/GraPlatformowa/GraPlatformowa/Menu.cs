using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.Text;

namespace GraPlatformowa
{
    class Menu
    {
        private string logo = "Logo gry";
        private string[] menuOptions = new string[] { "Resume", "New game", "Options", "Author", "Exit" };
        private string resume = "Resume";
        private string[] resolutionOptions = new string[] { "Resolution: ", "800x600", "1024x768", "1280x720", "1366x768", "1440x900", "1600x900", "1920x1080" };
        private string[] soundOptions = new string[] { "Sound: ", "Music: ","On", "Off" };
        private int selected = 1;
        private int chosenResolution;
        private Color selectedColor = Color.MediumVioletRed;
        private Color unselectedColor = Color.White;
        private KeyboardState kbState;
        private KeyboardState lastKbState;

        public bool startNewGame { get; set; } = false;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(Game1.menuFont, logo, new Vector2(650, 50), Color.White);
            for (int i = 1; i < menuOptions.Length; i++)
            {
                if(i == selected)
                    spriteBatch.DrawString(Game1.menuFont, menuOptions[i], new Vector2(650, 150 + 100 * i), selectedColor);
                else
                    spriteBatch.DrawString(Game1.menuFont, menuOptions[i], new Vector2(650, 150 + 100 * i), unselectedColor);
            }
        }
        public void Update(GameTime gameTime, Game1 game)
        {
            UpdateKeyboardState();
            Selecting(game);
        }

        //Input:
        private void UpdateKeyboardState()
        {
            this.lastKbState = kbState;
            this.kbState = Keyboard.GetState();
        }
        private void Selecting(Game1 game)
        {
            if(kbState.IsKeyDown(Keys.W) && !lastKbState.IsKeyDown(Keys.W) || kbState.IsKeyDown(Keys.Up) && !lastKbState.IsKeyDown(Keys.Up))
            {
                selected -= 1;
            }
            else if(kbState.IsKeyDown(Keys.S) && !lastKbState.IsKeyDown(Keys.S) || kbState.IsKeyDown(Keys.Down) && !lastKbState.IsKeyDown(Keys.Down))
            {
                selected += 1;
            }
            if (selected > menuOptions.Length-1)
                selected = 1;
            if (selected < 1)
                selected = menuOptions.Length-1;

            if (kbState.IsKeyDown(Keys.Enter))
                switch (selected)
            {
                case 1: this.startNewGame = true; menuOptions[1] = resume; break;
                case 4: game.Exit(); break;
            }

        }
    }
}
