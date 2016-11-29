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
    abstract class GameObject
    {
        protected Vector2 position = new Vector2(100, 100);
        protected Vector2 scale = new Vector2(50, 25);
        public Vector2 GetPosition()
        {
            return this.position;
        }
        public Vector2 GetScale()
        {
            return this.scale;
        }
    }
}
