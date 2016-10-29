using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GraPlatformowa
{
    class CollisionDetector
    {
        Player player;
        public CollisionDetector(Player newPlayer)
        {
            this.player = newPlayer;
        }


        //Sprawdzanie zajścia kolizji statycznego obiektu z listy SceneManagera z obiektem dynamicznym, np. graczem:
        //Musiałem użyć nullable (dodanie znaku zapytania), dla przypadku, gdy dynamiczny obiekt nie koliduje z niczym w liście:
        public Block In()
        {
            foreach (Block block in SceneManager.staticBlocks)
            {
                if ((player.GetPosition().Y + player.GetScale().Y) >= block.getY() && (player.GetPosition().X + player.GetScale().X) >= (block.getX())
                    && player.GetPosition().X <= (block.getX() + block.getWidth()) && player.GetPosition().Y <= (block.getY()))
                {
                    return block;
                }
            }
            return null;
        }

        public Block On()
        {
            Console.WriteLine("alamkota");
            return new BlueBlock(player.GetPosition());
        }
    }
}
