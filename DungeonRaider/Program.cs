using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRaider
{
    class Program
    {
        private const int MAX_Y = 10;
        private const int MAX_X = 20;
        public static string[,] stage;

        static void Main(string[] args)
        {
            //Initializes
            Console.Title = "Dungeon Raider";
            Console.SetWindowSize(40, 20);
            Console.ForegroundColor = ConsoleColor.Gray;

            Stages stg = new Stages();

            //Sound.backgroudMusic();


            stage = Stages.GetStage(1);

            int heroPosX = 1;
            int heroPosY = 1;

            //Enemy enemy1 = new Enemy(heroPosX, heroPosY);
            Enemy enemy1 = new Enemy(10, 6);

            printStage(stage, heroPosX, heroPosY);

            ConsoleKeyInfo cki;

            do
            {
                cki = Console.ReadKey();
                Console.Clear();

                //if (cki.Key == ConsoleKey.RightArrow && heroPosX < MAX_X-2)
                if (cki.Key == ConsoleKey.RightArrow && podeIrDireita(heroPosX, heroPosY))
                    heroPosX++;

                if (cki.Key == ConsoleKey.LeftArrow && podeIrEsquerda(heroPosX, heroPosY))
                    heroPosX--;

                if (cki.Key == ConsoleKey.UpArrow && podeIrCima(heroPosX, heroPosY))
                    heroPosY--;

                if (cki.Key == ConsoleKey.DownArrow && podeIrBaixo(heroPosX, heroPosY))
                    heroPosY++;

                int[] teste = enemy1.NextStep(heroPosX,heroPosY);

                Stages.updateEnemyPosition(x, y);

                stage = Stages.GetStage(1);

                printStage(stage, heroPosX, heroPosY);

            } while (cki.Key != ConsoleKey.Escape);
        }

        public static void printStage(string[,] stage, int heroPosX, int heroPosY)
        {
            stage[heroPosY, heroPosX] = "@";

            //Print all
            cabecalho();
            for (int i = 0; i < MAX_Y; i++)
            {
                Console.Write("          ");
                for (int j = 0; j < MAX_X; j++)
                {
                    Console.Write(stage[i, j]);
                }
                Console.WriteLine();
            }

            rodape();
        }

        public static bool podeIrDireita(int heroPosX, int heroPosY)
        {
            string prox = stage[heroPosY, heroPosX + 1].ToString();

            if (ehParede(prox)) //Valida se o proximo eh parede
                return false;

            return true;
        }

        public static bool podeIrEsquerda(int heroPosX, int heroPosY)
        {
            string prox = stage[heroPosY, heroPosX - 1].ToString();

            if (ehParede(prox)) //Valida se o proximo eh parede
                return false;

            return true;
        }

        public static bool podeIrCima(int heroPosX, int heroPosY)
        {
            string prox = stage[heroPosY-1, heroPosX].ToString();

            if (ehParede(prox)) //Valida se o proximo eh parede
                return false;

            Stages.abrePorta(heroPosX, heroPosY - 1, 1);

            return true;
        }

        public static bool podeIrBaixo(int heroPosX, int heroPosY)
        {
            string prox = stage[heroPosY + 1, heroPosX].ToString();

            if (ehParede(prox)) //Valida se o proximo eh parede
                return false;

            return true;
        }

        public static bool ehParede(string duvida)
        {
            if (duvida == "║" || duvida == "╣" || duvida == "╗" || duvida == "╝" || duvida == "╚" || duvida == "╔"
                || duvida == "╩" || duvida == "╦" || duvida == "╠" || duvida == "═" || duvida == "╬" || duvida == "#")
                return true;

            return false;
        }

        private static void cabecalho()
        {
            Console.WriteLine();
            Console.WriteLine("======== ░▒▓ DUNGEON RAIDER ▓▒░ ========");
            Console.WriteLine();
        }

        private static void rodape()
        {
            Console.WriteLine();
            string risca = "";
            for (int i = 0; i < (MAX_X*2); i++)
                risca = risca + "=";
            Console.WriteLine(risca);
            Console.WriteLine();
            Console.WriteLine("Press ESC to exit...");
        }
    }
}
