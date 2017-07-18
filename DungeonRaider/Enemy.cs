using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRaider
{
    public class Enemy
    {
        private static int posX = 0;
        private static int posY = 0;

        public Enemy(int stgEnemyPosX, int stgEnemyPosY)
        {
            posX = stgEnemyPosX;
            posY = stgEnemyPosY;
        }

        public int[] NextStep(int heroX, int heroY)
        {
            if (heroX < posX)
                posX--;
            else
                posX++;

            if (heroY < posY)
                posY++;
            else
                posY--;

            return new int[] { posX, posY };
        }
    }
}
