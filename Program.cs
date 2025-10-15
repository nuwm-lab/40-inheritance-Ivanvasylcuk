using System;

namespace Geometry
{
    // Клас для півплощини a1*x1 + a2*x2 <= b
    class HalfPlane
    {
        protected double a1, a2, b;

        // Метод для задання коефіцієнтів
        public virtual void SetCoefficients(double a1, double a2, double b)
        {
            this.a1 = a1;
            this.a2 = a2;
            this.b = b;
        }

        // Метод для виведення коефіцієнтів
        public virtual void DisplayCoefficients()
        {
            Console.WriteLine($"Півплощина: {a1}*x1 + {a2}*x2 <= {b}");
        }

        // Метод для перевірки, чи належить точка півплощині
        public virtual bool ContainsPoint(double x1, double x2)
        {
            return a1 * x1 + a2 * x2 <= b;
        }
    }

    // Похідний клас для півпростору a1*x1 + a2*x2 + a3*x3 <= b
    class HalfSpace : HalfPlane
    {
        private double a3;

        // Перевантаження методу для задання коефіцієнтів
        public void SetCoefficients(double a1, double a2, double a3, double b)
        {
            base.SetCoefficients(a1, a2, b);
            this.a3 = a3;
        }

        // Перевантаження методу для виведення коефіцієнтів
        public void DisplayCoefficients3D()
        {
            Console.WriteLine($"Півпростір: {a1}*x1 + {a2}*x2 + {a3}*x3 <= {b}");
        }

        // Перевантаження методу для перевірки точки
        public bool ContainsPoint(double x1, double x2, double x3)
        {
            return a1 * x1 + a2 * x2 + a3 * x3 <= b;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Створюємо об'єкт півплощини
            HalfPlane hp = new HalfPlane();
            hp.SetCoefficients(2, 3, 12);
            hp.DisplayCoefficients();

            Console.Write("Введіть координати точки x1, x2 через пробіл: ");
            string[] input2D = Console.ReadLine().Split();
            double x1_2D = double.Parse(input2D[0]);
            double x2_2D = double.Parse(input2D[1]);

            if (hp.ContainsPoint(x1_2D, x2_2D))
                Console.WriteLine("Точка належить півплощині.");
            else
                Console.WriteLine("Точка не належить півплощині.");

            Console.WriteLine();

            // Створюємо об'єкт півпростору
            HalfSpace hs = new HalfSpace();
            hs.SetCoefficients(1, 2, 3, 10);
            hs.DisplayCoefficients3D();

            Console.Write("Введіть координати точки x1, x2, x3 через пробіл: ");
            string[] input3D = Console.ReadLine().Split();
            double x1_3D = double.Parse(input3D[0]);
            double x2_3D = double.Parse(input3D[1]);
            double x3_3D = double.Parse(input3D[2]);

            if (hs.ContainsPoint(x1_3D, x2_3D, x3_3D))
                Console.WriteLine("Точка належить півпростору.");
            else
                Console.WriteLine("Точка не належить півпростору.");
        }
    }
}