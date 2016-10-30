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

        public Block On() // Zwraca blok z listy SceneManagera z którym gracz aktualnie część wspólną dla warunku, że spód (nogi) gracza jest zawiera się w bloku.
        {
            playerHead = player.GetPosition().Y; playerLeft = player.GetPosition().X;
            playerFeet = player.GetPosition().Y + player.GetScale().Y;
            playerRight = player.GetPosition().X + player.GetScale().X;

            foreach (Block block in SceneManager.staticBlocks)
            {
                blockHead = block.GetPosition().Y; blockLeft = block.GetPosition().X;
                blockFeet = block.GetPosition().Y + block.GetScale().Y;
                blockRight = block.GetPosition().X + block.GetScale().X;

                if (playerRight >= blockLeft && playerLeft <= blockRight && playerFeet >= blockHead && playerFeet <= blockFeet)
                    return block;
            }
            return null;
        }

        public Block Inner() // Zwraca blok z listy SceneManagera z którym gracz aktualnie część wspólną dla warunku, że obojętnie która część gracza zawiera się w bloku.
        {
            playerHead = player.GetPosition().Y; playerLeft = player.GetPosition().X;
            playerFeet = player.GetPosition().Y + player.GetScale().Y;
            playerRight = player.GetPosition().X + player.GetScale().X;

            foreach (Block block in SceneManager.staticBlocks)
            {
                blockHead = block.GetPosition().Y; blockLeft = block.GetPosition().X;
                blockFeet = block.GetPosition().Y + block.GetScale().Y;
                blockRight = block.GetPosition().X + block.GetScale().X;

                if (playerRight >= blockLeft && playerLeft <= blockRight && playerFeet >= blockHead && playerHead <= blockFeet)
                    return block;
            }
            return null;
        }

        public List<object> IcyTowerLike(ref float playerY, ref float playerVY)
        {
            Block block = this.On();
            bool standing = false;
            List<object> ArgList = new List<object>();

            if (block != null)
            {
                if (player.GetLastPosition().Y == playerY) //<-- Ten kod odpowiada za możliwość chodzenia po schodkach:
                    playerY = block.GetPosition().Y - player.GetScale().Y; 

                if (playerVY >= 0 && player.GetLastPosition().Y + player.GetScale().Y <= block.GetPosition().Y)
                    standing = true; //<-- Warunek stania na bloku gdy gracz był w ruchu Y.
                else
                    standing = false; //<-- Ta linijka kodu jest potrzebna, by gracz mógł skakać stojąc na bloku.
            }
            else 
                standing = false; // //<-- Gdy blok z którym gracz koliduje to null, czyli gracz z niczym nie koliduje.

            if (standing)
            {
                playerY = block.GetPosition().Y - player.GetScale().Y;
                playerVY = 0;
            }

            ArgList.Add(block);
            ArgList.Add(standing);
            return ArgList;
        }


    }
}