using Figgle.Fonts;

namespace ASCII_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Changing the color of the console text
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hi this is a different color");
            Console.ResetColor();

            DrawBorder("ASCII Art Demo");
            ShowWelcomeScreen();
        }

        //Draw a border with characters in red
        static void DrawBorder(string title)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new string('#', 30));
            Console.WriteLine(new string($"#       {title.PadRight(20)} #"));
            Console.WriteLine(new string('#', 30));
            Console.ResetColor();
        }

        static void ShowWelcomeScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(FiggleFonts.Big.Render("HELLO BOBO"));
            Console.ResetColor();

            string ascii = @" ____   ___  ____   ___       ____ ____       ______ __ __   ___      __ __  ___  __ __  _____  ___ 
|    \ /   \|    \ /   \     |    |    \     |      |  |  | /  _]    |  |  |/   \|  |  |/ ___/ /  _]
|  o  |     |  o  |     |     |  ||  _  |    |      |  |  |/  [_     |  |  |     |  |  (   \_ /  [_ 
|     |  O  |     |  O  |     |  ||  |  |    |_|  |_|  _  |    _]    |  _  |  O  |  |  |\__  |    _]
|  O  |     |  O  |     |     |  ||  |  |      |  | |  |  |   [_     |  |  |     |  :  |/  \ |   [_ 
|     |     |     |     |     |  ||  |  |      |  | |  |  |     |    |  |  |     |     |\    |     |
|_____|\___/|_____|\___/     |____|__|__|      |__| |__|__|_____|    |__|__|\___/ \__,_| \___|_____|
                                                                                                    ";

            Console.WriteLine(ascii);
        }
    }
            
}
