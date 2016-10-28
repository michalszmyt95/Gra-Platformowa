using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GraPlatformowa
{
    class CollisionDetector
    {
        //Sprawdzanie zajścia kolizji statycznego obiektu z listy SceneManagera z obiektem dynamicznym, np. graczem:
        //Musiałem użyć nullable (dodanie znaku zapytania), dla przypadku, gdy dynamiczny obiekt nie koliduje z niczym w liście:
        public Block With(Vector2 dynamicObjPosition, Vector2 dynamicObjScale)
        {
            foreach (Block block in SceneManager.staticBlocks)
            {
                if ((dynamicObjPosition.Y + dynamicObjScale.Y) >= block.getY() && (dynamicObjPosition.X + dynamicObjScale.X) >= (block.getX())
                    && dynamicObjPosition.X <= (block.getX() + block.getWidth()) && dynamicObjPosition.Y <= (block.getY()))
                {
                    return block;
                }
            }
            return null;
        }
    }
}
