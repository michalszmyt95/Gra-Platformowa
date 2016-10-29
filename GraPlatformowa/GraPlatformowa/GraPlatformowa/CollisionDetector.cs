using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace GraPlatformowa
{
    class CollisionDetector
    {
        Player player;

        private float playerFeet;
        private float playerHead;
        private float playerLeft;
        private float playerRight;

        private float blockHead;
        private float blockFeet;
        private float blockLeft;
        private float blockRight;

        public CollisionDetector(Player newPlayer)
        {
            this.player = newPlayer;
        }

        //Sprawdzanie zajścia kolizji statycznego obiektu z listy SceneManagera z obiektem dynamicznym, np. graczem:
        //Musiałem użyć nullable (dodanie znaku zapytania), dla przypadku, gdy dynamiczny obiekt nie koliduje z niczym w liście:
        public Block In()
        {
            playerHead = player.GetPosition().Y; playerLeft = player.GetPosition().X;
            playerFeet = player.GetPosition().Y + player.GetScale().Y;
            playerRight = player.GetPosition().X + player.GetScale().X;

            foreach (Block block in SceneManager.staticBlocks)
            {
                blockHead = block.GetPosition().Y; blockLeft = block.GetPosition().X;
                blockFeet = block.GetPosition().Y + block.GetScale().Y;
                blockRight = block.GetPosition().X + block.GetScale().X;

                if (playerFeet >= blockHead && playerHead <= blockFeet && playerRight >= blockLeft && playerLeft <= blockRight)
                {
                    return block;
                }
            }
            return null;
        }

        public Block On() // Zwraca blok z którym gracz aktualnie część wspólną.
        {
            playerHead = player.GetPosition().Y; playerLeft = player.GetPosition().X;
            playerFeet = player.GetPosition().Y + player.GetScale().Y;
            playerRight = player.GetPosition().X + player.GetScale().X;

            foreach (Block block in SceneManager.staticBlocks)
            {
                blockHead = block.GetPosition().Y; blockLeft = block.GetPosition().X;
                blockFeet = block.GetPosition().Y + block.GetScale().Y;
                blockRight = block.GetPosition().X + block.GetScale().X;

                if(playerRight >= blockLeft && playerLeft <= blockRight && playerFeet >= blockHead && playerFeet <= blockFeet)
                    return block;
            }
            return null;
        }

        public bool IcyTowerLike() // Zwraca informacje o tym czy gracz stoi.
        {
            return false;
        }


    }
}
