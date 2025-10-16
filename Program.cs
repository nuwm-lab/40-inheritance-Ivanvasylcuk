using System;

namespace Std
{
    public class Halfplane
    {
        private double _a1, _a2, _b;

        public double A1
        {
            get => _a1;
            protected set => _a1 = value;
        }

        public double A2
        {
            get => _a2;
            protected set => _a2 = value;
        }

        public double B
        {
            get => _b;
            protected set => _b = value;
        }

        public Halfplane() { }

        public Halfplane(double a1, double a2, double b)
        {
            A1 = a1;
            A2 = a2;
            B = b;
        }

        public virtual void SetCoefficients(double a1, double a2, double b)
        {
            A1 = a1;
            A2 = a2;
            B = b;
        }

        public virtual void PrintCoefficients()
        {
            Console.WriteLine($"Halfplane: {A1} * x1 + {A2} * x2 <= {B}");
        }

        public bool ContainsPoint(double x1, double x2)
        {
            double leftSide = A1 * x1 + A2 * x2;
            return leftSide <= B;
        }
    }

    public class Halfspace : Halfplane
    {
        private double _a3;

        public double A3
        {
            get => _a3;
            protected set => _a3 = value;
        }

        public Halfspace() { }

        public Halfspace(double a1, double a2, double a3, double b)
            : base(a1, a2, b)
        {
            A3 = a3;
        }

        public new void SetCoefficients(double a1, double a2, double a3, double b)
        {
            A1 = a1;
            A2 = a2;
            A3 = a3;
            B = b;
        }

        public override void PrintCoefficients()
        {
            Console.WriteLine($"Halfspace: {A1} * x1 + {A2} * x2 + {A3} * x3 <= {B}");
        }

        public bool ContainsPoint(double x1, double x2, double x3)
        {
            return A1 * x1 + A2 * x2 + A3 * x3 <= B;
        }
    }
    class Program
    {
        static void Main()
        {
            Halfplane p = new Halfplane();

            Console.Write("Enter a1: ");
            double a1 = ReadDouble();

            Console.Write("Enter a2: ");
            double a2 = ReadDouble();

            Console.Write("Enter b: ");
            double b = ReadDouble();

            p.SetCoefficients(a1, a2, b);
            p.PrintCoefficients();

            Console.WriteLine("\nEnter point coordinates:");
            Console.Write("x1 = ");
            double x1 = ReadDouble();

            Console.Write("x2 = ");
            double x2 = ReadDouble();

            Console.WriteLine(p.ContainsPoint(x1, x2)
                ? "The point belongs to the halfplane."
                : "The point does not belong to the halfplane.");

            Console.WriteLine("\n=== Halfspace test ===");
            Halfspace space = new Halfspace(1, 2, 3, 10);
            space.PrintCoefficients();
            Console.WriteLine(space.ContainsPoint(1, 1, 1)
                ? "The point belongs to the halfspace."
                : "The point does not belong to the halfspace.");
        }

        static double ReadDouble()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (double.TryParse(input, out double result))
                    return result;

                Console.Write("Invalid input. Please enter a number: ");
            }
        }
    }
}
