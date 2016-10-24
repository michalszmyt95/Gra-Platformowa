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
        Vector2 dynamicObjPosition; //Obiekt dynamiczny, który ma kolidować, np. Gracz.
        Vector2 dynamicObjScale;
        List<Rectangle> staticObj = new List<Rectangle>(); //Lista obiektów nieruchomych prostokątów, z którymi kolidować ma obiektZmienny.

        //Konstruktor dodający obiekt dynamiczny oraz obiekty z listy tych co mają kolidować, do CollisionDetector
        public CollisionDetector(ref Vector2 dynamicObjPosition, ref Vector2 dynamicObjScale, List<Rectangle> staticObj)
        {
            this.dynamicObjPosition = dynamicObjPosition;
            this.dynamicObjScale = dynamicObjScale;
            this.staticObj = staticObj;
        }

        public bool Collision(Vector2 dynamicObjPosition, Vector2 dynamicObjScale) //Sprawdzenie kolizji.
        {
            this.dynamicObjPosition = dynamicObjPosition;
            this.dynamicObjScale = dynamicObjScale;

            foreach (Rectangle obj in this.staticObj)
            {
                if (this.dynamicObjPosition.Y + dynamicObjScale.Y > obj.Y)
                {
                    Console.WriteLine("test");
                    return true;
                }
                Console.WriteLine("test: "+ this.dynamicObjPosition);
            }
            return false;
        }
    }
}
