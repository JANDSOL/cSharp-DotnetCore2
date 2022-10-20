using static System.Console;
namespace CoreSchool.Util
{
    public static class Printer
    {
        public static void DrawLine(int size = 60)
        {
            WriteLine("".PadLeft(size, '='));
        }
        public static void WriteTitle(string title)
        {
            const int EXTRA_SPACE = 4;
            var SIZE_TITLE = title.Length + EXTRA_SPACE;
            WriteLine("".PadLeft(SIZE_TITLE, '='));
            WriteLine($"| {title} |");
            WriteLine("".PadLeft(SIZE_TITLE, '='));
        }
    }
}
