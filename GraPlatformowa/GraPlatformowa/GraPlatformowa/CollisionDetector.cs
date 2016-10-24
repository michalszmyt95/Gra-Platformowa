using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GraPlatformowa
{
    class CollisionDetector
    {
        //Sprawdzanie zajścia kolizji statycznego obiektu z listy SceneManagera z obiektem dynamicznym, np. graczem:
        public Rectangle? With(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if ((dynamicObjPosition.Y + dynamicObjScale.Y) > obj.Y && (dynamicObjPosition.X + dynamicObjScale.X) >= obj.X 
                    && dynamicObjPosition.X <= (obj.X + obj.Width) && dynamicObjPosition.Y < (obj.Y + obj.Height))
                {
                    //return true;
                    return obj;
                }
            }
            return null;
        }
    }
}
