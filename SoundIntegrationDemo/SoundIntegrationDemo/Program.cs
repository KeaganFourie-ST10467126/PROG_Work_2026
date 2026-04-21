using System.Media;

namespace SoundIntegrationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        { 
            SoundPlayer wrongSound = new SoundPlayer("incorrect.wav");
            wrongSound.PlaySync();

            SoundPlayer correctSound = new SoundPlayer("correct.wav");
            correctSound.PlaySync();

        }
    }
}
