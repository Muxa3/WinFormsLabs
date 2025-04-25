using System;

class Ploschad
    {
        public string Name { get; set; }
        public void Compute(string Figure, int a)
        {
            if (Figure == "Куб") 
                {
                    int S = 6*a*a;
                    Console.WriteLine("Площадь " + Figure + "а со стороной " + Convert.ToString(a) + " = " + Convert.ToString(S));
                }
            else if (Figure == "Шар") 
                {
                    double S = 4*3.14*a*a;
                    Console.WriteLine("Площадь " + Figure + "а с радиусом " + Convert.ToString(a) + " = " + Convert.ToString(S));
                }
            else {}
        }
        public void Compute(string Figure, int a, int b)
        {
            if (Figure == "Цилиндр")
                {
                    double S = 2*3.14*a*(a+b);
                    Console.WriteLine("Площадь " + Figure + "а с радиусом " + Convert.ToString(a) + " и высотой " + Convert.ToString(b) + " = " + Convert.ToString(S));
                }
            else {}
        }
        public void Compute(string Figure, int a, int b, int c)
        {
            if (Figure == "Параллелепипед")
                {
                    int S = 2*(a*b+a*c+b*c);
                    Console.WriteLine("Площадь " + Figure + "а со сторонами " + Convert.ToString(a) + ", " + Convert.ToString(b) + " и " + Convert.ToString(c) +" = " + Convert.ToString(S));
                }
            else {}
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
           Ploschad Primer = new Ploschad { Name = "Первый" };
            Primer.Compute("Куб", 5);
            Primer.Compute("Шар", 5);
            Primer.Compute("Цилиндр", 5, 5);
            Primer.Compute("Параллелепипед", 5, 10, 10);
        }
    }