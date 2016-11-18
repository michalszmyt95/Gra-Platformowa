using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace GraPlatformowa
{
    class MenuItem : GameObject
    {
        private string name;
        private Color selectedColor = Color.MediumVioletRed;
        private Color unselectedColor = Color.White;
        private bool isSelected = false;

        public MenuItem(Vector2 newPosition, string newName)
        {
            this.position = newPosition;
            this.name = newName;
        }

        public MenuItem(Vector2 newPosition,  string newName, Color newSelectedColor, Color newUnselectedColor)
        {
            this.position = newPosition;
            this.name = newName;
            this.selectedColor = newSelectedColor;
            this.unselectedColor = newUnselectedColor;
        }

        public void isItSelected(bool value)
        {
            isSelected = value;
        }

        public void Draw(SpriteBatch spriteBatch) {
            if (isSelected)
                spriteBatch.DrawString(Game1.menuFont, this.name, this.position, this.selectedColor);
            else
                spriteBatch.DrawString(Game1.menuFont, this.name, this.position, this.unselectedColor);
        }
    }
}
