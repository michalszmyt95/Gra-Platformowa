﻿using System;
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
    class SceneManager
    {
        //Ogólnodostępna lista wszystkich obiektów statycznych w grze:
        public static List<Rectangle> StaticObjects = new List<Rectangle>();
        // Trzeba bedzie chyba jednak do tej listy obiektów dodawać chyba bloki zamiast same rectangle...
    }
}
