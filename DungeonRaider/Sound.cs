using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace DungeonRaider
{
    public class Sound
    {
        public static void backgroudMusic()
        {
            playSimpleSound("Media\\DragonQuest1.wav");
        }

        private static void playSimpleSound(string wavFile)
        {
            SoundPlayer simpleSound = new SoundPlayer(wavFile);
            try
            {
                simpleSound.SoundLocation = wavFile;
                simpleSound.Load();
                simpleSound.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Wav File Trouble: {0} \r\n {1} \r\n {2}", wavFile, ex.Message, ex.StackTrace);
            }
        }

    }
}
