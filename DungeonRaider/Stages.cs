using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;

namespace DungeonRaider
{
    public class Stages
    {
        public const int MAX_LINES = 10;
        public const int MAX_ROWS = 20;

        public static List<StringBuilder> stages = new List<StringBuilder>();

        public Stages()
        {
            carregaFases();
        }

        private void carregaFases()
        {
            //http://www.theasciicode.com.ar/

            StringBuilder stage1 = new StringBuilder();
            stage1.AppendLine("╔═╦════════════════╗");
            stage1.AppendLine("║ ║                ║");
            stage1.AppendLine("║ ║ ║              ║");
            stage1.AppendLine("║ ║ ║              ║");
            stage1.AppendLine("║ ║#║              ║");
            stage1.AppendLine("║   ║              ║");
            stage1.AppendLine("╠═╗ ║              ║");
            stage1.AppendLine("║x║ ║              ║");
            stage1.AppendLine("║   ║              ║");
            stage1.AppendLine("╚═══╩══════════════╝");

            stages.Add(stage1);
        }

        public static string[,] GetStage(int v)
        {

            StringBuilder stg = stages[v-1];

            string[] lines = stg.ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string[,] stageX = new string[MAX_LINES, MAX_ROWS];

            for (int i = 0; i < MAX_LINES; i++)
            {
                for (int j = 0; j < MAX_ROWS; j++)
                {
                    stageX[i, j] = lines[i][j].ToString();
                }
            }

            return stageX;
        }

        public static void abrePorta(int heroPosX, int heroPosY, int currentStage)
        {
            if (currentStage == 1)
            {
                if (heroPosX == 1 && heroPosY == 7) //Porta1
                {
                    removePorta(1, 3, 4);
                    var synth = new SpeechSynthesizer();
                    synth.SpeakAsync("abriu a porta nesse caráiu!");
                }
            }
        }

        private static void removePorta(int currentStage, int porta1_x, int porta1_y)
        {
            //Remove porta
            string[] stageLines = stages[currentStage - 1].ToString().Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            string linha = stageLines[porta1_y];
            char[] linhaArray = linha.ToCharArray();
            linhaArray[porta1_x] = ' ';
            linha = new string(linhaArray);
            stageLines[porta1_y] = linha;

            stages[currentStage - 1] = new StringBuilder(string.Join(Environment.NewLine, stageLines));
        }

    }
}