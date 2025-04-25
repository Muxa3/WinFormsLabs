using System;

class Figure
    {
        public string Name { get; set; }
        public virtual void  Compute()
        {
            Console.WriteLine( Name + "  -  это неизвестная фигура" );
        }
    }
class Kub:Figure
    {
        public int a { get; set; }
        public override void  Compute()
        {
            Console.WriteLine(Name + "  -  куб со стороной " + Convert.ToString(a));
            Console.WriteLine(Name + "  имеет площадь равную  " +  Convert.ToString(6*a*a));
        }
    }
class Shar:Figure
    {
        public int r { get; set; }
        public override void  Compute()
        {
            Console.WriteLine(Name + "  -  шар с радиусом " + Convert.ToString(r));
            Console.WriteLine(Name + "  имеет площадь равную  " +  Convert.ToString(4*3.14*r*r));
        }
    }
class Cilinder:Figure
    {
        public int r { get; set; }
        public int h { get; set; }
        public override void  Compute()
        {
            Console.WriteLine(Name + "  -  цилиндр с радиусом " +  Convert.ToString(r) + " и высотой " + Convert.ToString(h));
            Console.WriteLine(Name + "  имеет площадь равную  " +  Convert.ToString(2*3.14*r*(r+h)));
        }
    }
class Parallelepiped:Figure
    {
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }
        public override void  Compute()
        {
            Console.WriteLine(Name + "  -  параллелепипед со сторонами " + Convert.ToString(a) + ", " + Convert.ToString(b) + " и " + Convert.ToString(c));
            Console.WriteLine(Name + "  имеет площадь равную  " +  Convert.ToString(2*(a*b+a*c+b*c)));
        }
    }
class Program
    {
        static void Main(string[] args)
        {
            Figure nOne = new Figure { Name = "Рыба"};
            nOne.Compute();
            Kub  nTwo = new Kub { Name = "Рыба", a = 5 };
            nTwo.Compute();
            Shar nThree = new Shar { Name = "Рыба", r = 5 };
            nThree.Compute();
            Cilinder nFour = new Cilinder { Name = "Рыба", r = 5, h = 5};
            nFour.Compute();
            Parallelepiped nFive = new Parallelepiped { Name = "Рыба", a = 5, b = 10, c = 10 };
            nFive.Compute();
        }
    }