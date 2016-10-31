using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
namespace GraPlatformowa
{
    class ScreenManager
    {
        GraphicsDeviceManager graphics;

        public ScreenManager(GraphicsDeviceManager newGraphics)
        {
            this.graphics = newGraphics;
        }

        public void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Z))
            {
                graphics.PreferredBackBufferWidth = 1366;
                graphics.PreferredBackBufferHeight = 768;
                graphics.ApplyChanges();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.X))
            {
                graphics.PreferredBackBufferWidth = 1600;
                graphics.PreferredBackBufferHeight = 900;
                graphics.ApplyChanges();
            }
            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                graphics.PreferredBackBufferWidth = 1980;
                graphics.PreferredBackBufferHeight = 1080;
                graphics.ApplyChanges();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.V))
            {
                graphics.PreferredBackBufferWidth = 1024;
                graphics.PreferredBackBufferHeight = 768;
                graphics.ApplyChanges();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.B))
            {
                graphics.PreferredBackBufferWidth = 800;
                graphics.PreferredBackBufferHeight = 600;
                graphics.ApplyChanges();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.F))
            {
                if (!graphics.IsFullScreen)
                {
                    graphics.IsFullScreen = true;
                    graphics.ApplyChanges();
                }
                else
                {
                    graphics.IsFullScreen = false;
                    graphics.ApplyChanges();
                }
            }
        }
        public void Draw()
        {

        }
    }
}
