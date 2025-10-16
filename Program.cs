using System;

namespace Std
{
    public class halfplane
    {
        protected double a1, a2, b;
        public halfplane() { }
        public halfplane(double a1, double a2, double b)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b = b;
        }
        public virtual void SetCoefficients(double a1, double a2, double b)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b = b;
        }
        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Рівняння півплощини: {a1} * x1 + {a2} * x2 <= {b}");
        }
        public bool ContainsPoint(double x1, double x2)
        {
            double leftSide = a1 * x1 + a2 * x2;
            return leftSide <= b;
        }
    }
    public class Pivprostir : halfplane
    {
                private double a3;

        public Pivprostir() { }

        public Pivprostir(double a1, double a2, double a3, double b)
            : base(a1, a2, b)
        {
            this.a3 = a3;
        }

        public void SetCoefficients(double a1, double a2, double a3, double b)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.a3 = a3;
            this.b = b;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Півпростір: {a1} * x1 + {a2} * x2 + {a3} * x3 <= {b}");
        }

        public bool ContainsPoint(double x1, double x2, double x3)
        {
            return a1 * x1 + a2 * x2 + a3 * x3 <= b;
        }
    }
    class Program
    {
        static void Main()
        {
            halfplane p = new halfplane();

            Console.Write("Введіть a1: ");
            double a1 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть a2: ");
            double a2 = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Введіть b: ");
            double b = double.Parse(Console.ReadLine() ?? "0");

            p.SetCoefficients(a1, a2, b);
            p.PrintCoefficients();

            Console.WriteLine("\nВведіть координати точки:");
            Console.Write("x1 = ");
            double x1 = double.Parse(Console.ReadLine() ?? "0");
            Console.Write("x2 = ");
            double x2 = double.Parse(Console.ReadLine() ?? "0");

            if (p.ContainsPoint(x1, x2))
                Console.WriteLine("Точка належить півплощині.");
            else
                Console.WriteLine("Точка не належить півплощині.");

                Console.WriteLine("\n=== Перевірка півпростору ===");
            Pivprostir space = new Pivprostir(1, 2, 3, 10);
            space.PrintCoefficients();
            Console.WriteLine(space.ContainsPoint(1, 1, 1)
                ? "Точка належить півпростору."
                : "Точка не належить півпростору.");
        }
    }
}