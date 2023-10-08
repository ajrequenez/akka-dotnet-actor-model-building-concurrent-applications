namespace MovieStreaming.Common
{
    public static class ColorConsole
    {
        public static void WriteLineBlue(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineCyan(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineGray(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineGreen(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }

        public static void WriteLineMagenta(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor= ConsoleColor.Magenta;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }
        public static void WriteLineRed(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }
        public static void WriteLineYellow(string text)
        {
            var beforeColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine(text);
            Console.ForegroundColor = beforeColor;
        }
    }
}
