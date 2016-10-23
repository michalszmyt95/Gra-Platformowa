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
    class CollisionDetector
    {
        Rectangle dynamicObj; //Obiekt dynamiczny, który ma kolidować, np. Gracz.
        List<Rectangle> staticObj = new List<Rectangle>(); //Lista obiektów statycznych prostokątów, z którymi kolidować ma obiektZmienny.

        //Konstruktor dodający obiekty z listy tych co mają kolidować, do CollisionDetector
        public CollisionDetector(List<Rectangle> staticObj)
        {
            this.staticObj = staticObj;
        }

        public bool Collision(Rectangle dynamicObj) //Sprawdzenie kolizji.
        {
            this.dynamicObj = dynamicObj;
            foreach (Rectangle obj in this.staticObj)
            {
                //Metoda Intersects sprawdza, czy pole dynamicznego obiektu zawiera się w statycznym obiekcie obj:
                if (this.dynamicObj.Intersects(obj)) {
                    Console.WriteLine("test");
                    return true;
                }
            }
            return false;
        }
    }
}
