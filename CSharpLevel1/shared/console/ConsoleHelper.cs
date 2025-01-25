using System.Globalization;
using System.Numerics;

namespace Kanadeiar.Common;

public class ConsoleHelper
{
    public static void PrintHeader(string text = "Название и описание задачи", string title = "RearmToDDD.NET")
    {
        setupConsole(title);
        outputHeaderToConsole(text);
    }

    private static void setupConsole(string title)
    {
        Console.Title = title;
        Console.WindowWidth = 120;
    }

    private static void outputHeaderToConsole(string text)
    {
        Console.BackgroundColor = ConsoleColor.DarkGreen;
        Console.ForegroundColor = ConsoleColor.White;

        Console.WriteLine($"┌─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
        Console.WriteLine($"│{text,-117}│");
        Console.WriteLine($"└─────────────────────────────────────────────────────────────────────────────────────────────────────────────────────┘");

        Console.ForegroundColor = ConsoleColor.White;
        Console.BackgroundColor = ConsoleColor.Black;

        Console.WriteLine("");
    }

    public static void PrintFooter(string text = "Для завершения работы приложения нажмите любую кнопку ...")
    {
        Console.WriteLine("\n" + text);
        Console.ReadKey();
    }

    public static void Pause(string text = "Нажмите любую кнопку для продолжения ...")
    {
        Console.WriteLine("\n" + text);
        Console.ReadKey();
    }

    public static void PositionPrint(string message, int x, int y)
    {
        Console.SetCursorPosition(x, y);
        Console.WriteLine(message);
    }

    public static string? ReadLineFromConsole(string message)
    {
        Console.Write($"{message}:>");
        return Console.ReadLine();
    }

    public static T ReadNumberFromConsole<T>(string message)
        where T : INumber<T>
    {
        while (true)
        {
            Console.Write($"{message}:>");
            var ci = new CultureInfo("ru-ru");
            if (T.TryParse(Console.ReadLine(), ci, out T? number))
            {
                return number;
            }
            Console.WriteLine("Ошибка! Введен неверный формат числа!");

            Console.Beep();
        }
    }
}