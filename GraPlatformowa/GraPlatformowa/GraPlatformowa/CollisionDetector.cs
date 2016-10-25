using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GraPlatformowa
{
    class CollisionDetector
    {
        //Sprawdzanie zajścia kolizji statycznego obiektu z listy SceneManagera z obiektem dynamicznym, np. graczem:
        //Musiałem użyć nullable (dodanie znaku zapytania), dla przypadku, gdy dynamiczny obiekt nie koliduje z niczym w liście:
        public Rectangle? With(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if ((dynamicObjPosition.Y + dynamicObjScale.Y) > obj.Y && (dynamicObjPosition.X + dynamicObjScale.X) >= (obj.X)
                    && dynamicObjPosition.X <= (obj.X + obj.Width) && dynamicObjPosition.Y < (obj.Y))
                {
                    return obj;
                }
            }
            return null;
        }
        /*
        public Rectangle? PlayerOver(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if (dynamicObjPosition.Y <= (obj.Y + 10) &&  dynamicObjPosition.X <= (obj.X + obj.Width - 10)
                    && (dynamicObjPosition.X + dynamicObjScale.X) >= (obj.X + 10) && (dynamicObjPosition.Y + dynamicObjScale.Y) >= obj.Y)
                {
                    return obj;
                }
            }
            return null;
        }
        public Rectangle? PlayerUnder(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if (dynamicObjPosition.Y <= (obj.Y + obj.Height) && dynamicObjPosition.X <= (obj.X + obj.Width)
                    && (dynamicObjPosition.X + dynamicObjScale.X) >= obj.X && (dynamicObjPosition.Y + dynamicObjScale.Y) >= (obj.Y + obj.Height - 10))
                {
                    return obj;
                }
            }
            return null;
        }
        public Rectangle? PlayerAtLeft(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if ((dynamicObjPosition.Y + dynamicObjScale.Y) > obj.Y && (dynamicObjPosition.X + dynamicObjScale.X) >= obj.X
                    && dynamicObjPosition.X <= (obj.X + 10) && dynamicObjPosition.Y < (obj.Y + obj.Height))
                {
                    return obj;
                }
            }
            return null;
        }
        public Rectangle? PlayerAtRight(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Rectangle obj in SceneManager.StaticObjects)
            {
                if ((dynamicObjPosition.Y + dynamicObjScale.Y) > obj.Y && (dynamicObjPosition.X + dynamicObjScale.X) >= (obj.X + obj.Width -10)
                    && dynamicObjPosition.X <= (obj.X + obj.Width) && dynamicObjPosition.Y < (obj.Y + obj.Height))
                {
                    return obj;
                }
            }
            return null;
        }
        */
    }
}
