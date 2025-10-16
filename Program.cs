using System;

namespace Std
{
    public class Halfplane
    {
        protected double a1, a2, b;

        public Halfplane() { }

        public Halfplane(double a1, double a2, double b)
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
            Console.WriteLine($"Півплощина: {a1} * x1 + {a2} * x2 <= {b}");
        }

        public bool ContainsPoint(double x1, double x2)
        {
            double leftSide = a1 * x1 + a2 * x2;
            return leftSide <= b;
        }
    }

    public class Pivprostir : Halfplane
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
            Console.WriteLine("Оберіть об’єкт:\n1 — Півплощина\n2 — Півпростір");
            int choice = int.Parse(Console.ReadLine() ?? "1");

            if (choice == 1)
            {
                Halfplane p = new Halfplane();

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

                Console.WriteLine(p.ContainsPoint(x1, x2)
                    ? "Точка належить півплощині."
                    : "Точка не належить півплощині.");
            }
            else if (choice == 2)
            {
                Pivprostir pp = new Pivprostir();

                Console.Write("Введіть a1: ");
                double a1 = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Введіть a2: ");
                double a2 = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Введіть a3: ");
                double a3 = double.Parse(Console.ReadLine() ?? "0");

                Console.Write("Введіть b: ");
                double b = double.Parse(Console.ReadLine() ?? "0");

                pp.SetCoefficients(a1, a2, a3, b);
                pp.PrintCoefficients();

                Console.WriteLine("\nВведіть координати точки:");
                Console.Write("x1 = ");
                double x1 = double.Parse(Console.ReadLine() ?? "0");
                Console.Write("x2 = ");
                double x2 = double.Parse(Console.ReadLine() ?? "0");
                Console.Write("x3 = ");
                double x3 = double.Parse(Console.ReadLine() ?? "0");

                Console.WriteLine(pp.ContainsPoint(x1, x2, x3)
                    ? "Точка належить півпростору."
                    : "Точка не належить півпростору.");
            }
        }
    }
}