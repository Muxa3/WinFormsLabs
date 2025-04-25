using System;

namespace MyApp.Models
{
    // класс Car public т.к. к нему нужно свободно обращаться
    public class Car
    {
        // Private для инкапсуляции
        private string make;
        private string model;
        
        // Public для обращения изменения даты изготовления авто
        public int Year { get; set; }

        // Internal даёт доступ к методу, но только внутри сборки
        internal void SetMakeAndModel(string make, string model)
        {
            this.make = make;
            this.model = model;
        }

        // Protected предоставляет доступ только внутри класса и его производных
        protected virtual void DisplayInfo()
        {
            Console.WriteLine($"Make: {make}");
            Console.WriteLine($"Model: {model}");
            Console.WriteLine($"Year: {Year}");
        }
    }

    public class ElectricCar : Car
    {
        // Private для инкапсуляции
        private double batteryCapacity;

        // Public метод чтоб ставить значение обьема батарейки с private модификатором
        public void SetBatteryCapacity(double capacity)
        {
            this.batteryCapacity = capacity;
        }

        // перегрузили DisplayInfo чтобы он показывал обьем батарейки
        protected override void DisplayInfo()
        {
            base.DisplayInfo();
            Console.WriteLine($"Battery Capacity: {batteryCapacity} kWh");
        }
    }
}

namespace MyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyApp.Models.Car myCar = new MyApp.Models.Car();
            
            // Private не дает нам поменять значение вне класса
            // myCar.make = "Toyota";
            // myCar.model = "Camry";
            
            myCar.SetMakeAndModel("Toyota", "Camry");
            myCar.Year = 2023;

            MyApp.Models.ElectricCar myElectricCar = new MyApp.Models.ElectricCar();
            myElectricCar.SetMakeAndModel("Tesla", "Model 3");
            myElectricCar.Year = 2023;
            myElectricCar.SetBatteryCapacity(75.0);

            // Обьект класса не может вызывать методы с модификатором protected - можно только внутри самого класса или его производных
            // myCar.DisplayInfo();
            // myElectricCar.DisplayInfo();
        }
    }
}