using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("\nРасчет объема озера:");
        Console.Write("Введите начальный объем A (км3): ");
        double volume = double.Parse(Console.ReadLine());
        Console.Write("Введите процент уменьшения p (%): ");
        double decreasePercent = double.Parse(Console.ReadLine());
        Console.Write("Введите дополнительное уменьшение B (км3): ");
        double decrease = double.Parse(Console.ReadLine());
        Console.Write("Введите количество лет N: ");
        int years = int.Parse(Console.ReadLine());

        double currentVolume = volume;
        for (int i = 0; i < years; i++)
        {
            currentVolume *= (1 - decreasePercent / 100.0);
            currentVolume -= decrease;
            if (currentVolume < 0) currentVolume = 0;
        }

        Console.WriteLine($"\nОбъем воды через {years} лет: {currentVolume} км3");
    }
}