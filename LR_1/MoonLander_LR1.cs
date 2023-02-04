using System;
namespace moon_lander
{
    class Program
    {
        static void Main(string[] args)
        {

            static int GetInt(string msg, int x1, int x2)
            {
                bool valid = false;
                int input = 0;

                do
                {
                    Console.Write(msg);
                    valid = int.TryParse(Console.ReadLine(), out input);
                } while (!valid || (input != x1 && input != x2));

                return input;
            }

            static void FallingTime(double A, double B, double C, out int n, out double x1, out double x2)
            {
                n = 0;
                x1 = 0;
                x2 = 0;
                    double d = B * B - 4 * A * C;

                    if (d < 0) return;
                    if (d == 0) n = 1;
                    if (d > 0) n = 2;

                    x1 = (-B + Math.Sqrt(d)) / (2 * A);
                    x2 = (-B - Math.Sqrt(d)) / (2 * A);

            }

            //данные для расчетов
            double h = 1000; //начальная высота в метрах
            double f = 60; //на сколько времени хватит топлива в секундах
            double v = 0; //скорость корабля в м/с
            double t = 0; // время в секундах
            int engine = 0; //0-двигатель выключен, 1-включен
            const double g = -1.62; //ускорение свободного падения на луне в м/с^2
            const double a = 2; //ускорение корабля в м/с^2
            const double vMax = 10; //скорость в м/с, при которой корабль разбивается

            //основной алгоритм
            while (h >= 0.0000001)
            {
                Console.WriteLine($"Текущие значения: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек");
                engine = GetInt("(1-включить, 0-выключить): ", 0, 1);
                double currenta = engine == 0 ? g : a;
                t = 1;

                if (t < 0) t = 0;
                if (t > f) t = f;

                int n;
                double t1, t2;
                FallingTime(currenta / 2, v, h, out n, out t1, out t2);

                if (n > 0 && t1 > 0 && t > t1) t = t1;
                if (n > 0 && t2 > 0 && t > t2) t = t2;

                if (engine == 1) f -= t;
                h = h + v * t + currenta / 2 * t * t;
                v = v + currenta * t;
            }


            Console.WriteLine($"Текущие значения: высота {h:F2} м, скорость {Math.Abs(v):F2} м/с, топлива {f:F2} сек");



            if (Math.Abs(v) > vMax) 
                Console.WriteLine("Вы разбились!");
            else
                Console.WriteLine("Вы приземлились!");
        }
    }
}
       