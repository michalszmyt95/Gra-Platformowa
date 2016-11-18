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
        private int selected = 0;
        private int chosenResolution;

        private Color selectedColor = Color.MediumVioletRed;
        private Color unselectedColor = Color.White;

        private KeyboardState kbState;
        private KeyboardState lastKbState;

        List<MenuItem> menuItems = new List<MenuItem>();

        public bool startNewGame = false;

        public Menu()
        {
            this.mainMenuView();
        }


        public void Update(GameTime gameTime, Game1 game)
        {
            UpdateKeyboardState();
            Selecting(game);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem menuItem in menuItems)
            {
                menuItem.Draw(spriteBatch);
            }
        }

 

        private void mainMenuView()
        {
            menuItems.Add(new MenuItem(new Vector2(650, 200), "New Game"));
            menuItems.Add(new MenuItem(new Vector2(650, 300), "Levels"));
            menuItems.Add(new MenuItem(new Vector2(650, 400), "Options"));
            menuItems.Add(new MenuItem(new Vector2(650, 500), "Author"));
            menuItems.Add(new MenuItem(new Vector2(650, 600), "Exit"));
        }
        private void levelsView()
        {

        }
        private void optionsView()
        {

        }
        private void authorView()
        {

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

            for(int i = 0; i< menuItems.Count; i++)
            {
                if (selected == i) menuItems[i].isItSelected(true);
                else menuItems[i].isItSelected(false);
            }

            if (selected > menuItems.Count-1)
                selected = 0;
            if (selected < 0)
                selected = menuItems.Count-1;

            /*
            if (kbState.IsKeyDown(Keys.Enter))
                switch (selected)
            {
                case 1: this.startNewGame = true; menuOptions[1] = resume; break;
                case 4: game.Exit(); break;
            }
            */
        }
    }
}
