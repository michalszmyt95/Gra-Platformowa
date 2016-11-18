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

        private Color selectedColor = Color.MediumVioletRed;
        private Color unselectedColor = Color.White;

        private KeyboardState kbState;
        private KeyboardState lastKbState;

        private string currentView = "mainMenuView";
        private List<MenuItem> menuItems = new List<MenuItem>();

        private bool gameStarted = false;
        private bool isVisible = true;
        private bool newGame = false;
        private bool playerWon = false;

        public Menu()
        {
            MainMenuView();
        }

        public void Update(GameTime gameTime, Game1 game)
        {
            UpdateKeyboardState();
            Selecting(game);
        }

        public bool GetVisibility()
        {
            return isVisible;
        }
        public void SetVisibility(bool newIsVisible)
        {
            isVisible = newIsVisible;
        }
        public bool GetNewGameState()
        {
            return newGame;
        }
        public void SetNewGameState(bool newGameState)
        {
            this.newGame = newGameState;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (MenuItem menuItem in menuItems)
            {
                menuItem.Draw(spriteBatch);
            }
            if(currentView == "AuthorView")
            {
                new MenuItem(new Vector2(593, 300), "Michał Szmyt").Draw(spriteBatch);
                new MenuItem(new Vector2(463, 400), "Informatyka Ogólna, 2016").Draw(spriteBatch);
            }
            DisplayWin();
            if (currentView == "WinView")
            {
                new MenuItem(new Vector2(548, 300), "Congratulations!").Draw(spriteBatch);
                new MenuItem(new Vector2(560, 400), "You've made it!").Draw(spriteBatch);
            }
        }

        public void Clear()
        {
            menuItems.Clear();
            switch (currentView)
            {
                case "MainMenuView": MainMenuView(); break;
                case "LevelsView": LevelsView(); break;
                case "WinView": WinView(); break;
            }
        }

        public void DisplayWin()
        {
            if (playerWon)
            {
                WinView();
                Clear();
                playerWon = false;
            }
        }

        public void SetIfPlayerWon(bool playerWon)
        {
            this.playerWon = playerWon;
        }

        //Inicjacja widoków menu:
        private void MainMenuView()
        {
            currentView = "MainMenuView";
            if (gameStarted)
            {   //kolejność dodawania jest ważna.
                menuItems.Add(new MenuItem(new Vector2(670, 250), "New game"));
                menuItems.Add(new MenuItem(new Vector2(670, 350), "Levels"));
                menuItems.Add(new MenuItem(new Vector2(670, 450), "Options"));
                menuItems.Add(new MenuItem(new Vector2(670, 550), "Author"));
                menuItems.Add(new MenuItem(new Vector2(670, 650), "Exit"));
                menuItems.Add(new MenuItem(new Vector2(670, 150), "Resume"));
            }
            else
            {
                menuItems.Add(new MenuItem(new Vector2(670, 200), "New game"));
                menuItems.Add(new MenuItem(new Vector2(670, 300), "Levels"));
                menuItems.Add(new MenuItem(new Vector2(670, 400), "Options"));
                menuItems.Add(new MenuItem(new Vector2(670, 500), "Author"));
                menuItems.Add(new MenuItem(new Vector2(670, 600), "Exit"));
            }
        }
        private void LevelsView()
        {
            currentView = "LevelsView";
            menuItems.Add(new MenuItem(new Vector2(670, 100), "Level1"));
            menuItems.Add(new MenuItem(new Vector2(670, 200), "Level2"));
            menuItems.Add(new MenuItem(new Vector2(670, 300), "Level3"));
            menuItems.Add(new MenuItem(new Vector2(670, 400), "Level4"));
            menuItems.Add(new MenuItem(new Vector2(670, 500), "Level5"));
            menuItems.Add(new MenuItem(new Vector2(670, 600), "Return"));
        }
        private void OptionsView()
        {
            currentView = "OptionsView";
            menuItems.Add(new MenuItem(new Vector2(670, 300), "Resolution"));
            menuItems.Add(new MenuItem(new Vector2(670, 400), "Sound"));
            menuItems.Add(new MenuItem(new Vector2(670, 500), "Return"));
        }
        private void ResolutionView()
        {
            currentView = "ResolutionView";
            menuItems.Add(new MenuItem(new Vector2(670, 150), "800x600"));
            menuItems.Add(new MenuItem(new Vector2(670, 250), "1024x768"));
            menuItems.Add(new MenuItem(new Vector2(670, 350), "1366x768"));
            menuItems.Add(new MenuItem(new Vector2(670, 450), "1600x900"));
            menuItems.Add(new MenuItem(new Vector2(670, 550), "1980x1080"));
            menuItems.Add(new MenuItem(new Vector2(670, 650), "Return"));
        }
        private void SoundView()
        {
            currentView = "SoundView";
            menuItems.Add(new MenuItem(new Vector2(650, 200), "Turn music on"));
            menuItems.Add(new MenuItem(new Vector2(650, 300), "Turn music off"));
            menuItems.Add(new MenuItem(new Vector2(650, 400), "Turn sounds on"));
            menuItems.Add(new MenuItem(new Vector2(650, 500), "Turn sounds off"));
            menuItems.Add(new MenuItem(new Vector2(650, 600), "Return"));
        }
        private void AuthorView()
        {
            currentView = "AuthorView";
            menuItems.Add(new MenuItem(new Vector2(670, 600), "Return"));
        }
        private void WinView()
        {
            currentView = "WinView";
            menuItems.Add(new MenuItem(new Vector2(670, 600), "Return"));
        }

        private void ViewsLogic(Game game)
        {
            switch (currentView)
            {
                case "MainMenuView":
                    switch (selected)
                    {  
                        case 0: this.newGame = true; this.gameStarted = true; this.isVisible = false; break; //new game
                        case 1: menuItems.Clear(); LevelsView(); break;
                        case 2: menuItems.Clear(); OptionsView(); break;
                        case 3: menuItems.Clear(); AuthorView(); break;
                        case 4: menuItems.Clear(); game.Exit(); break;
                        case 5: this.isVisible = false; break; //resume
                    }
                    break;
                case "LevelsView":
                    switch (selected)
                    {
                        case 0: break;
                        case 1: break;
                        case 2: break;
                        case 3: break;
                        case 4: break;
                        case 5: menuItems.Clear(); MainMenuView(); break;
                    }
                    break;
                case "OptionsView":
                    switch (selected)
                    {
                        case 0: menuItems.Clear(); ResolutionView(); break;
                        case 1: menuItems.Clear(); SoundView(); break;
                        case 2: menuItems.Clear(); MainMenuView(); break;
                    }
                    break;
                case "ResolutionView":
                    switch (selected)
                    {
                        case 0: break;
                        case 5: menuItems.Clear(); OptionsView(); break;
                    }
                    break;
                case "SoundView":
                    switch (selected)
                    {
                        case 0: break;
                        case 4: menuItems.Clear(); OptionsView(); break;
                    }
                    break;
                case "AuthorView":
                    switch (selected)
                    {
                        case 0: menuItems.Clear(); MainMenuView(); break;
                    }
                    break;
                case "WinView":
                    switch (selected)
                    {
                        case 0: menuItems.Clear(); playerWon = false; MainMenuView(); break;
                    }
                    break;
            }
        }

        //Input:
        private void UpdateKeyboardState()
        {
            this.lastKbState = kbState;
            this.kbState = Keyboard.GetState();
        }

        private void Selecting(Game1 game)
        { //Logika zaznaczania:
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

            //Co ma się dziać przy wybraniu danego pola Enterem:
            if (kbState.IsKeyDown(Keys.Enter) && !lastKbState.IsKeyDown(Keys.Enter))
            {   // Po wciśnięciu klawisza Enter funkcja ViewsLogic decyduje o tym, co ma się wykonać dalej przy obecnym zaznaczeniu elementu.
                ViewsLogic(game);
            }
        }
    }
}
