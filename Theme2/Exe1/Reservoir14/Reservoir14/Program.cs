using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Расчет массы вещества в резервуаре:");
        Console.Write("Введите начальную массу P (кг): ");
        double mass = double.Parse(Console.ReadLine());
        Console.Write("Введите ежедневное изъятие T (кг): ");
        double extract = double.Parse(Console.ReadLine());
        Console.Write("Введите процент улетучивания q (%): ");
        double evaporatePercent = double.Parse(Console.ReadLine());
        Console.Write("Введите количество суток N: ");
        int days = int.Parse(Console.ReadLine());

        List<double> results = new List<double>();
        double currentMass = mass;
        for (int i = 0; i <= days; i++)
        {
            currentMass -= extract;
            if (currentMass < 0) currentMass = 0;
            currentMass *= (1 - evaporatePercent / 100.0);
            Console.WriteLine($"День {i + 1}: {currentMass} кг");
        }
    }
}